using MongoDB.Driver;
using System;

namespace Aula03_ConexaoComOMongoDB
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}