using eAgenda1._0.Compartilhado;
using eAgenda1._0.ModuloItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda1._0.ModuloTarefa
{
    public class Tarefa : EntidadeBase, IComparable<Tarefa>
    {
        public TelaCadastroItem _telaCadastroItem;
        public RepositorioItem _repositorioItem;

        public readonly Prioridade prioridade;
        readonly DateTime readodataCriacao;
        readonly DateTime dataFim;
        public double porcentualConclusao;
        List<Item> items = new List<Item>();
        string titulo;

        public Tarefa(Prioridade prioridade, string titulo,  DateTime dataCriacao, DateTime dataFim )
        {
            Titulo = titulo;
            this.prioridade = prioridade;
            DataCriacao = dataCriacao;
            DataFim = dataFim;
            _repositorioItem = new RepositorioItem();
            _telaCadastroItem = new TelaCadastroItem(_repositorioItem);
            
        }
        public string Titulo { get; set; }
        public string Prioridade { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataFim { get; set; }
        public List<Item> Items { get; internal set; }


        public override string ToString()
        {
            return "id :" + id +
                "\ntitulo :" + Titulo +
                "\nPrioridade :" + Prioridade +            
                "\nData criação: " + DataCriacao +
                "\nData conclusão: " + DataFim +
                $"\nPercentual de conclusão: { porcentualConclusao * 100 } %";            
        }
        public int CompareTo(Tarefa other)
        {
            return other.prioridade.CompareTo(prioridade);
        }
    }
}
