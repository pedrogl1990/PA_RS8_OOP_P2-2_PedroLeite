using D00_Utility;
using RSGymPT_Client.ApplicationInputs;
using RSGymPT_Client.ApplicationStructure.Interface;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationStructure
{

    // Classe criadora da estrutura dos menus de funcionalidades
    public class MenusStructure : IMenusStructure
    {
    #region Methods
        ReadInputs readInputs = new ReadInputs();
        Menus menus = new Menus();
        public int MenusCreation(string[] menu, string title, string title2)
        {
            int option;
            Utility.ListMenu(menu, title, title2);
            bool valid = int.TryParse(readInputs.ReadOption(), out option);
            while (!valid || option < 1 || option > menu.Length)
            {
                Utility.RedText("\nPlease insert a valid option");
                Console.ReadKey();
                Console.Clear();
                Utility.ListMenu(menu, title, title2);
                valid = int.TryParse(readInputs.ReadOption(), out option);
            }
            return option;
        }

        public (string, string) LogNewUser()
        {
            Console.Clear();
            var result = readInputs.ReadUserCredentials("RSGymPT - ", "Login");
            string code = result.Item1;
            string password = result.Item2;
            return (code, password);
        }

        public void CreateNewUser()
        {
            Console.Clear();
            readInputs.inputToCreateUser();
            Utility.SuccesMessage("RSGymPT - ", "Create User", "User Created Successfully!", "Taking you to Users Administration Menu");
        }

        public void CreateNewClient()
        {
            Console.Clear();
            readInputs.inputToCreateClient();
            Utility.SuccesMessage("RSGymPT - ", "Create Client", "Client Created Successfully!", "Taking you to Clients Administration Menu");
        }

        public bool UpdateExistingUser()
        {
            Console.Clear();
            int option = MenusCreation(menus.UserUpdateSubMenu, "RSGymPT - ", "Update User");
            switch (option)
            {
                case 1:
                    readInputs.inputToUpdateUser();
                    Utility.SuccesMessage("RSGymPT - ", "Update User", "User Updated Successfully!", "Taking you to Users Administration Menu");
                    return true;
                case 2:
                    Console.WriteLine("\nTaking you to Users Administration Menu");
                    Console.ReadKey();
                    return true;
            }
            return false;
        }

        public void ReadExistingUser()
        {
            Console.Clear();
            Utility.WriteTitle("RSGymPT - ", "List Users");
            UserRepository.ReadUser();
            Utility.ReadMessage("Taking you to Users Administration Menu");
        }

        public void UpdateExistingClient()
        {
            Console.Clear();
            int option = MenusCreation(menus.clientUpdateSubMenu, "RSGymPT - ", "Update Client");
            readInputs.InputToUpdateClient(option);
            if (option != 7)
            {
                Console.ReadKey();
                Console.WriteLine("\nTaking you to Clients Administration Menu");
                Console.ReadKey();
            }
        }

        public void ReadExistingClient()
        {
            Console.Clear();
            Utility.WriteTitle("RSGymPT - ", "List Clients");
            ClientRepository.ReadClient();
            Utility.ReadMessage("Taking you to Clients Administration Menu");
        }

        public void UpdateClientStatus()
        {
            Console.Clear();
            readInputs.InputActivateClient();
            Console.Clear();
            Utility.SuccesMessage("RSGymPT - ", "Update Client Status", "Client Status Updated Successfully!", "Taking you to Clients Administration Menu");
        }

        public void CreateNewPT()
        {
            Console.Clear();
            readInputs.InputToCreatePT();
            Utility.SuccesMessage("RSGymPT - ", "Create PT", "PT Created Successfully!", "Taking you to PT's Administration Menu");
        }

        public void ReadExistingPT()
        {
            Console.Clear();
            Utility.WriteTitle("RSGymPT - ", "List PT's");
            PersonalTrainerRepository.ReadPT();
            Utility.ReadMessage("Taking you to PT's Administration Menu");
        }

        public void CreateNewRequest()
        {
            Console.Clear();
            readInputs.InputToCreateRequest();
            Utility.SuccesMessage("RSGymPT - ", "Create Request", "Request Created Successfully!", "Taking you to Request Menu");
        }

        public void ReadExistingRequest()
        {
            Console.Clear();
            Utility.WriteTitle("RSGymPT - ", "List Requests");
            RequestRepository.ReadRequest();
            Utility.ReadMessage("Taking you to Main Menu");
        }

        public void CreateNewLocation()
        {
            Console.Clear();
            readInputs.inputToCreateLocation();
            Utility.SuccesMessage("RSGymPT - ", "Create Location", "Location Created Successfully", "Taking you to Locations Administration Menu");
        }

        public void ReadExistingLocation()
        {
            Console.Clear();
            Utility.WriteTitle("RSGymPT - ", "List Locations");
            LocationRepository.ReadLocation();
            Utility.ReadMessage("Taking you to Locations Administration Menu");
        }
    #endregion
    }

}