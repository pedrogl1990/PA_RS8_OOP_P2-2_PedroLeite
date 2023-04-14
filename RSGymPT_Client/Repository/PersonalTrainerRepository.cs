using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;

namespace RSGymPT_Client.Repository
{
    public class PersonalTrainerRepository
    {
        // Classe com os métodos do repositório de PT's

        #region Methods
        public static void CreatePT(int locationID, string name, string nif, string code, string phone, string email)
        {

            PersonalTrainer personalTrainer = new PersonalTrainer()
            {
                LocationID = locationID,
                Name = name,
                Nif = nif,
                Code = code,
                Phone = phone,
                Email = email,
            };

            using (var context = new RSGymPTDBContext())
            {
                context.PersonalTrainer.Add(personalTrainer);
                context.SaveChanges();
            }

        }

        public static void ReadPT()
        {
            using (var context = new RSGymPTDBContext())
            {
                var queryPT = context.PersonalTrainer
                     .Select(p => p)
                     .OrderBy(p => p.Name);


                string header = String.Format("{0,-10} | {1,-30} | {2,-9} | {3,-10} | {4,-10} | {5,-30} | {6,-5}",
                       "PTID", "Name", "Nif", "Location", "Phone", "Email", "Code");
                Utility.GreenText2(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var p in queryPT)
                {
                    string line = String.Format("{0,-10} | {1,-30} | {2,-9} | {3,-10} | {4,-10} | {5,-30} | {6,-5}",
                        p.PersonalTrainerID, p.Name, p.Nif, p.LocationID, p.Phone, p.Email, p.Code);
                    Utility.WriteMessage(line, "", "\n");
                }
            }
        }

        public static bool CheckPTCode(string code)
        {
            using (var context = new RSGymPTDBContext())
            {
                var pt = context.PersonalTrainer.FirstOrDefault(p => p.Code == code);
                if (pt == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool CheckPTPhoneOrNif(string input, string inputType)
        {
            if (inputType == "phone")
            {
                using (var context = new RSGymPTDBContext())
                {
                    var pt = context.PersonalTrainer.FirstOrDefault(p => p.Phone == input);
                    if (pt == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                using (var context = new RSGymPTDBContext())
                {
                    var pt = context.PersonalTrainer.FirstOrDefault(p => p.Nif == input);
                    if (pt == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }   
        }
        public static bool CheckPTEmail(string email)
        {
            using (var context = new RSGymPTDBContext())
            {
                var pt = context.PersonalTrainer.FirstOrDefault(p => p.Email == email);
                if (pt == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static bool CheckPTID(int pTID)
        {
            using (var context = new RSGymPTDBContext())
            {
                var pt = context.PersonalTrainer.FirstOrDefault(p => p.PersonalTrainerID == pTID);
                if (pt == null)
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
