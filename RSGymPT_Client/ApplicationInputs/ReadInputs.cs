using D00_Utility;
using RSGymPT_Client.ApplicationInputs.Inferface;
using RSGymPT_Client.ApplicationValidation;
using RSGymPT_Client.Repository;
using RSGymPT_DAL.Model;
using System;
using System.Text.RegularExpressions;

namespace RSGymPT_Client.ApplicationInputs
{
    #region Methods
    public class ReadInputs : IReadInputs
    {
        GeneralValidations validations = new GeneralValidations();
        UserValidations userValidations = new UserValidations();
        ClientsValidations clientsValidations = new ClientsValidations();
        PTValidations pTValidations = new PTValidations();
        RequestsValidations requestValidations = new RequestsValidations();
        LocationValidations locationValidations = new LocationValidations();

        // Classe para leitura dos inputs de entrada do user

        public string ReadOption()
        {
            Console.Write("Choose your option: ");
            return Console.ReadLine();
        }

        public (string, string) ReadUserCredentials(string title, string title2)
        {
            Utility.WriteTitle(title, title2);
            Console.WriteLine();
            Console.WriteLine("Plase insert you Login Credentials\n");
            Console.Write("Code: ");
            string code = Console.ReadLine().ToUpper();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            return (code, password);
        }

        public void inputToCreateUser()
        {
            string name, code, password;
            User.ProfileType profile;

            code = userValidations.ValidateUserInputCode("Code", "RSGYMPT - ", "Create user", "Should not be null, have 4 to 6 characters, have no spaces and be unique");
            name = validations.ValidateName("Name", "RSGymPT - ", "Create user", "Should not be null, have < 100 characters and have only letters", 100);
            password = userValidations.ValidateUserPassword("Password", "RSGymPT - ", "Create user", "Should not be null, have 8 to 12 characters and no spaces");
            profile = userValidations.ValidateUserProfile("Profile", "RSGymPT - ", "Create user", "Possible values: 'admin' or 'colab'. Cannot be null");

            UserRepository.CreateUser(name, code, password, profile);
        }

        public void inputToUpdateUser()
        {
            int userID;
            string password;
            userID = userValidations.ValidateUserID("UserID", "RSGymPT - ", "Update User", "Should not be null, contain only digits and match an existing UserID");
            password = userValidations.ValidateUserPassword("Password", "RSGymPT - ", "Update user", "Should not be null, have 8 to 12 characters and no spaces");
            UserRepository.UpdateUser(userID, password);
        }

        public void inputToCreateClient()
        {
            string name, nif, phone, email, observation;
            int locationID;
            bool isActive;
            DateTime birthDate;

            name = validations.ValidateName("Name", "RSGymPT - ", "Create client", "Should not be null, have < 100 characters with only letters", 100);
            birthDate = clientsValidations.ValidateClientBirthDate("Birthdate", "RSGymPT - ", "Create client", "Should be > 01/01/1900 and should have 18 or more years. Format dd/mm/yyyy. Cannot be null");
            nif = clientsValidations.ValidateClientNif("NIF", "RSGymPT - ", "Create client", "Should not be null, contain 9 digits and be unique");
            phone = clientsValidations.ValidateClientPhone("Phone", "RSGymPT - ", "Create client", "Should not be null, contain 9 digits and be unique");
            email = clientsValidations.ValidateClientEmail("Email", "RSGymPT - ", "Create client", "Should not be null, have < 100 characters. Format 'example@domain.com'");
            locationID = locationValidations.ValidateLocationID("LocationID", "RSGymPT - ", "Create client", "Should not be null, contain only digit and match an existing LocationID");
            observation = validations.ValidateObservations("Observation", "RSGymPT - ", "Create client", "Should have less than 255 characters (not required field)", 255);
            isActive = clientsValidations.ValidateClientStatus("Active Status", "RSGymPT - ", "Create client", "Should not be null. Possible values: 'true' or 'false'");

            ClientRepository.CreateClient(locationID, name, nif, birthDate, phone, email, observation, isActive);
        }

