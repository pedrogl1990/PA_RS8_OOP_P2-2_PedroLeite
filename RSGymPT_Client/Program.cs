using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D00_Utility;
using RSGymPT_Client.InitialDatabase;
using RSGymPT_Client.ApplicationStructure;
using RSGymPT_Client.InitialData;

namespace RSGymPT_Client
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Utility.SetUnicodeConsole();

                AppLayout appLayout = new AppLayout();

                //(tirar o comentário da linha 28 para povoar as tabelas com os dados após a migration)

                //InitialAppData.CreateInitialData();
                appLayout.MenuLayout();

            }
            catch (Exception exception)
            {

                Console.WriteLine($"Ocorreu um erro: {exception}");
            }
            finally
            {
                Utility.TerminateConsole();
            }
        }
    }
}
