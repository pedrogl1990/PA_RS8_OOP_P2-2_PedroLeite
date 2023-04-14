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
    public interface IPTValidations
    {
        #region Menthods

        string ValidatePTCode(string inputType, string title, string title2, string rule);
        string ValidatePTPhoneAndNif(string inputType, string title, string title2, string rule);
        string ValidatePTEmail(string inputType, string title, string title2, string rule);
        int ValidatePTID(string inputType, string title, string title2, string rule);

        #endregion
    }
}
