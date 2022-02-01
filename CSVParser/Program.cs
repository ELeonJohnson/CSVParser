using CsvHelper;
using CSVParser.Mappers;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;


namespace CSVParser
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Please enter a file name:");
            Console.WriteLine("File Name Formatting Example:C:/Users/enoch/Desktop/repos/CSVParser/CSVParser/CSVFiles/UserData.csv");

            var userFileName = Console.ReadLine();

            if (File.Exists(userFileName))
    
                using (var reader = new StreamReader("C:/Users/enoch/Desktop/repos/CSVParser/CSVParser/CSVFiles/UserData.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<UserMap>();
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var records = csv.GetRecords<User>();
                        

                        bool IsValidEmail(string email)
                        {
                            var trimmedEmail = email.Trim();

                            if (trimmedEmail.EndsWith("gdcit.com"))
                            {
                                   
                                return true;
                            }
                            else
                            {
                                
                                return false;
                            }

                        }

                        List<User> validList = new List<User>();
                        List<User> inValidList = new List<User>();

                        foreach (var record in records)
                        {
                            if (IsValidEmail(record.Email))
                            {
                                validList.Add(record);
                            }
                            else 
                            {
                                inValidList.Add(record);
                            }
                        }

                        Console.WriteLine("List Of Valid Users");
                        foreach (var validUser in validList)
                        {
                            Console.WriteLine(validUser.Email + ": " + validUser.FirstName + validUser.LastName);
                        }
                        Console.WriteLine("List Of Invalid Users");
                        foreach (var inValidUser in inValidList)
                        {
                            Console.WriteLine(inValidUser.Email + ": " + inValidUser.FirstName + inValidUser.LastName);
                        }

                    }
                }
            else
                Console.WriteLine("File does not exist.");
           
           

            
           

           

        }
    }
}
