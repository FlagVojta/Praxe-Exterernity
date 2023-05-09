using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Microsoft.Data.SqlClient;

namespace BlazorApp1.DbConnect
{
    public class MyContext
    {
        public void DatabaseInput()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=dbPraxe;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            
        }
       
    }
}
