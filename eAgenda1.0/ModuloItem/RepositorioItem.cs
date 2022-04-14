using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgenda1._0.Compartilhado;

namespace eAgenda1._0.ModuloItem
{
    public class RepositorioItem : RepositorioBase<Item>
    {
        public bool Concluir(int id)
        {
            if (registros.Find(x => x.id == id) == default)
                return false;
            else
            {
                registros.Find(x => x.id == id).concluido = true;
                return true;
            }
        }
            
    }
}
