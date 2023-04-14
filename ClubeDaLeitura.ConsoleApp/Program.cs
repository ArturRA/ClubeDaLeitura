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
            while (true)
            {
                string opcao = ApresentarMenuPrincipal();

                if (opcao == "s")
                    break;

                switch (opcao)
                {
                    case "1":
                        string opcaoCadastroAmigo = TelaAmigo.ApresentarMenuCadastroAmigo();

                        switch (opcaoCadastroAmigo)
                        {
                            case "1":
                                TelaAmigo.InserirNovoAmigo();
                                break;
                            case "2":
                                TelaAmigo.VisualizarAmigos();
                                break;
                            case "3":
                                TelaAmigo.EditarAmigo();
                                break;
                            case "4":
                                TelaAmigo.ExcluirCaixa();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        string opcaoCadastroCaixa = TelaCaixa.ApresentarMenuCadastroCaixa();

                        switch (opcaoCadastroCaixa)
                        {
                            case "1":
                                TelaCaixa.InserirNovoAmigo();
                                break;
                            case "2":
                                TelaCaixa.VisualizarCaixas();
                                break;
                            case "3":
                                TelaCaixa.EditarCaixa();
                                break;
                            case "4":
                                TelaCaixa.ExcluirCaixa();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        string opcaoCadastroEmprestimo = TelaEmprestimo.ApresentarMenuCadastroEmprestimo();

                        switch (opcaoCadastroEmprestimo)
                        {
                            case "1":
                                TelaEmprestimo.InserirNovoEmprestimo();
                                break;
                            case "2":
                                TelaEmprestimo.FazerDevolucao();
                                break;
                            case "3":
                                TelaEmprestimo.VisualizarEmprestimos();
                                break;
                            case "4":
                                TelaEmprestimo.VisualizarEmprestimosDeUmPeriodo("MM/yyyy");
                                break;
                            case "5":
                                TelaEmprestimo.VisualizarEmprestimosDeUmPeriodo("dd/MM/yyyy");
                                break;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        string opcaoCadastroRevista = TelaRevista.ApresentarMenuCadastroRevista();

                        if (opcaoCadastroRevista == "s")
                            break;

                        switch (opcaoCadastroRevista)
                        {
                            case "1":
                                TelaRevista.InserirNovoRevista();
                                break;
                            case "2":
                                TelaRevista.VisualizarRevistas();
                                break;
                            case "3":
                                TelaRevista.EditarRevista();
                                break;
                            case "4":
                                TelaRevista.ExcluirRevista();
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

        public static void ApresentarMensagemColorida(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
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