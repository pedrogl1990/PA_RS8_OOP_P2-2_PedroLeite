using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RSGymPT_DAL.Model.User;
using D00_Utility;
using System.Xml.Linq;

namespace RSGymPT_Client.Repository
{
    public class LocationRepository
    {
        // Classe com os métodos do repositório de localizações

        #region Methods
        public static void CreateLocation(string postalCode, string city)
        {

            Location location = new Location()
            {
                PostalCode= postalCode,
                City= city
            };

            using (var context = new RSGymPTDBContext())
            {
                context.Location.Add(location);
                context.SaveChanges();
            }

        }

        public static void ReadLocation()
        {
            using (var context = new RSGymPTDBContext())
            {
                var queryLocation = context.Location
                     .Select(l => l)
                     .OrderBy(l => l.City);
                string header = String.Format("{0,-10} | {1,-15} | {2,-30}",
                   "LocationID", "Postal Code", "City");
                Utility.GreenText2(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var l in queryLocation)
                {
                    string line = String.Format("{0,-10} | {1,-15} | {2,-30}",
                        l.LocationID, l.PostalCode, l.City);
                    Utility.WriteMessage(line, "", "\n");
                }
            }
        }

        public static Location CheckLocationID(int locationID)
        {
            using (var context = new RSGymPTDBContext())
            {
                var result = context.Location
                    .Where(l => l.LocationID == locationID)
                    .FirstOrDefault();

                return result;
            }
        }

        #endregion
    }
}
