using eAgenda1._0.Compartilhado;
using eAgenda1._0.ModuloItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda1._0.ModuloContato
{
    public class Contato : EntidadeBase
    {
        public Contato(string nome, string email, string telefone, string cargo, string empresa)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Cargo = cargo;
            Empresa = empresa;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }

        public override string ToString()
        {
            return "id :" + id + "\n" +
                "Nome :" + Nome + "\n" +
                "E-mail :" + Email + "\n" +
                "Empresa :" + Empresa +"\n" +
                "Cargo :" + Cargo + "\n" +
                "Telefone :" + Telefone + "\n";
        }
    }
}
