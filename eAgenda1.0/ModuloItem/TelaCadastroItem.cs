using eAgenda1._0.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eAgenda1._0.ModuloItem
{
    public class TelaCadastroItem : TelaBase<RepositorioItem, Item>
    {
        public  Notificador _notificador;
        public  RepositorioItem _repositorioItem;

        public TelaCadastroItem(RepositorioItem repositorioItem, Notificador notificador ) : base("Cadastro de itens", repositorioItem)
        {
            _notificador = notificador;
            _repositorioItem = repositorioItem;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Item");
            Item novoItem = ObterItem();
            base.Inserir(novoItem);
        }

        public  void Editar()
        {
            MostrarTitulo("Editando Item");
            int id = ObterNumeroId();
            base.Editar(ObterItem(), id);
        }

        public new void Excluir()
        {
            MostrarTitulo("Excluindo Item");

            base.Excluir();
        }

        public new void VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Items");
            base.VisualizarRegistros(tipoVisualizacao);
        }


        
        private Item ObterItem()
        {
            Console.WriteLine("Digite o Nome do Item: ");
            string descricao = Console.ReadLine();

            return new Item(descricao);
        }
        public void Concluir()
        {
            if (_repositorioItem.Concluir(ObterNumeroId()))

                _notificador.ApresentarMensagem("item concluido com sucesso", TipoMensagem.Sucesso);

            else
                _notificador.ApresentarMensagem("nao encontrado", TipoMensagem.Erro);
        }
    }
}
