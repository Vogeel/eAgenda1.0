using eAgenda1._0.Compartilhado;
using eAgenda1._0.ModuloContato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eAgenda1._0.ModuloCompromisso
{
    public class TelaCadastroCompromisso : TelaBase<RepositorioCompromisso, Compromisso>
    {

        readonly RepositorioCompromisso _repositorioCompromisso;
        readonly RepositorioContato _repositorioContato;
        readonly TelaCadastroContato _telaCadastroContato;
        public TelaCadastroCompromisso(RepositorioCompromisso repositorioCompromisso,  RepositorioContato repositorioContato, TelaCadastroContato telaCadastroContato)
            : base("Cadastro de Compromissos", repositorioCompromisso)
        {
            _repositorioCompromisso = repositorioCompromisso;

            _repositorioContato = repositorioContato;
            _telaCadastroContato = telaCadastroContato;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Compromisso");
            Compromisso novoCompromisso = ObterCompromisso();
            base.Inserir(novoCompromisso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Compromisso");
            int id = ObterNumeroId();
            base.Editar(ObterCompromisso(), id);
        }

        public new void Excluir()
        {
            MostrarTitulo("Excluindo Compromisso");
            base.Excluir();
        }

        public new void VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Compromissos");
            base.VisualizarRegistros(tipoVisualizacao);
        }

        private Compromisso ObterCompromisso()
        {
            Console.WriteLine("Digite o assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.WriteLine("Digite o local do Compromisso ");
            string local = Console.ReadLine();

            Console.WriteLine("Digite a data de inicio do Compromisso");
            DateTime dataInicio = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Digite a data final do Compromisso");
            DateTime dataFim = Convert.ToDateTime(Console.ReadLine());

            _telaCadastroContato.VisualizarRegistros("pesquisa");
            Console.WriteLine("Qual o Contato que irá no compromisso?");
            int contatoSelecionado = Convert.ToInt32(Console.ReadLine());
            Contato c = _telaCadastroContato.PegarRegistro();


            return new Compromisso(assunto, local, dataInicio, dataFim, c);
        }

    }
}
