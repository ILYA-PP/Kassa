using System;

namespace KassaApp.Models
{
    class PrefixCreator
    {
        public static string GetPrefix(string prefixName, object data, object addData = null)
        {
            string prefix = "";

            switch (prefixName)
            {
                case "dn": prefix = $"{data}"; break;
                case "dd": prefix = $"{((DateTime)data):yyMMdd)}"; break;
                case "ps": prefix = $"{data}"; break;
                case "sid": prefix = $"{data}"; break;
                case "sp": 
                    if(addData != null && decimal.Parse(data.ToString()) < decimal.Parse(addData.ToString()))
                        prefix = $"{data}/{addData}"; 
                    else
                        prefix = $"";
                    break;
                case "ss": prefix = $"{Math.Round(decimal.Parse(data.ToString()))}00"; break;
            }
            
            return prefix;
        }
    }
}
