using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Aula08_DocumentosComplexos
{
    class Program
    {
        static List<Cliente> GerarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente
            {
                Nome = "Bruno Cezani",
                Email = "bruno@cezani.com",
                Telefone = "9999-8888",
                Endereco = new Endereco
                {
                    Logradouro = "Rua Fulano de Tal",
                    Numero = 123,
                    Bairro = "Bairro Sem Nome",
                    Cidade = "Vila Velha",
                    UF = "ES"
                }
            });
            clientes.Add(new Cliente
            {
                Nome = "Pexe Veronez",
                Email = "pexe@veronez.com",
                Telefone = "8888-7777",
                Endereco = new Endereco
                {
                    Logradouro = "Avenida Doutor Fulano",
                    Numero = 789,
                    Bairro = "Bairro Qualquer",
                    Cidade = "Vila Velha",
                    UF = "ES"
                }
            });
            clientes.Add(new Cliente
            {
                Nome = "Bernard Hacker",
                Email = "bernauuudo@hacker.com",
                Telefone = "7777-6666",
                Endereco = new Endereco
                {
                    Logradouro = "Rua Sem Nome",
                    Numero = 456,
                    Bairro = "Bairro da Aparecida",
                    Cidade = "São Paulo",
                    UF = "SP"
                }
            });
            return clientes;
        }

        static void Main(string[] args)
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://localhost:27017");

                IMongoDatabase database = client.GetDatabase("loja");

                IMongoCollection<Cliente> collectionCliente = database.GetCollection<Cliente>("clientes");

                FilterDefinition<Cliente> filtro = Builders<Cliente>.Filter.Eq(c => c.Endereco.UF, "SP");

                // Gera os clientes e insere na coleção:

                //List<Cliente> clientes = GerarClientes();
                //collectionCliente.InsertMany(clientes);

                // Lista os clientes:

                List<Cliente> listaClientes = collectionCliente.Find(filtro).ToList();
                listaClientes.ForEach(c => Console.WriteLine(c));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}