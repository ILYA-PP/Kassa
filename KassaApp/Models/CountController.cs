﻿using System;
using System.Linq;
			{
				db = new KassaDBContext();
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
			{
				MessageBox.Show(ex.Message);
			}
		{
			try
			{
				db = new KassaDBContext();
				var productInDB = db.Product.Where(p => p.Name == prod.Name).FirstOrDefault();
				if (productInDB.Type == 1)
				{
					productInDB.Quantity += prod.Quantity;
					db.SaveChanges();
				}
				return true;
			}
			{
				MessageBox.Show(ex.Message);
			}
			return false;
		}