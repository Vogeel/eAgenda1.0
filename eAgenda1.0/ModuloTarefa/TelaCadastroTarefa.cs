using eAgenda1._0.Compartilhado;
using eAgenda1._0.ModuloItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda1._0.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase<RepositorioTarefa, Tarefa>
    {
        readonly RepositorioTarefa _repositorioTarefa;

         TelaCadastroItem _telaCadastroItem;
         RepositorioItem _repositorioItem;
        
        public TelaCadastroTarefa(RepositorioTarefa repositorioTarefa) : base("Cadastro de Tarefas", repositorioTarefa)
        {
            _repositorioTarefa = repositorioTarefa;    
        }
        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para items");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public void InserirItem()
        {
          
            
            int id = ObterNumeroId();
            _telaCadastroItem = _repositorioTarefa.PegarTela(id);
            
            string opcaoSelecionada = _telaCadastroItem.MostrarOpcoes();
            switch (opcaoSelecionada)
            {
                case "1":
                    _telaCadastroItem.Inserir();
                    _repositorioTarefa.AtualizarItems(id, _telaCadastroItem._repositorioItem.SelecionarTodos());
                    break;
                case "2":
                    _telaCadastroItem.Editar();
                    id = ObterNumeroId();
                    _repositorioTarefa.AtualizarItems(id, _telaCadastroItem._repositorioItem.SelecionarTodos());
                    Console.ReadKey();
                    break;
                case "3":
                    _telaCadastroItem.Excluir();
                    id = ObterNumeroId();
                    _repositorioTarefa.AtualizarItems(id, _telaCadastroItem._repositorioItem.SelecionarTodos());
                    Console.ReadKey();
                    break;
                case "4":
                    _telaCadastroItem.VisualizarRegistros("tela");
                    Console.ReadKey();
                    break;
                case "5":
                    _telaCadastroItem.Concluir();
                    _repositorioTarefa.AtualizarItems(id, _telaCadastroItem._repositorioItem.SelecionarTodos());
                    Console.ReadKey();
                    break;
            }
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Tarefa");
            Tarefa tarefa = ObterTarefa(false);
            base.Inserir(tarefa);           
        }

        public void Editar()
        {
            MostrarTitulo("Editando Tarefa");
            
            int id = ObterNumeroId();
            base.Editar(ObterTarefa(true), id);
           
        }

        public new void Excluir()
        {
            MostrarTitulo("Excluindo Tarefa");
            base.Excluir();
        }

        public override bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
            {
                if (!VisualizarRegistros("Tela"))
                    return false;
            }

            _repositorioTarefa.Ordenar();
            Console.WriteLine("1 = pendentes\n" +
                "2 = completas");


            switch (Console.ReadLine())
            {
                case "1":

                    MostrarTitulo("Vizualizando Tarefas Pendentes");

                    foreach (Tarefa entidade in _repositorioTarefa.SelecionarTodos())
                    {

                        if (entidade.porcentualConclusao != 1)                       
                            Console.WriteLine(entidade.ToString() + Environment.NewLine);
                        
                        
                    }
                    Console.ReadLine();
                    break;
                case "2":
                    MostrarTitulo("Vizualizando Tarefas Completas");

                     foreach (Tarefa entidade in _repositorioTarefa.SelecionarTodos())
                     {
                        if (entidade.porcentualConclusao == 1)                        
                            Console.WriteLine(entidade.ToString() + Environment.NewLine);
                            
                        
                     }
                    Console.ReadLine();
                    break;


                    

            }
            return true;
        }

        private Tarefa ObterTarefa(bool editar)
        {
            string titulo;
            int numero = 0;
            Prioridade prioridade;
            DateTime datafim;
            DateTime datainicio;

            if (editar)
            {
                numero = 0;
                do
                {
                    Console.WriteLine("Prioridade da tarefa \n" +
                        "1 = Alta\n" +
                        "2 = Normal\n" +
                        "3 = Baixa\n");
                } while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 3 || numero < 1);
                prioridade = Prioridade.Baixa;
                switch (numero)
                {
                    case 1:
                        prioridade = Prioridade.Alta;
                        break;
                    case 2:
                        prioridade = Prioridade.Media;
                        break;
                    case 3:
                        prioridade = Prioridade.Baixa;
                        break;
                }
                Console.WriteLine("titulo");
                titulo = Console.ReadLine();

                return new Tarefa(prioridade, titulo, DateTime.Now, DateTime.Now);
            }

            numero = 0;
            do
            {
                Console.WriteLine("Prioridade da tarefa \n" +
                    "1 = Alta\n" +
                    "2 = Normal\n" +
                    "3 = Baixa\n");
            } while (!(int.TryParse(Console.ReadLine(), out numero)) || numero > 3 || numero < 1);
            prioridade = Prioridade.Baixa;
            switch (numero)
            {
                case 1:
                    prioridade = Prioridade.Alta;
                    break;
                case 2:
                    prioridade = Prioridade.Media;
                    break;
                case 3:
                    prioridade = Prioridade.Baixa;
                    break;
            }
            Console.WriteLine("titulo");
            titulo = Console.ReadLine();
            do
            {
                Console.WriteLine("data de inicio");
            } while (!(DateTime.TryParse(Console.ReadLine(), out datainicio)));
            do
            {
                Console.WriteLine("data de conclusão");
            } while (!(DateTime.TryParse(Console.ReadLine(), out datafim)));
            Tarefa t = new Tarefa(prioridade, titulo, datainicio, datafim);
            t.porcentualConclusao = 1;
            return t;

        }
    }
}
