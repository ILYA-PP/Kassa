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
				var db = new KassaDBContext();
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
				var db = new KassaDBContext();
				var productInDB = db.Product.Where(p => p.Name == prod.Name).FirstOrDefault();
				if (productInDB.Type == 1)
				{
					productInDB.Quantity += prod.Quantity;
					db.SaveChanges();
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return false;
		}
		public static void Reconciliation()
		{
			try
			{
				var db = new KassaDBContext();
				var purchases = db.Purchase.Where(p => p.Paid == false);
				foreach (Purchase p in purchases)
				{
					var prod = db.Product.Where(pr => pr.Id == p.ProductId).FirstOrDefault();
					if (prod != null)
						Recover(prod);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
