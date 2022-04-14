using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAgenda1._0.Compartilhado;

namespace eAgenda1._0.ModuloItem
{
    public class Item : EntidadeBase
    {
        public bool concluido;
        public Item(string descricao)
        {
            Descricao = descricao;
            concluido = false;
        }

        public string Descricao { get; set; }

        public override string ToString()
        {
            return "id :" + id + 
                "\nDescrição :" + Descricao +
                "\nConcluido: " + concluido;
        }    
    }
}
