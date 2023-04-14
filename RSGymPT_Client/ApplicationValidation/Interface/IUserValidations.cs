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
    public interface IUserValidations
    {
        #region Methods

        string ValidateUserInputCode(string inputType, string title, string title2, string rule);
        string ValidateUserPassword(string inputType, string title, string title2, string rule);
        User.ProfileType ValidateUserProfile(string inputType, string title, string title2, string rule);
        int ValidateUserID(string inputType, string title, string title2, string rule);
       
        #endregion
    }
}
