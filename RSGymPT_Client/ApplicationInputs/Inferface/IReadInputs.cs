using D00_Utility;
using RSGymPT_Client.ApplicationValidation;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationInputs.Inferface
{
    public interface IReadInputs
    {
        #region Methods
        string ReadOption();

        (string, string) ReadUserCredentials(string title, string title2);

        void inputToCreateUser();

        void inputToUpdateUser();

        void inputToCreateClient();

        bool InputToUpdateClient(int option);
       
        void InputActivateClient();

        void InputToCreatePT();

        void InputToCreateRequest();

        void inputToCreateLocation();

        #endregion
    }
}