        public bool InputToUpdateClient(int option)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    Client result = clientsValidations.ValidateSearchClientName("Client Name", "RSGymPT - ", "Update Client", "Should not be null and be an existing client");
                    string name = validations.ValidateName("Name", "RSGymPT - ", "Update Client", "Should not be null, have < 100 characters with only letters", 100);
                    ClientRepository.UpdateClientName(name, result);
                    Utility.WriteTitle("RSGymPT - ", "Update Client");
                    Utility.GreenText("\nClient Updated Successfully!\n");
                    return true;
                case 2:
                    Console.Clear();
                    result = clientsValidations.ValidateSearchClientName("Client Name", "RSGymPT - ", "Update Client", "Should not be null and be an existing client");
                    DateTime birthDate = clientsValidations.ValidateClientBirthDate("Birthdate", "RSGymPT - ", "Update Client", "Should be > 01/01/1900 and should have 18 or more years. Format dd/mm/yyyy. Cannot be null");
                    ClientRepository.UpdateClientBirthdate(birthDate, result);
                    Utility.WriteTitle("RSGymPT - ", "Update Client");
                    Utility.GreenText("\nClient Updated Successfully!\n");
                    return true;
                case 3:
                    Console.Clear();
                    result = clientsValidations.ValidateSearchClientName("client name", "RSGymPT - ", "Update Client", "Should not be null and be an existing client");
                    int locationID = locationValidations.ValidateLocationID("LocationID", "RSGymPT - ", "Update Client", "Should not be null, contain only digit and match an existing LocationID");
                    ClientRepository.UpdateClientLocation(locationID, result);
                    Console.Clear();
                    Utility.WriteTitle("RSGymPT - ", "Update Client");
                    Utility.GreenText("\nClient Updated Successfully!\n");
                    return true;
                case 4:
                    Console.Clear();
                    result = clientsValidations.ValidateSearchClientName("Client Name", "RSGymPT - ", "Update Client", "Should not be null and be an existing client");
                    string phone = clientsValidations.ValidateClientPhone("Phone", "RSGymPT - ", "Update Client", "Should not be null, contain 9 digits and be unique");
                    ClientRepository.UpdateClientPhone(phone, result);
                    Console.Clear();
                    Utility.WriteTitle("RSGymPT - ", "Update Client");
                    Utility.GreenText("\nClient Updated Successfully!\n");
                    return true;
                case 5:
                    Console.Clear();
                    result = clientsValidations.ValidateSearchClientName("Client Name", "RSGymPT - ", "Update Client", "Should not be null and be an existing client");
                    string email = clientsValidations.ValidateClientEmail("Email", "RSGymPT - ", "Update Client", "Should not be null, have < 100 characters. Format 'example@domain.com'");
                    ClientRepository.UpdateClientEmail(email, result);
                    Console.Clear();
                    Utility.WriteTitle("RSGymPT - ", "Update Client");
                    Utility.GreenText("\nClient Updated Successfully!\n");
                    return true;
                case 6:
                    Console.Clear();
                    result = clientsValidations.ValidateSearchClientName("Client Name", "RSGymPT - ", "Update Client", "Should not be null and be an existing client");
                    string observation = validations.ValidateObservations("Observation", "RSGymPT - ", "Update Client", "Should have less than 255 characters (not required field)", 255);
                    ClientRepository.UpdateClientObservations(observation, result);
                    Console.Clear();
                    Utility.WriteTitle("RSGymPT - ", "Update Client");
                    Utility.GreenText("\nClient Updated Successfully!\n");
                    return true;
                case 7:
                    Console.WriteLine("\nTaking you to Clients Administration Menu\n");
                    Console.ReadKey();
                    return true;
                default:
                    return false;
            }
        }

        public void InputActivateClient()
        {
            int clientID;
            bool clientStatus;

            clientID = clientsValidations.ValidateClientID("Active Status", "RSGymPT - ", "Update Client Status", "Should not be null, contain only digits and match an existing ClientID");
            clientStatus = ClientRepository.VerifyClientStatus(clientID);
            ClientRepository.ChangeClientStatus(clientStatus, clientID);
        }

        public void InputToCreatePT()
        {
            string name, nif, phone, email, code;
            int locationID;

            name = validations.ValidateName("Name", "RSGymPT - ", "Create PT", "Should not be null and be an existing client", 100);
            code = pTValidations.ValidatePTCode("Code", "RSGymPT - ", "Create PT", "Should not be null, contain 4 characters and be unique");
            nif = pTValidations.ValidatePTPhoneAndNif("NIF", "RSGymPT - ", "Create PT", "Should not be null, contain 9 digts and be unique");
            phone = pTValidations.ValidatePTPhoneAndNif("Phone", "RSGymPT - ", "Create PT", "Should not be null, contain 9 digts and be unique");
            email = pTValidations.ValidatePTEmail("Email", "RSGymPT - ", "Create PT", "Should not be null, have < 100 characters. Format 'example@domain.com'");
            locationID = locationValidations.ValidateLocationID("LocationID", "RSGymPT - ", "Create PT", "Should not be null, contain only digit and match an existing LocationID");

            PersonalTrainerRepository.CreatePT(locationID, name, nif, code, phone, email);
        }

        public void InputToCreateRequest()
        {
            string status, observation;
            int clientID, pTID;
            DateTime schedule;

            clientID = clientsValidations.ValidateClientID("ClientID", "RSGymPT - ", "Create Request", "Should not be null, contain only digits and match an existing ClientID");
            pTID = pTValidations.ValidatePTID("PTID", "RSGymPT - ", "Create Request", "Should not be null, contain only digits and match an existing PTID");
            schedule = requestValidations.ValidateRequestSchedule("Schedule", "RSGymPT - ", "Create Request", "Should not be null, > current date and not match other schedule. Format dd/MM/yyyy HH:dd");
            status = requestValidations.ValidateRequestStatus("Status", "RSGymPT - ", "Create Request", "Should not be null. Possible values: 'scheduled', 'ended' or 'cancelled'");
            observation = validations.ValidateObservations("Observation", "RSGymPT - ", "Create Request", "Should have less than 255 characters (not required field)", 255);

            RequestRepository.CreateRequest(clientID, pTID, schedule, status, observation);
        }

        public void inputToCreateLocation()
        {
            string postalCode, city;

            postalCode = locationValidations.ValidateLocationPostalCode("Postal Code", "RSGymPT - ", "Create Locatiom", "Should not be null and contain only digits. Format xxxx-yyy");
            city = locationValidations.ValidateLocationCity("City", "RSGymPT - ", "Create Location", "Should not be null, have < 100 characters and contains only letters");

            LocationRepository.CreateLocation(postalCode, city);
        }

    #endregion
    }
}

