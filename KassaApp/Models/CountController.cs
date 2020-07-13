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
		public static void Reconciliation(int Receipt_Id)
		{
			try
			{
				var db = new KassaDBContext();
				IQueryable<Purchase> purchases;
				if (Receipt_Id != 0)
					purchases = db.Purchase.Where(p => p.Paid == false && p.ReceiptId == Receipt_Id);
				else
					purchases = db.Purchase.Where(p => p.Paid == false && p.ReceiptId == Receipt_Id);
				foreach (Purchase p in purchases)
				{
					var prod = db.Product.Where(pr => pr.Id == p.ProductId).FirstOrDefault();
					prod.Quantity = p.Count;
					if (prod != null)
						Recover(prod);
				}
				if(Receipt_Id != 0)
					db.Receipt.Remove(db.Receipt.Where(r => r.Id == Receipt_Id).FirstOrDefault());
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
