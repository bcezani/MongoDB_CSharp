using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula05_AlteracaoDocumentos
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

                //Atualização de 1 documento:

                FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Eq(u => u.Login, "bruno");
                UpdateDefinition<Usuario> alteracao = Builders<Usuario>.Update.Set(u => u.Ativo, true);
                collectionUsuario.UpdateOne(filtro, alteracao);

                //Atualização de vários documentos: Por exemplo, inserir uma nova propriedade em todos os documentos.

                //FilterDefinition<Usuario> filtro = Builders<Usuario>.Filter.Empty; // Filtro vazio para alcançar todos os documentos da coleção.
                //UpdateDefinition<Usuario> alteracao = Builders<Usuario>.Update.Set(u => u.Ativo, false);
                //collectionUsuario.UpdateMany(filtro, alteracao);

                Console.WriteLine("Documento(s) atualizado(s) com sucesso.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}