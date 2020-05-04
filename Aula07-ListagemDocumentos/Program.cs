using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula07_ListagemDocumentos
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

                // Obtendo uma lista de documentos:

                //FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Empty;
                //List<Usuario> usuarios = collectionUsuario.Find(filtro).ToList();
                //usuarios.ForEach(u => Console.WriteLine(u));

                //FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Where(u => u.Ativo == true);
                //List<Usuario> usuarios = collectionUsuario.Find(filtro).ToList();
                //usuarios.ForEach(u => Console.WriteLine(u));

                // Obtendo apenas um documento:

                FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Where(u => u.Login == "pexe");
                Usuario usuario = collectionUsuario.Find(filtro).FirstOrDefault();
                Console.WriteLine(usuario);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}