using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExercisesADO.NET
{
    public class SQLQuerryes
    {
        public const string GetAllMinnions = 
            @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
            FROM Villains AS v
            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
            GROUP BY v.Id, v.Name
                HAVING COUNT(mv.VillainId) > 3 
            ORDER BY COUNT(mv.VillainId)";

        public const string GetVillainByName =
            @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string GetAllMinionsbyVillianById =
            @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) AS RowNum,
                m.Name, 
                m.Age
            FROM MinionsVillains AS mv
            JOIN Minions As m ON mv.MinionId = m.Id
            WHERE mv.VillainId = @Id
            ORDER BY m.Name";


    }
}
