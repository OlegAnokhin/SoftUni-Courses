using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExercisesADO.NET
{
    public class Config
    {
        public const string ConnectionString =
            @"Server = ACERPREDATOR\SQLEXPRESS; 
            Database = MinionsDB; 
            Integrated Security=true;
            Trust Server Certificate = true;";
    }
}
