using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.InitialDatabase
{
    // Classe que tem o método de criação de dados iniciais na tabela de localizações
    public class InitialLocations
    {
    #region Methods
        public static void InitialLocationsData() 
        {
            LocationRepository.CreateLocation("4440-111", "Valongo");
            LocationRepository.CreateLocation("4350-232", "Porto");
            LocationRepository.CreateLocation("4400-011", "Vila Nova de Gaia");
            LocationRepository.CreateLocation("4500-010", "Espinho");
            LocationRepository.CreateLocation("4450-007", "Matosinhos");
        }
    #endregion
    }

}
