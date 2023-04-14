using D00_Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation.Interface
{
    public interface IRequestsValidations
    {
        #region Methods
        string ValidateRequestStatus(string inputType, string title, string title2, string rule);
        DateTime ValidateRequestSchedule(string inputType, string title, string title2, string rule);

        #endregion
    }
}
