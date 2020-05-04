using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula09_TratandoErrosDeConexao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MongoClientSettings settings = new MongoClientSettings
                {
                    ServerSelectionTimeout = new TimeSpan(0, 0, 5),
                    Server = new MongoServerAddress("localhost", 27017)
                };

                MongoClient client = new MongoClient(settings);

                IMongoDatabase database = client.GetDatabase("loja");

                IMongoCollection<Cliente> collectionCliente = database.GetCollection<Cliente>("clientes");

                FilterDefinition<Cliente> filtro = Builders<Cliente>.Filter.Eq(c => c.Endereco.UF, "ES");

                //Consulta a coleção no banco de dados:
                List<Cliente> clientes = collectionCliente.Find(filtro).ToList();

                clientes.ForEach(c => Console.WriteLine(c));

                BsonDocument comando = new BsonDocument("ping", 1);

                BsonDocument resultado = database.RunCommandAsync<BsonDocument>(comando).Result;
            }
            catch (Exception e)
            {
                if (e.InnerException != null && e.InnerException is TimeoutException)
                    Console.WriteLine($"Erro: Não foi possível conectar ao servidor.");
            }
            //catch (TimeoutException) // Forma mais usual de implementar o Exception acima.
            //{
            //    Console.WriteLine($"Erro: Não foi possível conectar ao servidor.");
            //}
        }
    }
}