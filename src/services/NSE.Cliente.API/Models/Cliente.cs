using NSE.Core.DomainObjects;

namespace NSE.Clientes.API.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }
        //EF
        protected Cliente() { }

        public Cliente(Guid id ,string nome, string email, string cpf, bool excluido)
        {
            Id = id;
            Nome = nome;
            Excluido = false;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
        }

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }
        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
