using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using RSGymPT_DAL.Model;

namespace RSGymPT_Client.Repository
{
    public class RequestRepository
    {
        // Classe com os métodos do repositório de ~Requests

        #region Methods
        public static void CreateRequest(int clientID, int PersonalTrainerID, DateTime Schedule, string status, string observations)
        {
            Request request = new Request()
            {
                ClientID = clientID,
                PersonalTrainerID = PersonalTrainerID,
                Schedule = Schedule,
                Status = status,
                Observations = observations
            };

            using (var context = new RSGymPTDBContext())
            {
                context.Request.Add(request);
                context.SaveChanges();
            }
        }

        public static void ReadRequest()
        {
            using (var context = new RSGymPTDBContext())
            {
                var queryRequest = context.Request
                     .Select(r => r)
                     .OrderBy(r => r.Status)
                     .ThenBy(r => r.Schedule);

                string header = $"{"ResquestID",-10} | {"ClientID",-10} | {"PTID",-10} | {"Schedule",-25} | {"Status",-10} | {"Observations",-30}";
                Utility.GreenText2(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var r in queryRequest)
                {
                    string line = $"{r.RequestID,-10} | {r.ClientID,-10} | {r.PersonalTrainerID,-10} | {r.Schedule,-25} | {r.Status,-10} | {r.Observations, -30}";
                    Console.WriteLine(line);
                }
            }
        }

        public static bool VerifyRequestSchedule(DateTime schedule)
        {
            using (var context = new RSGymPTDBContext())
            {
                var user = context.Request.FirstOrDefault(r => r.Schedule == schedule);
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
