using RSGymPT_Client.ApplicationStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation.Interface
{
    public interface ILayoutValidations
    {
        #region Methods

        void UserType(string profile, FunctionsMenus_Construction functionsMenus_Construction, string[] menu, bool backMain);

        #endregion
    }
}
