using D00_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation.Interface
{
    public interface IGeneralValidations
    {
        #region Methods
        string ValidateName(string inputType, string title, string title2, string rule, int length);
        
        #endregion
    }
}
