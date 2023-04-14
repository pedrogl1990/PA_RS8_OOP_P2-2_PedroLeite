using RSGymPT_Client.InitialDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.InitialData
{
    public class InitialAppData
    {
        // Classe que tem cada um dos métodos de criação de dados inicias nas diferentes tabelas
        #region Methods
        public static void CreateInitialData()
        {
            InitialUsers.InitialUsersData();
            InitialLocations.InitialLocationsData();
            InitialPersonalTrainers.InitialPTData();
            InitialClients.InitialClienstData();
            InitialRequests.InitialRequestsData();
        }

        #endregion
    }
}
