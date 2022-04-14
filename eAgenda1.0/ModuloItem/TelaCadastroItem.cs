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

        public  RepositorioItem _repositorioItem;

        public TelaCadastroItem(RepositorioItem repositorioItem) : base("Cadastro de itens", repositorioItem)
        {

            _repositorioItem = repositorioItem;
        }
        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");
            Console.WriteLine("Digite 5 para concluir um item");

            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;
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

                Notificador.ApresentarMensagem("item concluido com sucesso", TipoMensagem.Sucesso);

            else
                Notificador.ApresentarMensagem("nao encontrado", TipoMensagem.Erro);
        }
    }
}
