using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula06_ExclusaoDocumentos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://localhost:27017");

                IMongoDatabase database = client.GetDatabase("loja");

                IMongoCollection<Usuario> collectionUsuario = database.GetCollection<Usuario>("usuarios");

                FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Eq(u => u.Login, "teste");
                DeleteResult resultado = collectionUsuario.DeleteOne(filtro);

                //FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Where(u => u.Login == "wesley" || u.Login == "diego");
                //DeleteResult resultado = collectionUsuario.DeleteMany(filtro);

                Console.WriteLine($"{resultado.DeletedCount} documento(s) excluído(s).");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}