using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KassaApp.Models
{
    class MarkingCodeParse
    {
        public string SerialNumber { get; set; }
        public string GTIN { get; set; }
        public string VerificationKey { get; set; }
        public string VerificationCode { get; set; }

        public bool Parse(string markingCode)
        {
            string prefix = "";
            if (!string.IsNullOrEmpty(markingCode))
            {
                prefix = markingCode.Substring(0, 2);
                if (prefix == "01")
                    GTIN = markingCode.Substring(2, 14);
                else
                    return false;
                prefix = markingCode.Substring(16, 2);
                if (prefix == "21")
                    SerialNumber = markingCode.Substring(18, 13);
                else
                    return false;
                prefix = markingCode.Substring(31, 2);
                if (prefix == "91")
                    VerificationKey = markingCode.Substring(33, 4);
                else
                    return false;
                prefix = markingCode.Substring(37, 2);
                if (prefix == "92")
                    VerificationCode = markingCode.Substring(39, 44);
                else
                    return false;

                return true;
            }
            else
                return false;
        }
    }
}
