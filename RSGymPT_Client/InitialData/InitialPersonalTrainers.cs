using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.InitialDatabase
{

    public class InitialPersonalTrainers
    {
        // Classe que tem o método de criação de dados iniciais na tabela de PT's
        #region Methods
        public static void InitialPTData()
        {
            PersonalTrainerRepository.CreatePT(1, "Albano Carreira Fortes", "123456789", "AFPT", "912345678", "im_fortes@rsgym.pt");
            PersonalTrainerRepository.CreatePT(2, "Carolina Faria Lopes", "987654321", "CLPT", "919364823", "carol_fit@rsgym.pt");
        }
    #endregion
    }

}
