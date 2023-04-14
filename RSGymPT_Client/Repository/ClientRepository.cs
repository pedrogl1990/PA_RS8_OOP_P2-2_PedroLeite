using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Runtime.Remoting.Contexts;

namespace RSGymPT_Client.Repository
{
    public class ClientRepository
    {
        // Classe com os métodos do repositório de clientes

        #region Methods
        public static void CreateClient(int locationID, string name, string nif, DateTime birthDate, string phone, string email, string observations, bool isActive)
        {

            Client client = new Client()
            {
                LocationID = locationID,
                Name = name,
                Nif = nif,
                BirthDate = birthDate,
                Phone = phone,
                Email = email,
                Observations = observations,
                IsActive = isActive
            };

            using (var context = new RSGymPTDBContext())
            {
                context.Client.Add(client);
                context.SaveChanges();
            }

        }

        public static void ReadClient()
        {
            using (var context = new RSGymPTDBContext())
            {
                var queryClient = context.Client
                    .Select(c => c)
                    .OrderByDescending(c => c.IsActive)
                    .ThenBy(c => c.Name);


                string header = String.Format("{0,-10} | {1,-30} | {2,-9} | {3,-11} | {4,-10} | {5,-9} | {6,-30} | {7,-10} | {8, -30}",
                    "ClientID", "Name", "Nif", "Birth Date", "Location", "Phone", "Email", "Active", "Observations");
                Utility.GreenText2(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var c in queryClient)
                {
                    string line = String.Format("{0,-10} | {1,-30} | {2,-9} | {3,-11} | {4,-10} | {5,-9} | {6,-30} | {7,-10} | {8, -30}",
                        c.ClientID, c.Name, c.Nif, c.BirthDate.ToString("yyyy-MM-dd"), c.LocationID, c.Phone, c.Email, c.IsActive, c.Observations);
                    Utility.WriteMessage(line, "", "\n");
                }
            }
        }

        public static void UpdateClientName(string name, Client result)
        {

            using (var context = new RSGymPTDBContext())
            {
                var result2 = context.Client.FirstOrDefault(c => c.ClientID == result.ClientID);
                result2.Name = name;
                context.SaveChanges();
            }
        }

        public static void UpdateClientBirthdate(DateTime birthdate, Client result)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result2 = context.Client.FirstOrDefault(c => c.ClientID == result.ClientID);
                result2.BirthDate = birthdate;
                context.SaveChanges();
            }
        }

        public static void UpdateClientLocation(int locationID, Client result)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result2 = context.Client.FirstOrDefault(c => c.ClientID == result.ClientID);
                result2.LocationID = locationID;
                context.SaveChanges();
            }
        }

        public static void UpdateClientPhone(string phone, Client result)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result2 = context.Client.FirstOrDefault(c => c.ClientID == result.ClientID);
                result2.Phone = phone;
                context.SaveChanges();
            }
        }

        public static void UpdateClientEmail(string email, Client result)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result2 = context.Client.FirstOrDefault(c => c.ClientID == result.ClientID);
                result2.Email = email;
                context.SaveChanges();
            }
        }

        public static void UpdateClientObservations(string observations, Client result)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result2 = context.Client.FirstOrDefault(c => c.ClientID == result.ClientID);
                result2.Observations = observations;
                context.SaveChanges();
            }
        }

        public static Client CheckClientName(string name)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result = context.Client
                    .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                    .FirstOrDefault();

                return result;
            }
        }

        public static bool VerifyClientStatus(int clientID)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result = context.Client
                .Where(c => c.ClientID == clientID)
                .Select(c => c.IsActive)
                .FirstOrDefault();

                return result;
            }
        }

        public static void ChangeClientStatus(bool clientStatus, int clientID)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result = context.Client.FirstOrDefault(c => c.ClientID == clientID);

                if (clientStatus == false)
                {
                    result.IsActive = true;
                    context.SaveChanges();
                }
                else
                {
                    result.IsActive = false;
                    context.SaveChanges();
                }
            }
        }

        public static bool CheckClientEmailPhone(string inputType, string input)
        {
            using (var context = new RSGymPTDBContext())
            {
                if (inputType == "email")
                {
                    var result = context.Client.FirstOrDefault(c => c.Email == input);
                    return result != null;
                }
                else
                {
                    var result = context.Client.FirstOrDefault(c => c.Phone == input);
                    return result != null;
                }
            }
        }

        public static bool CheckClientNif(string nif)
        {
            using (var context = new RSGymPTDBContext())
            {
                var client = context.Client.FirstOrDefault(c => c.Nif == nif);
                if (client == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static Client VerifyClientID(int clientID)
        {
            using (var context = new RSGymPTDBContext())
            {
                return context.Client.FirstOrDefault(c => c.ClientID == clientID);
            }
        }

        #endregion
    }
}



