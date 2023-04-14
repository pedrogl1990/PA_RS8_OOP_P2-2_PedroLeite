using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.InitialDatabase
{
    public class InitialRequests
    {
        // Classe que tem o método de criação de dados na tabela de requests
        #region Methods
        public static void InitialRequestsData()
        {
            RequestRepository.CreateRequest(1, 1, new DateTime(2023, 5, 20, 12, 00, 0), "ended", "");
            RequestRepository.CreateRequest(2, 1, new DateTime(2023, 5, 5, 14, 00, 0), "scheduled", "");
            RequestRepository.CreateRequest(3, 2, new DateTime(2023, 4, 29, 13, 30, 0), "cancelled", "Never came to a scheduled session");
        }

        #endregion
    }
}
