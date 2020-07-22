using System;
using System.Linq;
using System.Windows.Forms;

namespace KassaApp.Models
{
	class CountController
	{
		public static bool Check(Product prod)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					var productInDB = db.Product.Where(p => p.Name == prod.Name).FirstOrDefault();
					if (prod.Quantity <= productInDB.Quantity)
					{
						if (productInDB.Type == 1)
						{
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

		public static bool Recover(int id, int count)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					var productInDB = db.Product.Where(p => p.Id == id).FirstOrDefault();
					if (productInDB.Type == 1)
					{
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
		public static void Reconciliation(Receipt receipt)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					foreach (Product p in receipt.Products)
						Recover(p.Id, p.Quantity);
					if (receipt != null)
					{
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
							Recover(p.ProductId, p.Count);
						db.Receipt.Remove(r);
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
