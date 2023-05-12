using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class FormatValidation
    {
        public void Validate(string test)
        {
            if (test == null || test == "")
                return;
            Regex regex = new("^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            if (regex.IsMatch(test) == false)
            {
                throw new FormatException("Ivalid Format: DateTime");
            }
        }

        
    }
}
