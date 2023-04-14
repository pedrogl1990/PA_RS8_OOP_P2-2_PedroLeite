using D00_Utility;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation.Interface
{
    public interface IClientsValidations
    {
        #region Methods
        string ValidateClientPhone(string inputType, string title, string title2, string rule);
        string ValidateClientNif(string inputType, string title, string title2, string rule);
        string ValidateClientEmail(string inputType, string title, string title2, string rule);
        bool ValidateClientStatus(string inputType, string title, string title2, string rule);
        DateTime ValidateClientBirthDate(string inputType, string title, string title2, string rule);
        int ValidateClientID(string inputType, string title, string title2, string rule);
        Client ValidateSearchClientName(string inputType, string title, string title2, string rule);
       
        #endregion
    }
}
