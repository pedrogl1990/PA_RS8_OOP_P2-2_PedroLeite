using D00_Utility;
using RSGymPT_Client.ApplicationValidation.Interface;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation
{
    public class UserValidations : IUserValidations
    {
        // Classe que valida os diferentes inputs nos Users
        #region Methods
        public string ValidateUserInputCode(string inputType, string title, string title2, string rule)
        {
            string code;
            bool existingCode;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Code ({rule}): ");
                code = Console.ReadLine().ToUpper();
                existingCode = UserRepository.VerifyUserCode(code);
                if (code.Length >= 4 && code.Length <= 6 && existingCode == false && !code.Contains(" "))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return code;
        }

        public string ValidateUserPassword(string inputType, string title, string title2, string rule)
        {
            string password;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                password = Console.ReadLine();
                if (password.Length >= 8 && password.Length <= 12 && !password.Contains(" "))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return password;
        }

        public User.ProfileType ValidateUserProfile(string inputType, string title, string title2, string rule)
        {
            string inputProfile;
            User.ProfileType profile;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Profile ({rule}): ");
                inputProfile = Console.ReadLine().ToLower();
                bool invalid = !Enum.TryParse(inputProfile, true, out profile);
                if (!invalid)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return profile;
        }

        public int ValidateUserID(string inputType, string title,  string title2, string rule)
        {

            int userID;
            User user;

            while (true)
            {
                Console.Clear();
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Search UserID ({rule}): ");
                bool valid = int.TryParse(Console.ReadLine(), out userID);
                user = UserRepository.VerifyUserID(userID);
                if (valid && user != null)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return userID;
        }

        #endregion
    }
}
