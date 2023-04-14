using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.InitialDatabase
{
    public class InitialClients
    {
        // Classe que tem o método de criação de dados iniciais na tabela de clientes
        #region Methods
        public static void InitialClienstData()
        {
            ClientRepository.CreateClient(3, "Albertino Fagundes Sousa", "736153274", new DateTime(1963, 3, 31), "939192941", "alb.fagundes@gmail.com", "", true);
            ClientRepository.CreateClient(4, "Joana Fonseca Costa", "635128321", new DateTime(1987, 12, 10), "924688583", "joaninha.costa@gmail.com", "With PT plan", true);
            ClientRepository.CreateClient(5, "Tiago Silva Trigo", "902746193", new DateTime(1990, 7, 5), "914694823", "tiago_trigo@gmail.com", "Last appearance was 3 months ago", false);
        }
    #endregion
    }

}
