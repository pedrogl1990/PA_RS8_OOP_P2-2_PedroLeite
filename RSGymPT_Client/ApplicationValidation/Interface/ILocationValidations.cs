using D00_Utility;
using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation.Interface
{
    public interface ILocationValidations
    {
        #region Methods
        int ValidateLocationID(string inputType, string title, string title2, string rule);
        string ValidateLocationPostalCode(string inputType, string title, string title2, string rule);
        string ValidateLocationCity(string inputType, string title, string title2, string rule);

        #endregion

    }
}
