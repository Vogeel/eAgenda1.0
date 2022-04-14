using eAgenda1._0.ModuloTarefa;
using eAgenda1._0.ModuloItem;
using eAgenda1._0.ModuloContato;
using eAgenda1._0.ModuloCompromisso;

using System;

namespace eAgenda1._0.Compartilhado
{
    internal class TelaMenuPrincipal
    {

        private RepositorioTarefa repositorioTarefa;
        private TelaCadastroTarefa telaCadastroTarefa;

        private RepositorioItem repositorioItem;
        private TelaCadastroItem telaCadastroItem;

        private RepositorioContato repositorioContato;
        private TelaCadastroContato telaCadastroContato;

        private RepositorioCompromisso repositorioCompromisso;
        private TelaCadastroCompromisso telaCadastroCompromisso;

        public TelaMenuPrincipal()
        {
            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa( repositorioTarefa);


            repositorioItem = new RepositorioItem();
            telaCadastroItem = new TelaCadastroItem(repositorioItem);

            repositorioContato = new RepositorioContato();
            telaCadastroContato = new TelaCadastroContato(repositorioContato);

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, repositorioContato, telaCadastroContato);
            repositorioContato.Inserir(new Contato("a", "b", "c", "d", "e"));
            repositorioCompromisso.Inserir(new Compromisso("a", "a", DateTime.Parse("13/04/2022 23:26"), DateTime.Parse("13/04/2022 23:22"), new Contato("a", "b", "c", "d", "e")));
            repositorioCompromisso.Inserir(new Compromisso("a", "a", DateTime.Parse("13/04/2021 5:26"), DateTime.Parse("13/04/2021 5:22"), new Contato("a", "b", "c", "d", "e")));
            repositorioCompromisso.Inserir(new Compromisso("a", "a", DateTime.Parse("15/04/2022 5:26"), DateTime.Parse("15/04/2022 5:22"), new Contato("a", "b", "c", "d", "e")));
        }
        private string opcaoSelecionada;
        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Clube da Leitura 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Tarefas");
            Console.WriteLine("Digite 2 para Cadastrar Contastos");
            Console.WriteLine("Digite 3 para Cadastrar Compromissos");


            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public object ObterTela()
        {
            string opcao = MostrarOpcoes();

            if (opcao == "1")
                return telaCadastroTarefa;

            else if (opcao == "2")
                return telaCadastroContato;

            else if (opcao == "3")
                return telaCadastroCompromisso;

            return null;
        }
    }
}
