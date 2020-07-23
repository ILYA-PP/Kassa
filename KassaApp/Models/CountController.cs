using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp.Models
{
	//класс для отслеживания остатков товаров в БД
	class CountController
	{
		//проверка хватает ли товара
		public static bool Check(Product prod)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					var productInDB = db.Product.Where(p => p.Name == prod.Name).FirstOrDefault();
					//если количество выбранного товара меньше либо равно остатку
					if (prod.Quantity <= productInDB.Quantity)
					{
						if (productInDB.Type == 1)
						{
							//вычесть количество из остатков в бд
							productInDB.Quantity -= prod.Quantity;
							db.SaveChanges();
						}
						return true;
					}
					else
					{
						MessageBox.Show("Недостаточно товара в наличии!" +
										$"\nТовар: {productInDB.Name}" +
										$"\nОстаток: {productInDB.Quantity}");
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return false;
		}
		//восстановление остатков товара
		//в случае, если чек не был оплачен или товар удалён из чека
		public static bool Recover(int id, int count)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					var productInDB = db.Product.Where(p => p.Id == id).FirstOrDefault();
					if (productInDB.Type == 1)
					{
						//прибавить количество к остаткам в бд
						productInDB.Quantity += count;
						db.SaveChanges();
					}
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return false;
		}
		//восставновление остатков всех товаров чека
		public static void Reconciliation(Receipt receipt)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					foreach (Product p in receipt.Products)
						Recover(p.Id, p.Quantity);//восстановление остатков товара
					if (receipt != null)
					{
						//удаление чека из бд
						db.Receipt.Remove(db.Receipt.Where(r => r.Id == receipt.Id).FirstOrDefault());
						db.SaveChanges();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		//восстановление остатков товаров всех неоплаченных чеков
		public static void ReconciliationAll()
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					var receipts = db.Receipt.Where(r => r.Paid == false);
					foreach (var r in receipts)
					{
						foreach (var p in r.Purchases)
							Recover(p.ProductId, p.Count);//восстановление остатков товара
						db.Receipt.Remove(r);//удаление чека из бд
					}
					db.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
