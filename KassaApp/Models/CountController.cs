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

		public static bool Recover(Product prod)
		{
			try
			{
				using (var db = new KassaDBContext())
				{
					var productInDB = db.Product.Where(p => p.Id == prod.Id).FirstOrDefault();
					if (productInDB.Type == 1)
					{
						productInDB.Quantity += prod.Quantity;
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
						Recover(p);
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
	}
}
