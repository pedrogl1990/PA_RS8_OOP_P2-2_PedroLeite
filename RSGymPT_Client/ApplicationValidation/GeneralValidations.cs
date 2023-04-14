using D00_Utility;
using RSGymPT_Client.ApplicationInputs;
using RSGymPT_Client.ApplicationValidation.Interface;
using RSGymPT_DAL.Model;
using System;
using System.Globalization;
using System.Text.RegularExpressions;


namespace RSGymPT_Client.Repository
{
    public class GeneralValidations : IGeneralValidations
    {
        // Classe que valida os diferentes inputs comuns a mais que uma classe
        #region Methods
        public string ValidateName(string inputType, string title, string title2, string rule, int length)
        {
            string input;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                input = Console.ReadLine();
                if(Regex.IsMatch(input, @"^[a-zA-ZÀ-ú\s]+$") && input.Length <= length)
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

        public string ValidateObservations(string inputType, string title, string title2, string rule, int length)
        {
            string input;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                input = Console.ReadLine();
                if (input.Length <= length)
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

        #endregion
    }
}

