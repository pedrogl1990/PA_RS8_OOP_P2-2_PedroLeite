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
    public class LocationValidations : ILocationValidations
    {
        // Classe que valida os diferentes inputs nas Locations

        #region Methods
        public int ValidateLocationID(string inputType, string title, string title2, string rule)
        {
            int locationID;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                bool valid = int.TryParse(Console.ReadLine(), out locationID);
                var result = LocationRepository.CheckLocationID(locationID);
                if (valid && result != null)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return locationID;
        }

        public string ValidateLocationPostalCode(string inputType, string title, string title2, string rule)
        {
            string postalCode;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Postal Code ({rule}): ");
                postalCode = Console.ReadLine();
                if (Regex.IsMatch(postalCode, @"^\d{4}-\d{3}$"))
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return postalCode;
        }

        public string ValidateLocationCity(string inputType, string title, string title2, string rule)
        {
            string city;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"{inputType} ({rule}): ");
                city = Console.ReadLine();
                if (Regex.IsMatch(city, @"^[a-zA-ZÀ-ú\s]+$") && city.Length <= 100)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return city;
        }

        #endregion
    }
}
