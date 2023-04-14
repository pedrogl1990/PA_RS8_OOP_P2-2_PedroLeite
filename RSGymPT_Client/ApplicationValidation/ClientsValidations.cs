using D00_Utility;
using RSGymPT_Client.ApplicationValidation.Interface;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation
{
    public class ClientsValidations : IClientsValidations
    {

        // Classe que valida os diferentes inputs nos Clientes
        #region Methods
        public string ValidateClientPhone(string inputType, string title, string title2, string rule)
        {
            string input;
            bool existingPhone;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                input = Console.ReadLine();
                existingPhone = ClientRepository.CheckClientEmailPhone(inputType, input);
                if (Regex.IsMatch(input, @"^[0-9]{9}$") && existingPhone == false)
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

        public string ValidateClientNif(string inputType, string title, string title2, string rule)
        {
            string nif;
            bool existingNif;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                nif = Console.ReadLine();
                existingNif = ClientRepository.CheckClientNif(nif);
                if (Regex.IsMatch(nif, @"^[0-9]{9}$") && existingNif == false)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return nif;
        }

        public string ValidateClientEmail(string inputType, string title, string title2, string rule)
        {

            string email;
            bool existingEmail;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                email = Console.ReadLine().ToLower();
                existingEmail = ClientRepository.CheckClientEmailPhone(inputType, email);
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

        public bool ValidateClientStatus(string inputType, string title, string title2, string rule)
        {
            bool isActive;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                bool valid = bool.TryParse(Console.ReadLine(), out isActive);
                if (valid)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return isActive;
        }

        public DateTime ValidateClientBirthDate(string inputType, string title, string title2, string rule)
        {
            DateTime birthDate;
            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                bool valid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthDate);
                if (valid && birthDate.Year >= 1900 && birthDate.Year <= DateTime.Now.Year - 18)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return birthDate;
        }

        public int ValidateClientID(string inputType, string title, string title2, string rule)
        {
            int clientID;
            Client existingClientID;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Search ClientID ({rule}): ");
                bool valid = int.TryParse(Console.ReadLine(), out clientID);
                existingClientID = ClientRepository.VerifyClientID(clientID);
                if (valid && existingClientID != null)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return clientID;
        }

        public Client ValidateSearchClientName(string inputType, string title, string title2, string rule)
        {
            string clientToSearch;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Search Client Name ({rule}): ");
                clientToSearch = Console.ReadLine();
                var result = ClientRepository.CheckClientName(clientToSearch);
                if (true && result != null)
                {
                    Console.Clear();
                    return result;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
        }

        #endregion
    }
}
