using RSGymPT_Client.ApplicationStructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationStructure
{
    #region Properties

    // Classe que contém todos os menus
    public class Menus : IMenus
    {
        public string[] LogMenu { get; set; }
        public string[] ValidationMenu { get; set; }
        public string[] MainMenu { get; set; }
        public string[] UsersSubMenu { get; set; }
        public string[] ClientsSubMenu { get; set; }
        public string[] PTsSubMenu { get; set; }
        public string[] RequestsSubMenu { get; set; }
        public string[] LocationsSubMenu { get; set; }
        public string[] UserUpdateSubMenu { get; set; }
        public string[] clientUpdateSubMenu { get; set; }
        #endregion

        #region Constructor
        public Menus()
        {
            LogMenu = new string[] { "Login", "Close App" };
            ValidationMenu = new string[] { "Code", "Password", "Close App" };
            MainMenu = new string[] { "Users Admin.", "Clients Admin.", "Personal Trainers Admin.", "Requests Admin.", "Locations Admin.", "Logout", "Close App" };
            UsersSubMenu = new string[] { "Create User", "List User", "Update User", "Main Menu" };
            ClientsSubMenu = new string[] { "Create Client", "List Client", "Update Client", "Update Client Status", "Main Menu" };
            PTsSubMenu = new string[] { "Create PT", "List PT", "Main Menu" };
            RequestsSubMenu = new string[] { "Create Request", "List Request", "Main Menu" };
            LocationsSubMenu = new string[] { "Create Location", "List Location", "Main Menu" };
            UserUpdateSubMenu = new string[] { "Password", "User Admin. Menu" };
            clientUpdateSubMenu = new string[] { "Name", "BirthDate", "LocationID", "Phone", "Email", "Observations", "Client Admin. Menu" };
        }

        #endregion

    }
}
