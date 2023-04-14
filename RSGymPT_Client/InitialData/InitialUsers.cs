using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.InitialDatabase
{
    public class InitialUsers
    {
        // Classe que tem o método de criação de dados na tabela de users
        #region Methods
        public static void InitialUsersData()
        {
            UserRepository.CreateUser("Carlos Parreira Filho", "CFADMN", "admin123", User.ProfileType.admin);
            UserRepository.CreateUser("Rita Ribeiro Alves", "RACLAB", "colab123", User.ProfileType.colab);
            UserRepository.CreateUser("Fábio Pereira Soares", "FPCLAB", "colab456", User.ProfileType.colab);
        }

        #endregion
    }
}
