using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RSGymPT_DAL.Model.User;
using D00_Utility;

namespace RSGymPT_Client.Repository
{
    static class UserRepository
    {

        // Classe com os métodos do repositório de clientes

        #region Methods
        public static void CreateUser(string name, string code, string password, ProfileType profile)
        {
            User user = new User()
            {
                Name = name,
                Code = code,
                Password = password,
                Profile = profile
            };

            using (var context = new RSGymPTDBContext())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        public static void ReadUser()
        {
            using (var context = new RSGymPTDBContext())
            {
                var queryClient = context.User
                     .Select(u => u)
                     .OrderBy(u => u.Code);

                string header = $"{"ID",-5} | {"Name",-30} | {"Code",-8} | {"Password",-15} | {"Profile",-8}";
                Utility.GreenText2(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var user in queryClient)
                {
                    string line = $"{user.UserID,-5} | {user.Name,-30} | {user.Code,-8} | {user.Password,-15} | {user.Profile,-8}";
                    Console.WriteLine(line);
                }
            }
        }

        public static void UpdateUser(int userID, string password)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result = context.User.FirstOrDefault(u => u.UserID == userID);

                if (result != null)
                {
                    result.Password = password;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Not a valid UserID");
                }
            }
        }
        public static (bool, string, string) VerifyCredentials(string code, string password)
        {
            using (var context = new RSGymPTDBContext())
            {
                bool validUser;
                string userPermition;
                string userName;

                var user = context.User.FirstOrDefault(u => u.Code == code);
                if (user == null)
                {
                    validUser = false;
                    userPermition = string.Empty;
                    userName = string.Empty;
                    return (validUser, userPermition, userName);
                }
                validUser = user.Password == password;
                userPermition = user.Profile.ToString();
                userName = user.Name;
                return (validUser, userPermition, userName);
            }
        }

        public static User VerifyUserID(int userID)
        {
            using (var context = new RSGymPTDBContext())
            {
                return context.User.FirstOrDefault(u => u.UserID == userID);
            }
        }

        public static bool VerifyUserCode(string code)
        {
            using (var context = new RSGymPTDBContext())
            {
                var user = context.User.FirstOrDefault(u => u.Code == code);
                if (user == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion
    }
}