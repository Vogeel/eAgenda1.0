using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda1._0.Compartilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase 
    {
        protected readonly List<T> registros;

        protected int contadorId;

       
        public RepositorioBase()
        {
            registros = new List<T>();
        }

        public virtual string Inserir(T entidade)
        {
            entidade.id = ++contadorId;

            registros.Add(entidade);

            return "REGISTRO_VALIDO";
        }

        public virtual bool Editar(int idSelecionado, T novaEntidade)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.id)
                {
                    novaEntidade.id = entidade.id;

                    int posicaoParaEditar = registros.IndexOf(entidade);
                    registros[posicaoParaEditar] = novaEntidade;

                    return true;
                }
            }

            return false;
        }
      
        public virtual bool Excluir(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.id)
                {
                    registros.Remove(entidade);
                    return true;
                }
            }
            return false;
        }

        

        public T SelecionarRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
            {
                if (idSelecionado == entidade.id)
                    return entidade;
            }

            return null;
        }

       

        public List<T> SelecionarTodos()
        {
            return registros;
        }

        

        public bool ExisteRegistro(int idSelecionado)
        {
            foreach (T entidade in registros)
                if (idSelecionado == entidade.id)
                    return true;

            return false;
        }

        
    
}
}
