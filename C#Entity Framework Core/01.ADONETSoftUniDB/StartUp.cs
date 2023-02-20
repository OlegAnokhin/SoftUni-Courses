using System.Text;
using _02.ExercisesADO.NET;
using Microsoft.Data.SqlClient;

public class StartUp
{
    static async Task Main(string[] args)
    {
        await using SqlConnection sqlConnection = 
            new SqlConnection(Config.ConnectionString);
        await sqlConnection.OpenAsync();
 //PR2       string result = await VilliansMinnions(sqlConnection);
 //PR3
    int villainId = int.Parse(Console.ReadLine());
    string result = await GetVillianwithAllMinnionsById(sqlConnection, villainId);
        Console.WriteLine(result);
    }

    static async Task<string> VilliansMinnions(SqlConnection sqlConnection)
    {
        StringBuilder sb = new StringBuilder();
        SqlCommand sqlCommand = new SqlCommand(SQLQuerryes.GetAllMinnions);
        SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();
        while (reader.Read())
        {
            string villianName = (string)reader["Name"];
            int minionsCount = (int)reader["MinionsCount"];

            sb.AppendLine($"{villianName} - {minionsCount}");
        }
        return sb.ToString().TrimEnd();
    }

    static async Task<string> GetVillianwithAllMinnionsById(SqlConnection sqlConnection, int villainId)
    {
        SqlCommand getVillainNameCmd = 
            new SqlCommand(SQLQuerryes.GetVillainByName);
        getVillainNameCmd.Parameters.AddWithValue("@Id", villainId);
        object? villianNameObj = await getVillainNameCmd.ExecuteScalarAsync();
        if (villianNameObj == null)
        {
            return $"No villain with ID {villainId} exists in the database.";
        }
        string villainName = (string)villianNameObj;
        SqlCommand getAllMinionsCmd =
            new SqlCommand(SQLQuerryes.GetAllMinionsbyVillianById, sqlConnection);
        getAllMinionsCmd.Parameters.AddWithValue("@Id", villainId);
        SqlDataReader minionsReader = await getAllMinionsCmd.ExecuteReaderAsync();

        string output = GenerateVillianWithMinionsOut(villainName, minionsReader);
        return output;
    }

    private static string GenerateVillianWithMinionsOut(string villainName, SqlDataReader minionsReader)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Villain: {villainName}");
        if (!minionsReader.HasRows)
        {
            sb.AppendLine("(no minions)");
        }
        else
        {
            while (minionsReader.Read())
            {
                long rowNum = (long)minionsReader["RowNum"];
                string minionsName = (string)minionsReader["Name"];
                int minionAge = (int)minionsReader["Age"];
                sb.AppendLine($"{rowNum}. {minionsName} {minionAge}");
            }
        }
        return sb.ToString().TrimEnd();
    }
}

