using D00_Utility;
using RSGymPT_Client.ApplicationValidation.Interface;
using RSGymPT_Client.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSGymPT_Client.ApplicationValidation
{
    public class RequestsValidations : IRequestsValidations
    {
        // Classe que valida os diferentes inputs nos Requests
        #region Methods
        public string ValidateRequestStatus(string inputType, string title, string title2, string rule)
        {
            string status;

            while (true)
            {
                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Status ({rule}): ");
                status = Console.ReadLine();
                if (status == "scheduled" || status == "ended" || status == "cancelled")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return status;
        }

        public DateTime ValidateRequestSchedule(string inputType, string title,  string title2, string rule)
        {
            DateTime schedule;
            bool existingSchedule;

            while (true)
            {

                Utility.WriteTitle(title, title2);
                Console.WriteLine("\nPlease insert:\n");
                Console.Write($"Insert {inputType} ({rule}): ");
                bool valid = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out schedule);
                existingSchedule = RequestRepository.VerifyRequestSchedule(schedule);
                if (valid && existingSchedule == false && schedule > DateTime.Now)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Utility.ValidationError(inputType, rule, title, title2);
                }
            }
            return schedule;
        }

        #endregion
    }
}
