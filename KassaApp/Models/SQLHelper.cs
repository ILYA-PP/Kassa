using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace KassaApp.Models
{
    class SQLHelper
    {
        public static string Select<T>(string condition = null)
        {
            string query;

            if (string.IsNullOrEmpty(condition))
                query = $"SELECT * FROM {typeof(T).Name}";
            else
                query = $"SELECT * FROM {typeof(T).Name} {condition}";

            return query;
        }

        public static string Delete(object obj)
        {
            var T = obj.GetType();
            var id = T.GetProperties().Where(p => p.CustomAttributes.Where(ca => ca.AttributeType == typeof(NotMappedAttribute)).Count() == 0).Where(p => p.Name == "Id").FirstOrDefault().GetValue(obj);

            string query;

            query = $"DELETE FROM {T.Name} WHERE Id = {id}";

            return query;
        }

        public static string Insert(object obj)
        {
            var T = obj.GetType();
            var types = new Type[] { typeof(int), typeof(double), typeof(decimal) };
            List<string> values = new List<string>();
            var properties = T.GetProperties().Where(p => p.CustomAttributes.Where(ca => ca.AttributeType == typeof(NotMappedAttribute)).Count() == 0).ToList();
            properties.Remove(properties.Where(p => p.Name == "Id").FirstOrDefault());

            foreach (var p in properties)
            {
                var value = obj.GetType().GetProperty(p.Name).GetValue(obj);

                if(types.Contains(p.PropertyType))
                {
                    values.Add($"{value.ToString().Replace(",",".")}");
                }
                else
                {
                    if (p.PropertyType == typeof(DateTime?) || p.PropertyType == typeof(DateTime))
                    {
                        values.Add($"'{(DateTime)value:yyyy-MM-dd HH:mm:ss}'");
                        continue;
                    }

                    values.Add($"'{value}'");
                }
            }

            string query = $"INSERT INTO {T.Name} ({string.Join(",", properties.Select(p => p.Name))}) VALUES ({string.Join(",", values)});";

            return query;
        }

        public static string Update(object obj)
        {
            var T = obj.GetType();
            var types = new Type[] { typeof(int), typeof(double), typeof(decimal) };
            List<string> values = new List<string>();
            var properties = T.GetProperties().Where(p => p.CustomAttributes.Where(ca => ca.AttributeType == typeof(NotMappedAttribute)).Count() == 0).ToList();
            var id = properties.Where(p => p.Name == "Id").FirstOrDefault().GetValue(obj);
            properties.Remove(properties.Where(p => p.Name == "Id").FirstOrDefault());

            foreach (var p in properties)
            {
                var value = obj.GetType().GetProperty(p.Name).GetValue(obj);

                if (types.Contains(p.PropertyType))
                {
                    values.Add($"{p.Name} = {value.ToString().Replace(",",".")}");
                }
                else
                {
                    if (p.PropertyType == typeof(DateTime?) || p.PropertyType == typeof(DateTime))
                    {
                        values.Add($"{p.Name} = '{(DateTime)value:yyyy-MM-dd HH:mm:ss}'");
                        continue;
                    }

                    values.Add($"{p.Name} = '{value}'");
                }
            }

            string query = $"UPDATE {T.Name} SET {string.Join(",", values)} WHERE Id = {id}";

            return query;
        }
    }
}
