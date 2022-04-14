using System;
using eAgenda1._0.Compartilhado;
using eAgenda1._0.ModuloTarefa;
using eAgenda1._0.ModuloContato;
using eAgenda1._0.ModuloCompromisso;

namespace eAgenda1._0
{
    internal class Program
    {
        private static string tipoVisualizacao;
        static void Main(string[] args)
        {

            TelaMenuPrincipal telaMenuPrincipal = new();

            while(true)
            {
                Object telaselecionada = telaMenuPrincipal.ObterTela();

                if (telaselecionada == null)
                    return;

                if(telaselecionada is TelaCadastroTarefa)
                {
                    TelaCadastroTarefa telaCadastro = (TelaCadastroTarefa)telaselecionada;
                    string opcaoselecionada = telaCadastro.MostrarOpcoes();
                    switch(opcaoselecionada)

                    {
                        case "1":
                            telaCadastro.Inserir();
                            break;
                        case "2":
                            telaCadastro.Editar();
                            break;
                        case "3":
                            telaCadastro.Excluir();
                            break;
                        case "4":
                            telaCadastro.VisualizarRegistros("tela");
                            break;
                        case "5":
                            telaCadastro.InserirItem();
                            break;
                    }
                }
                if (telaselecionada is TelaCadastroCompromisso)
                {
                    TelaCadastroCompromisso telaCadastro = (TelaCadastroCompromisso)telaselecionada;
                    string opcaoselecionada = telaCadastro.MostrarOpcoes();
                    switch (opcaoselecionada)

                    {
                        case "1":
                            telaCadastro.Inserir();
                            break;
                        case "2":
                            telaCadastro.Editar();
                            break;
                        case "3":
                            telaCadastro.Excluir();
                            break;
                        case "4":
                            telaCadastro.VisualizarRegistros("tela");
                            break;
                    }
                }
                if (telaselecionada is TelaCadastroContato)
                {
                    TelaCadastroContato telaCadastro = (TelaCadastroContato)telaselecionada;
                    string opcaoselecionada = telaCadastro.MostrarOpcoes();
                    switch (opcaoselecionada)

                    {
                        case "1":
                            telaCadastro.Inserir();
                            break;
                        case "2":
                            telaCadastro.Editar();
                            break;
                        case "3":
                            telaCadastro.Excluir();
                            break;
                        case "4":
                            telaCadastro.VisualizarRegistros("tela");
                            break;
                    }
                }
            }
        }
    }
}
