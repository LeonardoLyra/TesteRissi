using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste_Rissi.Models;
using static Teste_Rissi.Models.Carro;

namespace Teste_Rissi.Data
{
    public class CarroData : Data
    {
        public void Create(Carro carros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;

            cmd.CommandText = @"Insert into Carros Values (@nome, @eixos, @categoria, @tamanhoPortaMalas, @portas, @preco, @createdAt, @updatedAt)";

            cmd.Parameters.AddWithValue("@nome", carros.Nome);
            cmd.Parameters.AddWithValue("@eixos", carros.Eixos);
            cmd.Parameters.AddWithValue("@categoria", carros.NomeCategoria);
            cmd.Parameters.AddWithValue("@tamanhoPortaMalas", carros.TamanhoPortaMalas);
            cmd.Parameters.AddWithValue("@portas", carros.Portas);
            cmd.Parameters.AddWithValue("@preco", carros.Preco);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

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
                    if((string)reader["Categoria"] == "Hatch")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Hatch);
                    }
                    else if ((string)reader["Categoria"] == "Sedan")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Sedan);
                    }
                    else if ((string)reader["Categoria"] == "SUV")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.SUV);
                    }
                    else if ((string)reader["Categoria"] == "Utilitario")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Utilitario);
                    }
                    else
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Picape);
                    }
                    carro.NomeCategoria = (string)reader["Categoria"];
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

                carro = new Carro();

                    carro.IdCarro = (int)reader["IdCarro"];
                    carro.Nome = (string)reader["Nome"];
                    carro.Eixos = (int)reader["Eixos"];
                    if((string)reader["Categoria"] == "Hatch")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Hatch);
                    }
                    else if ((string)reader["Categoria"] == "Sedan")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Sedan);
                    }
                    else if ((string)reader["Categoria"] == "SUV")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.SUV);
                    }
                    else if ((string)reader["Categoria"] == "Utilitario")
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Utilitario);
                    }
                    else
                    {
                        carro.SetCategoria(categoria:CategoriaEnum.Picape);
                    }
                    carro.TamanhoPortaMalas = (int)reader["TamanhoPortaMalas"];
                    carro.Preco = (decimal)reader["Preco"];
                    carro.Portas = (int)reader["Portas"];
                    carro.CreatedAt = (DateTime)reader["CreatedAt"];
                    carro.UpdatedAt = (DateTime)reader["UpdatedAt"];
                    
            }

            return carro;
        }

        public void Update(Carro carro)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Update Carros set Nome = @nome, Eixos = @eixos, Categoria = @categoria, TamanhoPortaMalas = @tamanhoPortaMalas, Portas = @portas, Preco = @preco, UpdatedAt = @updatedAt
            Where IdCarro = @id";

            cmd.Parameters.AddWithValue("@id", carro.IdCarro);
            cmd.Parameters.AddWithValue("@nome", carro.Nome);
            cmd.Parameters.AddWithValue("@eixos", carro.Eixos);
            cmd.Parameters.AddWithValue("@categoria", carro.NomeCategoria);
            cmd.Parameters.AddWithValue("@tamanhoPortaMalas", carro.TamanhoPortaMalas);
            cmd.Parameters.AddWithValue("@portas", carro.Portas);
            cmd.Parameters.AddWithValue("@preco", carro.Preco);
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);

            cmd.ExecuteNonQuery();
        }

        public bool Delete(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.connectionDB;
                cmd.CommandText = @"Delete from Carros Where IdCarro = @id";

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
