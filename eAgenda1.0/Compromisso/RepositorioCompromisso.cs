using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgenda1._0.Compartilhado;

namespace eAgenda1._0.ModuloCompromisso
{
    public class RepositorioCompromisso : RepositorioBase<Compromisso>
    {
        Compromisso compromisso;
        TelaCadastroCompromisso telaCadastroCompromisso;

        public void VisualizarCompromissoPassados()
        {
            if(compromisso.DataFim > DateTime.Now)
            {

            }
        }
        public void VisualizarCompromissoSemanal()
        {
           
            if(compromisso.DataFim > DateTime.Today.AddDays(7))
            {

            }
        }
        public void VisualizarCompromissoDiario()
        {
            if (compromisso.DataFim < DateTime.Today.AddDays(7))
            {
               telaCadastroCompromisso.VisualizarRegistros(compromisso.DataFim < DateTime.Today.AddDays(7))
            }
        }

    }
}
