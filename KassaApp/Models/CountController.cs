using System;
using System.Linq;using System.Windows.Forms;namespace KassaApp.Models{	class CountController	{		private static KassaDBContext db;		public static bool Check(Product prod)		{			try
			{
				db = new KassaDBContext();
				var productInDB = db.Product.Where(p => p.Name == prod.Name).FirstOrDefault();
				if (prod.Quantity <= productInDB.Quantity)
				{
					productInDB.Quantity -= prod.Quantity;
					db.SaveChanges();
					return true;
				}
				else
				{
					MessageBox.Show("Недостаточно товара в наличии!" +
									$"\nТовар: {productInDB.Name}" +
									$"\nОстаток: {productInDB.Quantity}");
				}
			}			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}			return false;		}		public static bool Recover(Product prod)
		{
			try
			{
				db = new KassaDBContext();
				var productInDB = db.Product.Where(p => p.Name == prod.Name).FirstOrDefault();
				productInDB.Quantity += prod.Quantity;
				db.SaveChanges();
				return true;
			}			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return false;
			}
		}	}}