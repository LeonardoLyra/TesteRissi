using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste_Rissi.Models;

namespace Teste_Rissi.Data
{
    public class CarroData : Data
    {
        public void Create(Carro carros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;

            cmd.CommandText = @"Insert into Carros Values (@nome, @eixos, @categoria, @tamanhoPortaMalas, @preco, @portas, @createdAt, @updatedAt)";

            cmd.Parameters.AddWithValue("@nome", carros.Nome);
            cmd.Parameters.AddWithValue("@eixos", carros.Eixos);
            cmd.Parameters.AddWithValue("@categoria", carros.Cat.ToString());
            cmd.Parameters.AddWithValue("@tamanhoPortaMalas", carros.TamanhoPortaMalas);
            cmd.Parameters.AddWithValue("@preco", carros.Preco);
            cmd.Parameters.AddWithValue("@portas", carros.Portas);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

            cmd.ExecuteNonQuery();
        }

        public List<Carro> Read()
        {
            List<Carro> lista = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Select * from Carros Order By IdCarro";

                SqlDataReader reader = cmd.ExecuteReader();

                lista = new List<Carro>();

                while (reader.Read())
                {
                    Carro carro = new Carro();

                    carro.IdCarro = (int)reader["IdCarro"];
                    carro.Nome = (string)reader["Nome"];
                    carro.Eixos = (int)reader["Eixos"];
                    string cat = (string)reader["Categoria"];
                    carro.TamanhoPortaMalas = (int)reader["TamanhoPortaMalas"];
                    carro.Preco = (decimal)reader["Preco"];
                    carro.Portas = (int)reader["Portas"];
                    carro.CreatedAt = (DateTime)reader["CreatedAt"];
                    carro.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    

                    lista.Add(carro);

                }
            }
            catch (SqlException sqlerror)
            {
                Console.WriteLine("Erro" + sqlerror);
            }
            return lista;
        }

        public Carro Read(int id)
        {

            Carro carro = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;

            cmd.CommandText = @"Select * from Carros Where IdCarro = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                carro = new Carro
                {
                    IdCarro = (int)reader["IdCarro"],
                    Nome = (string)reader["Nome"],
                    Eixos = (int)reader["Eixos"],
                    //Cat = (string)reader["Categoria"],
                    TamanhoPortaMalas = (int)reader["TamanhoPortaMalas"],
                    Preco = (decimal)reader["Preco"],
                    Portas = (int)reader["Portas"],
                    CreatedAt = (DateTime)reader["CreatedAt"],
                    UpdatedAt = (DateTime)reader["UpdatedAt"],

                };
            }

            return carro;
        }

        public void Update(Carro carro)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Update Carro set Nome = @nome, Eixos = @eixos, Categoria = @categoria, TamanhoPortaMalas = @tamanhoPortaMalas, Preco = @preco, Portas = @portas, CreatedAt = @createdAt, UpdatedAt = @updatedAt
            Where IdCliente = @id";

            cmd.Parameters.AddWithValue("@id", carro.IdCarro);
            cmd.Parameters.AddWithValue("@nome", carro.Nome);
            cmd.Parameters.AddWithValue("@Categoria", carro.Cat);
            cmd.Parameters.AddWithValue("@TamanhoPortaMalas", carro.TamanhoPortaMalas);
            cmd.Parameters.AddWithValue("@Preco", carro.Preco);
            cmd.Parameters.AddWithValue("@Portas", carro.Portas);
            cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);

            cmd.ExecuteNonQuery();
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Delete from Carro Where IdCarro = @id";

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                return false;
            }

        }

    }
}
