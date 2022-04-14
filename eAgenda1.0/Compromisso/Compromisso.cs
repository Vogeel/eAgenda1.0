using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgenda1._0.Compartilhado;
using eAgenda1._0.ModuloContato;

namespace eAgenda1._0.ModuloCompromisso
{
    public class Compromisso : EntidadeBase
    {
        Contato contato;
        
        public Compromisso( string assunto, string local, DateTime dataInicio, DateTime dataFim, Contato contato)
        {
            this.contato = contato;
            Assunto = assunto;
            Local = local;
            DataInicio = dataInicio;
            DataFim = dataFim;
            
        }

        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int ContatoCompromisso { get; set; }

        public override string ToString()
        {
            return "id :" + id + "\n" +
                "assunto :" + Assunto + "\n" +
                "E-mail :" + Local + "\n" +
                "ContatoCompromisso :" + contato.Nome + "\n" +
                "DataFim :" + DataFim + "\n" +
                "DataInicio :" + DataInicio + "\n";
        }
    }
}
