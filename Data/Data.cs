using System;
using System.Data.SqlClient;

namespace Teste_Rissi.Data
{
    public abstract class Data : IDisposable
    {
        protected SqlConnection connectionDB;

        

        protected Data()
        {
            try
            {
                string strConexao = Environment.GetEnvironmentVariable("DataBase");

                connectionDB = new SqlConnection(strConexao);

                connectionDB.Open();
            }
            catch(SqlException er)
            {
                Console.WriteLine("Erro do banco" + er);
            }
        }

        public void Dispose()
        {
            connectionDB.Close();
        }
    }
}
