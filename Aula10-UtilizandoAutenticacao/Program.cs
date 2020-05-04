using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula10_UtilizandoAutenticacao
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
                    Server = new MongoServerAddress("localhost", 27017),
                    Credentials = new[]{
                        MongoCredential.CreateCredential("loja", "bruno", "xyz123")
                    }
                };

                MongoClient client = new MongoClient(settings);

                IMongoDatabase database = client.GetDatabase("loja");

                IMongoCollection<Cliente> collectionCliente = database.GetCollection<Cliente>("clientes");

                // Teste - Inserção de novo Cliente:
                //Cliente cliente = new Cliente
                //{
                //    Nome = "Antonio Pereira",
                //    Email = "antonio@email.com",
                //    Telefone = "99999-8888"
                //};

                //collectionCliente.InsertOne(cliente);

                // Listagem (leitura) de Clientes:
                FilterDefinition<Cliente> filtro = Builders<Cliente>.Filter.Empty;
                List<Cliente> clientes = collectionCliente.Find(filtro).ToList();
                clientes.ForEach(c => Console.WriteLine(c));
            }
            catch (TimeoutException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}