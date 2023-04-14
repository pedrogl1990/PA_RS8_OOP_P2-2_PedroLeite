using D00_Utility;
using RSGymPT_Client.ApplicationValidation.Interface;
using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation
{
    public class PTValidations : IPTValidations
    {
        // Classe que valida os diferentes inputs nos PT's

        #region Methods

        public string ValidatePTCode(string inputType, string title,  string title2, string rule)
        {
            string code;
            bool existingPTCode;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                code = Console.ReadLine().ToUpper();
                existingPTCode = PersonalTrainerRepository.CheckPTCode(code);
                if (Regex.IsMatch(code, @"^.{4}$") && existingPTCode == false && !code.Contains(" "))
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

        public string ValidatePTPhoneAndNif(string inputType, string title, string title2, string rule)
        {
            string input;
            bool existingInput;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                input = Console.ReadLine();
                existingInput = PersonalTrainerRepository.CheckPTPhoneOrNif(input, inputType);
                if (Regex.IsMatch(input, @"^[0-9]{9}$"))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return input;
        }

        public string ValidatePTEmail(string inputType, string title,  string title2, string rule)
        {

            string email;
            bool existingEmail;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                email = Console.ReadLine().ToLower();
                existingEmail = PersonalTrainerRepository.CheckPTEmail(email);
                if (Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$") && email.Length <= 100 && existingEmail == false)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }

            return email;
        }

        public int ValidatePTID(string inputType, string title,  string title2, string rule)
        {
            int pTID;
            bool existingPTID;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"PTID ({rule}): ");
                bool valid = int.TryParse(Console.ReadLine(), out pTID);
                existingPTID = PersonalTrainerRepository.CheckPTID(pTID);
                if (valid && existingPTID == true)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return pTID;
        }

        #endregion
    }
}
