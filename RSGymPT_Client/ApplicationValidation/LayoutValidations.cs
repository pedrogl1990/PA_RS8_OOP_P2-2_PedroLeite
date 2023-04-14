using D00_Utility;
using RSGymPT_Client.ApplicationStructure;
using RSGymPT_Client.ApplicationValidation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation
{
    public class LayoutValidations : ILayoutValidations
    {
        // Classe que valida se o user é admin ou colab para ver se pode aceder ao menu user
        #region Methods
        public void UserType(string profile, FunctionsMenus_Construction functionsMenus_Construction, string[] menu, bool backMain)
        {
            if (profile == "admin")
            {
                functionsMenus_Construction.UserFunctions(menu);
            }
            else
            {
                Console.Clear();
                Utility.WriteTitle("RSGymPT - ", "Users Administration");
                Utility.RedText("\nYou don't have access permition. Please contact your administrator.\n");
                Console.WriteLine("\nTaking you to Main Menu");
                Console.ReadLine();
                backMain = true;
            }
        }

        #endregion
    }
}
