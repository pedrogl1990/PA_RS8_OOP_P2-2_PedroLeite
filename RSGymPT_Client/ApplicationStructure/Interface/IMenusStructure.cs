using D00_Utility;
using RSGymPT_Client.ApplicationInputs;
using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationStructure.Interface
{
    public interface IMenusStructure
    {
        #region Methods

        int MenusCreation(string[] menu, string title, string title2);
        (string, string) LogNewUser();
        void CreateNewUser();
        void CreateNewClient();
        bool UpdateExistingUser();
        void ReadExistingUser();
        void UpdateExistingClient();
        void ReadExistingClient();
        void UpdateClientStatus();
        void CreateNewPT();
        void ReadExistingPT();
        void CreateNewRequest();
        void ReadExistingRequest();
        void CreateNewLocation();
        void ReadExistingLocation();

        #endregion
    }
}
