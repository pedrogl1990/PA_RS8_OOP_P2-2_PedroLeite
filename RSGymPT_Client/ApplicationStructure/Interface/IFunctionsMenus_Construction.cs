using D00_Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationStructure.Interface
{
    #region Methods
    public interface IFunctionsMenus_Construction
    {
        void UserFunctions(string[] menu);
        void ClientFunctions(string[] menu);
        void PTFunctions(string[] menu);
        void RequestFunctions(string[] menu);
        void LocationFunctions(string[] menu);
        (bool,bool) LogoutFunction();
        void EndConsoleFunction();

        #endregion
    }
}
