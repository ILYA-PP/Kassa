using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaApp.Models.Marking
{
    class TagCreator
    {
        public static string GetTag(int tagName, PrefixData data, string docType = null)
        {
            string tag = "";

            switch (tagName)
            {
                case 1191:
                    if (!string.IsNullOrEmpty(data.sp) || !string.IsNullOrEmpty(data.ss))
                        tag = $"mdlp{data.sp}&{data.ss}&";
                    else
                        tag = "mdlp";
                    break;
                case 1084: tag = "mdlp"; break;
                case 1085:
                    if (string.IsNullOrEmpty(docType))
                        tag = "mdlp";
                    else
                        tag = $"mdlp{docType}";
                    break;
                case 1086:
                    if (!string.IsNullOrEmpty(data.ps) && !string.IsNullOrEmpty(data.dn))
                        tag = $"ps{data.ps.Replace("&", "&&")}&dn{data.dn.Replace("&", "&&")}&dd{data.dd}&sid{data.sid}&";
                    else
                        tag = $"sid{data.sid}&";
                    break;
            }

            return tag;
        }
    }
}
