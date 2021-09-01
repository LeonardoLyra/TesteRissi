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
                string strConexao = Environment.GetEnvironmentVariable("StrConexao", EnvironmentVariableTarget.Machine);
                
                //string strConexao = "Data Source = DESKTOP-Q909P6C\\SQLEXPRESS; Initial Catalog = bd_testeRissi; Integrated Security = true;"

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
