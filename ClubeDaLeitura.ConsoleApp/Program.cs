using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new TelaAmigo();
            TelaCaixa telaCaixa = new TelaCaixa();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            TelaRevista telaRevista = new TelaRevista();

            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                switch (opcao)
                {
                    case "1":
                        string opcaoCadastroAmigo = telaAmigo.ApresentarMenuCadastroAmigo();

                        switch (opcaoCadastroAmigo)
                        {
                            case "1":
                                telaAmigo.InserirNovoAmigo();
                                break;
                            case "2":
                                telaAmigo.VisualizarAmigos();
                                break;
                            case "3":
                                telaAmigo.EditarAmigo();
                                break;
                            case "4":
                                telaAmigo.ExcluirCaixa();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        string opcaoCadastroCaixa = telaCaixa.ApresentarMenuCadastroCaixa();

                        switch (opcaoCadastroCaixa)
                        {
                            case "1":
                                telaCaixa.InserirNovoAmigo();
                                break;
                            case "2":
                                telaCaixa.VisualizarCaixas();
                                break;
                            case "3":
                                telaCaixa.EditarCaixa();
                                break;
                            case "4":
                                telaCaixa.ExcluirCaixa();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        string opcaoCadastroEmprestimo = telaEmprestimo.ApresentarMenuCadastroEmprestimo();

                        switch (opcaoCadastroEmprestimo)
                        {
                            case "1":
                                telaEmprestimo.InserirNovoEmprestimo(telaAmigo, telaRevista);
                                break;
                            case "2":
                                telaEmprestimo.FazerDevolucao();
                                break;
                            case "3":
                                telaEmprestimo.VisualizarEmprestimos();
                                break;
                            case "4":
                                telaEmprestimo.VisualizarEmprestimosDeUmPeriodo("MM/yyyy");
                                break;
                            case "5":
                                telaEmprestimo.VisualizarEmprestimosDeUmPeriodo("dd/MM/yyyy");
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        string opcaoCadastroRevista = telaRevista.ApresentarMenuCadastroRevista();

                        if (opcaoCadastroRevista == "s")
                            break;

                        switch (opcaoCadastroRevista)
                        {
                            case "1":
                                telaRevista.InserirNovoRevista(telaCaixa);
                                break;
                            case "2":
                                telaRevista.VisualizarRevistas();
                                break;
                            case "3":
                                telaRevista.EditarRevista(telaCaixa);
                                break;
                            case "4":
                                telaRevista.ExcluirRevista();
                                break;
                            default:
                                break;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private static string ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("Club da Leitura 1.0\n"
                            + "->Digite 1 para Cadastrar Amigos\n"
                            + "->Digite 2 para Cadastrar Caixa\n"
                            + "->Digite 3 para Cadastrar Emprestimo\n"
                            + "->Digite 4 para Cadastrar Revista\n"
                            + "\n"
                            + "->Digite s para Sair");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }


    }
}