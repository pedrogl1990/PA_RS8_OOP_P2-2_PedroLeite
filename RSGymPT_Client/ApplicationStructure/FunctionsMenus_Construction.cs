using D00_Utility;
using RSGymPT_Client.ApplicationStructure.Interface;
using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationStructure
{
    public class FunctionsMenus_Construction : IFunctionsMenus_Construction
    {
        MenusStructure menusStructure = new MenusStructure();

        // Classe que constroi os diferentes menus de funcionalidades
        #region Methods
        public void UserFunctions(string[] menu)
        {
            int option;
            bool backUser;

            Console.Clear();
            backUser = true;
            while (backUser)
            {
                Console.Clear();
                option = menusStructure.MenusCreation(menu, "RSGymPT - ", "Users Administration");

                switch (option)
                {
                    case 1:
                        menusStructure.CreateNewUser();
                        backUser = true;
                        break;
                    case 2:
                        menusStructure.ReadExistingUser();
                        backUser = true;
                        break;
                    case 3:
                        backUser = menusStructure.UpdateExistingUser();
                        break;
                    case 4:
                        backUser = false;
                        Console.WriteLine("\nTaking you to Main Menu");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void ClientFunctions(string[] menu)
        {
            int option;
            bool backClient;

            Console.Clear();
            backClient = true;
            while (backClient)
            {
                Console.Clear();
                option = menusStructure.MenusCreation(menu, "RSGymPT - ", "Clients Administration");

                switch (option)
                {
                    case 1:
                        menusStructure.CreateNewClient();
                        backClient = true;
                        break;
                    case 2:
                        menusStructure.ReadExistingClient();
                        backClient = true;
                        break;
                    case 3:
                        menusStructure.UpdateExistingClient();
                        backClient = true;
                        break;
                    case 4:
                        menusStructure.UpdateClientStatus();
                        backClient = true;
                        break;
                    case 5:
                        backClient = false;
                        Console.WriteLine("\nTaking you to Main Menu");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void PTFunctions(string[] menu)
        {
            int option;
            bool backPT;

            Console.Clear();
            backPT = true;
            while (backPT)
            {
                Console.Clear();
                option = menusStructure.MenusCreation(menu, "RSGymPT - ", "PT's Administration");
                switch (option)
                {
                    case 1:
                        menusStructure.CreateNewPT();
                        backPT = true;
                        break;
                    case 2:
                        menusStructure.ReadExistingPT();
                        backPT = true;
                        break;
                    case 3:
                        backPT = false;
                        Console.WriteLine("\nTaking you to Main Menu");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void RequestFunctions(string[] menu)
        {
            int option;
            bool backRequest;

            Console.Clear();
            backRequest = true;
            while (backRequest)
            {
                Console.Clear();
                option = menusStructure.MenusCreation(menu, "RSGymPT - ", "Requests Administration");
                switch (option)
                {
                    case 1:
                        menusStructure.CreateNewRequest();
                        backRequest = true;
                        break;
                    case 2:
                        menusStructure.ReadExistingRequest();
                        backRequest = true;
                        break;
                    case 3:
                        backRequest = false;
                        Console.WriteLine("\nTaking you to Main Menu");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void LocationFunctions(string[] menu)
        {
            int option;
            bool backLocations;

            Console.Clear();
            backLocations = true;
            while (backLocations)
            {
                Console.Clear();
                option = menusStructure.MenusCreation(menu, "RSGymPT - ", "Locations Administration");
                switch (option)
                {
                    case 1:
                        menusStructure.CreateNewLocation();
                        backLocations = true;
                        break;
                    case 2:
                        menusStructure.ReadExistingLocation();
                        backLocations = true;
                        break;
                    case 3:
                        backLocations = false;
                        Console.WriteLine("\nTaking you to Main Menu");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public (bool,bool) LogoutFunction()
        {
            Utility.GoodbyeModule();
            return (true,false);
        }

        public void EndConsoleFunction()
        {
            Utility.GoodbyeModule();
            Utility.TerminateConsole();
        }
        #endregion
    }
}
