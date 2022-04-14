using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda1._0.Compartilhado
{
    public abstract class TelaBase<RepositorioBase,T>  where T : EntidadeBase
    {

        private RepositorioBase<T> repositorio;
        protected string Titulo { get; set; }

        public TelaBase(string titulo, RepositorioBase<T> repositorio)
        {
            this.repositorio = repositorio;
            Titulo = titulo;
        }


        public virtual string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

       

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();

            Console.WriteLine(titulo);

            Console.WriteLine();
        }
        protected virtual void Excluir()// funcionaou? sim.. vai mexer? nao
        {
            
            repositorio.Excluir(ObterNumeroId());

            bool temEntidadesRegistrados = VisualizarRegistros("Pesquisando");

            if (temEntidadesRegistrados == false)
            {
                Notificador.ApresentarMensagem("Nenhum registro cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }
        }
        protected virtual void Inserir(T entidade)// funcionaou? sim.. vai mexer? nao
        {
            repositorio.Inserir(entidade);
            Notificador.ApresentarMensagem("registro cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public virtual bool VisualizarRegistros(string tipoVisualizacao)// funcionaou? sim.. vai mexer? nao
        {

            List<T> registros = repositorio.SelecionarTodos();

            if (registros.Count == 0)
            {
                Notificador.ApresentarMensagem("Nenhum registro disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (T registro in registros)
                Console.WriteLine(registro.ToString());

            Console.ReadLine();
            return true;

        }


        protected virtual void Editar(T entidade, int id)// funcionaou? sim.. vai mexer? nao
        {
            VisualizarRegistros("pesquisando");
            repositorio.Editar(id, entidade);
            bool temEntidadesRegistrados = VisualizarRegistros("Pesquisando");

            if (temEntidadesRegistrados == false)
            {
                Notificador.ApresentarMensagem("Nenhum cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }
        }
        public virtual int ObterNumeroId()// funcionaou? sim.. vai mexer? nao
        {
            int numeroId;
            do
            {

                VisualizarRegistros("pesquisando");
                Console.WriteLine("qual o id do registro");

            } while (!(int.TryParse(Console.ReadLine(), out numeroId)));
            return numeroId;
        }
        
    }
}
