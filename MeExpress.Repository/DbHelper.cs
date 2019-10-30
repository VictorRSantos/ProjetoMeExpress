using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeExpress.Repository
{
    public static class DbHelper
    {

        private const string stringDeConexao = @"Data Source=DESKTOP;Initial Catalog=MeExpressDB;Integrated Security=True;Pooling=False";



        public static SqlConnection obterConexao()
        {
            return new SqlConnection(stringDeConexao);
        }


        public static int Execute(string sql, object parametro)
        {

            using (var db = obterConexao())
            {
                return db.Execute(sql, parametro, commandType: CommandType.StoredProcedure);
            }

        }



        public static List<T> Query<T>(string sql, object parametro)
        {
            using (var db = obterConexao())
            {
                return db.Query<T>(sql, parametro, commandType: CommandType.StoredProcedure).ToList();
            }

        } 



        public static T QueryFirstOrDefault<T>(string sql, object parametro)
        {
            using (var db = obterConexao())
            {
                return db.QueryFirstOrDefault(sql, parametro, commandType:CommandType.StoredProcedure);
            }
        }





    }
}
