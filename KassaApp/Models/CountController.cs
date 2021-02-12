using Dapper;
using KassaApp.Forms;
using KassaApp.Models.Connection;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KassaApp.Models
{
	/// <summary>
	/// Класс содержит функционал для отслеживания остатков товаров.
	/// </summary>
	class CountController
	{
		/// <summary>
		/// Метод проверяет, хватает ли остатка товара
		/// при добавлении указанного количества товара в чек, если хватает, то из
		/// базы данных вычитается это количество.
		/// </summary>
		/// <param name="product">Продукт, остаток которого необходимо проверить.</param>
		/// <returns>Признак успешности выполнения операции.</returns>
		public static bool Check(Product product)
		{
			try
			{
				using (var db = ConnectionFactory.GetConnection())
				{
					var productInDB = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Id = {product.Id}")).FirstOrDefault();
					Log.Logger.Info($"Попытка выбрать товар с ID = {product.Id} в количестве {product.Quantity} шт.");
					//если количество выбранного товара меньше либо равно остатку
					if (product.Quantity <= productInDB.Quantity)
					{
						if (productInDB.Type == 1)//услуги не отслеживаются, только товары
						{
							//вычесть количество из остатков в бд
							productInDB.Quantity -= product.Quantity;
							db.Execute(SQLHelper.Update(productInDB));
							Log.Logger.Info($"Товар с ID = {product.Id} в количестве {product.Quantity} шт. " +
								$"вычтен из остатков. Остаток: {productInDB.Quantity}");
						}
						return true;
					}
					else
					{
						Log.Logger.Info($"Недостаточно товара с ID = {product.Id}. Остаток: {productInDB.Quantity}");
						MessageBox.Show("Недостаточно товара в наличии!" +
										$"\nТовар: {productInDB.Name}" +
										$"\nОстаток: {productInDB.Quantity}");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(TextFormat.GetExceptionMessage(ex));
			}
			return false;
		}
		/// <summary>
		/// Метод отвечает за восстановление остатков товара,
		/// в случае, если чек не был оплачен или товар удалён из чека.
		/// </summary>
		/// <param name="id">ID продукта, остаток которого необходимо проверить.</param>
		/// <param name="count">Количество продукта, которое необходимо восстановить.</param>
		/// <returns>Признак успешности выполнения операции.</returns>
		public static bool Recover(int id, int count)
		{
			try
			{
				using (var db = ConnectionFactory.GetConnection())
				{
					var productInDB = db.Query<Product>(SQLHelper.Select<Product>($"WHERE Id = {id}")).FirstOrDefault();
					if (productInDB.Type == 1)
					{
						//прибавить количество к остаткам в бд
						productInDB.Quantity += count;
						db.Execute(SQLHelper.Update(productInDB));
						Log.Logger.Info($"Товар с ID = {id} в количестве {count} шт. восстановлен");
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(TextFormat.GetExceptionMessage(ex));
			}
			return false;
		}
		/// <summary>
		/// Метод отвечает за восстановление остатков товаров чека,
		/// в случае, если товары были добавлены в чек, но не были
		/// удалены из него до закрытия приложения.
		/// </summary>
		/// <param name="receipt">Чек, остатки продуктов
		/// которого необходимо восстановить.</param>
		public static async Task Reconciliation(Receipt receipt)
		{
			try
			{
				using (var db = ConnectionFactory.GetConnection())
				{
					foreach (var p in receipt.Purchase)
					{
						Log.Logger.Info($"Восстановление остатков по товару с ID = {p.ProductId} в количестве {p.Count} шт.");
						Recover(p.ProductId, p.Count);//восстановление остатков товара
					}						
					if (receipt != null)
					{
						var rec = db.Query<Receipt>(SQLHelper.Select<Receipt>($"WHERE Id = {receipt.Id}")).FirstOrDefault();
						//удаление чека из бд
						db.Execute(SQLHelper.Delete(rec));
						Log.Logger.Info($"Чек с ID = {receipt.Id} удалён из базы данных");
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(TextFormat.GetExceptionMessage(ex));
			}
		}
		/// <summary>
		/// Метод отвечает за восстановление остатков товаров чеков,
		/// в случае, если они не были отмечены в базе данных,
		/// как оплаченные.
		/// </summary>
		public async static Task ReconciliationAll()
		{
			try
			{
				using (var db = ConnectionFactory.GetConnection())
				{
					
					var receipts = db.Query<Receipt>(SQLHelper.Select<Receipt>("WHERE Paid = 0"));
					Log.Logger.Info($"В базе данных найдено {receipts.Count()} неоплаченных чека");
					foreach (var r in receipts)
					{
						if (r.Summa == 0 || new Recovery(r).ShowDialog() == DialogResult.No)
						{
							Log.Logger.Info($"Восстановление остатков по чеку с ID = {r.Id}");
							if (r.Payment == 2)
								using (ITerminal terminal = CurrentHardware.GetTerminal())
								{
									if (terminal.IsEnabled())
										terminal.CancelTransaction();
								}
							await Reconciliation(r);
						}
						else
						{
							r.Paid = true;
							Log.Logger.Info($"Чек с ID = {r.Id} отмечен, как Оплаченный");
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(TextFormat.GetExceptionMessage(ex));
			}
		}
	}
}
