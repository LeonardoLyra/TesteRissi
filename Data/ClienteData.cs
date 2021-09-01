using Teste_Rissi.Models;
using System.Data.SqlClient;

namespace Teste_Rissi.Data
{
    public class ClienteData : Data
    {
        public void Create(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = base.connectionDB;

            cmd.CommandText = @"Insert into Cliente Values (@nome, @email, @senha)";

            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@senha", cliente.Senha);

            cmd.ExecuteNonQuery();
        }

        public void Update(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Update Cliente set Nome = @nome, Email = @email, Senha = @senha
                                Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@email", cliente.Email);
            cmd.Parameters.AddWithValue("@senha", cliente.Senha);

            cmd.ExecuteNonQuery();
        }

        public Cliente Read(ClienteViewModel model)
        {

            Cliente cliente = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;

            cmd.CommandText = @"Select * from Cliente Where Email = @email and Senha = @senha";

            cmd.Parameters.AddWithValue("@email", model.Email);
            cmd.Parameters.AddWithValue("@senha", model.Senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                cliente = new Cliente
                {
                    IdCliente = (int)reader["IdCliente"],
                    Nome = (string)reader["Nome"],
                    Email = (string)reader["Email"]
                };
            }
            return cliente;
        }


    }
}
