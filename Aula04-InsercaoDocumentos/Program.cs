using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula04_InsercaoDocumentos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");

                IMongoDatabase database = client.GetDatabase("loja"); // Se o banco não existir, o MongoDB cria.

                IMongoCollection<Usuario> collectionUsuario = database.GetCollection<Usuario>("usuarios");

                Console.WriteLine("Conexão com o banco do MongoDB realizada com sucesso.");

                Usuario usuario = new Usuario { Login = "teste", Senha = "teste" };
                collectionUsuario.InsertOne(usuario);

                //List<Usuario> usuarios = new List<Usuario> { new Usuario { Login = "pexe", Senha = "kareneuteamo" }, new Usuario { Login = "bernauuudo", Senha = "b3u" } };
                //collectionUsuario.InsertMany(usuarios);

                Console.WriteLine("Documento(s) inserido(s) com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}