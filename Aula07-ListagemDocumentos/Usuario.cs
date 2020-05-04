using MongoDB.Bson;

namespace Aula07_ListagemDocumentos
{
    public class Usuario
    {
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return $"Usuário: {Login} | Status: {(Ativo ? "Ativo" : "Inativo")}";
        }
    }
}