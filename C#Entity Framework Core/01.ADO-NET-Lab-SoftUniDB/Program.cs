
using Microsoft.Data.SqlClient;

SqlConnection connection = new SqlConnection("Server = ACERPREDATOR\\SQLEXPRESS; Database = SoftUni; Integrated Security=true;Trust Server Certificate = true ");

connection.Open();
using (connection)
//{
//    SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
//    int? employeesCount = (int?) await command.ExecuteScalarAsync();
//    Console.WriteLine($"Count {employeesCount}");
//}

{
    SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection); 
    //SqlDataReader reader = command.ExecuteReader();
    SqlDataReader reader = await command.ExecuteReaderAsync();


    using (reader)
    {
        while (reader.Read())
        {
            string name = reader["FirstName"].ToString().ToString();
            string lastName = reader[2].ToString().ToString();
            Console.WriteLine($"{name} {lastName}");
        }
    }
}