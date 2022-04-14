using eAgenda1._0.Compartilhado;
using System;

namespace eAgenda1._0.ModuloContato
{
    public class RepositorioContato : RepositorioBase<Contato>
    {
        public void VisualizarAgrupadoPorCargo()
        {

        }

        public Contato PegarRegistro(int id)
        {
            return registros.Find(x=>x.id == id) ;
        }
    }
}
