using eAgenda1._0.Compartilhado;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace eAgenda1._0.ModuloContato
{
    public class TelaCadastroContato : TelaBase<RepositorioContato, Contato>
    {

        readonly RepositorioContato _repositorioContato;
        public TelaCadastroContato(RepositorioContato repositorioContato) : base("Cadastro de Contatos", repositorioContato)
        {
            _repositorioContato = repositorioContato;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Contato");
            Contato novoContato = ObterContato();
            base.Inserir(novoContato);
        }

        public  void Editar()
        {
            MostrarTitulo("Editando Contato");
            int id = ObterNumeroId();
            base.Editar(ObterContato(), id);
        }

        public new void Excluir()
        {
            MostrarTitulo("Excluindo Contato");
            base.Excluir();
        }

        public new void VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Contatos");
            base.VisualizarRegistros(tipoVisualizacao);
        }

        private bool validTelephoneNo(string telNo)
        {
            return Regex.Match(telNo, @"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$").Success;
        }
        private bool IsValidEmail(string emailaddress)
        {
            return new EmailAddressAttribute().IsValid(emailaddress);
        }
        private Contato ObterContato()
        {
            Console.WriteLine("Digite o Nome do contato: ");
            string nome = Console.ReadLine();

            string email;
            do
            {
                Console.WriteLine("Digite o e-mail do contato");
                email = Console.ReadLine();
            } while (!IsValidEmail(email));

            string telefone;
            do
            {
                Console.WriteLine("Digite numero de telefone do contato (xx) xxxxx-xxxx");
                telefone = Console.ReadLine();

            } while (!(validTelephoneNo(telefone)));

            Console.WriteLine("Digite a empresa do contato");
            string empresa = Console.ReadLine();

            Console.WriteLine("Digite o cargo do contato");
            string cargo = Console.ReadLine();
            return new Contato(nome, email, telefone, empresa, cargo);
        }

        public Contato PegarRegistro()
        {
            return _repositorioContato.PegarRegistro(ObterNumeroId());          
        }
    }
}
