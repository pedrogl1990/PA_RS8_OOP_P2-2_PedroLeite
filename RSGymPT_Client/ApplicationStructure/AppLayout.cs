using System;
using D00_Utility;
using RSGymPT_Client.ApplicationValidation;
using RSGymPT_Client.Repository;

namespace RSGymPT_Client.ApplicationStructure
{
    public class AppLayout
    {
        #region Methods
        Menus menus = new Menus();
        MenusStructure menuStructure = new MenusStructure();
        FunctionsMenus_Construction functionsMenus_Construction = new FunctionsMenus_Construction();
        LayoutValidations layoutValidations = new LayoutValidations();

        // Classe com a estrutura geral da aplicação
        public void MenuLayout()
        {

            bool backMain, backLog;
            Utility.InitialSaudation();
            backLog = true;
            while (backLog)
            {
                Console.Clear();
                int logOption = menuStructure.MenusCreation(menus.LogMenu, "RSGymPT - ", "User Signing In");
                if (logOption == 1)
                {
                    (string, string) result = menuStructure.LogNewUser();
                    (bool validUser, string userPermition, string userName) = UserRepository.VerifyCredentials(result.Item1, result.Item2);
                    while (!validUser)
                    {
                        Utility.RedText("\nInvalid username or password");
                        Console.ReadKey();
                        result = menuStructure.LogNewUser();
                        (validUser, userPermition, userName) = UserRepository.VerifyCredentials(result.Item1, result.Item2);
                    }

                    Utility.GreenText($"\nWelcome {userName}");
                    Console.ReadKey();
                    backMain = true;
                    while (backMain)
                    {
                        Console.Clear();
                        int option = menuStructure.MenusCreation(menus.MainMenu, "RSGymPT - ", "Main Menu");
                        switch (option)
                        {
                            case 1:
                                layoutValidations.UserType(userPermition, functionsMenus_Construction, menus.UsersSubMenu, backMain);
                                break;
                            case 2:
                                functionsMenus_Construction.ClientFunctions(menus.ClientsSubMenu);
                                break;
                            case 3:
                                functionsMenus_Construction.PTFunctions(menus.PTsSubMenu);
                                break;
                            case 4:
                                functionsMenus_Construction.RequestFunctions(menus.RequestsSubMenu);
                                break;
                            case 5:
                                functionsMenus_Construction.LocationFunctions(menus.LocationsSubMenu);
                                break;
                            case 6:
                                var backOptions = functionsMenus_Construction.LogoutFunction();
                                backLog = backOptions.Item1;
                                backMain = backOptions.Item2;
                                break;
                            case 7:
                                functionsMenus_Construction.EndConsoleFunction();
                                break;
                        }
                    }
                }
                else
                {
                    functionsMenus_Construction.EndConsoleFunction();
                }
            }
        }
        #endregion
    }
}

