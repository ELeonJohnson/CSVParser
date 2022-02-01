using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSVParser.Mappers
{
    public sealed class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(u => u.FirstName).Name("First Name");
            Map(u => u.LastName).Name("Last Name");
            Map(u => u.Email).Name("Email");
         

        }
    }
}
