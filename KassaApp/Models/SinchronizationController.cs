using Dapper;
using KassaApp.Models.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KassaApp.Models
{
    class SinchronizationController
    {
        public static Dictionary<int, int> ChangesList;
        private Timer Timer { get; set; } 
        public SinchronizationController(int period)
        {
            TimerCallback tm = new TimerCallback(SincDB);
            Timer = new Timer(tm, 0, 0, period);

            ChangesList = new Dictionary<int, int>();
        }
        public void SincDB(object obj)
        {
            using (var db = ConnectionFactory.GetMainDbConnection())
            {
                foreach (var id in ChangesList.Keys)
                {
                    db.Execute($"UPDATE Stock SET Quantity = Quantity - {ChangesList[id]} WHERE ProductId = {id} AND PharmacyId = 1");
                }
            }
        }
    }
}
