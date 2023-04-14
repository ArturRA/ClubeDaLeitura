using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo
    {
        public static string ApresentarMenuCadastroEmprestimo()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Emprestimos\n"
                            + "-->Digite 1 para Inserir um novo Emprestimo\n"
                            + "-->Digite 2 para Fazer Devolução\n"
                            + "-->Digite 3 para Visulizar os Emprestimos\n"
                            + "-->Digite 4 para Visulizar os Emprestimos de um mês\n"
                            + "-->Digite 5 para Visulizar os Emprestimos de um dia\n"
                            + "\n"
                            + "-->Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        public static void InserirNovoEmprestimo()
        {

            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Inserindo novo Emprestimo:\n");

            if (RepositorioRevista.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            if (RepositorioAmigo.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            Emprestimo novoEmprestimo = ObterInformacaoEmprestimoUsuario();

            RepositorioEmprestimo.Inserir(novoEmprestimo);

            Program.ApresentarMensagemColorida("Emprestimo inserida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void FazerDevolucao()
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Fazer Devolução:\n");

            if (RepositorioEmprestimo.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma Emprestimo cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarEmprestimos();

            Emprestimo emprestimoParaEditar = EncontrarEmprestimoNaLista();
            RepositorioEmprestimo.EditarStatus(emprestimoParaEditar);

            Program.ApresentarMensagemColorida("Revista devolvida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void VisualizarEmprestimos()
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Visualizando Emprestimos:\n");

            if (RepositorioEmprestimo.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhum Emprestimo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarEmprestimos();
            Console.ReadLine();
        }

        public static void VisualizarEmprestimosDeUmPeriodo(string tipo)
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Visualizando Emprestimos:\n");

            if (RepositorioEmprestimo.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhum Emprestimo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarEmprestimos();

            ArrayList listaDeEmprestimos = RepositorioEmprestimo.SelecionarTodaALista();

            Console.Write($"Digite o {tipo} que deseja verificar: ");
            string dataVerificar = Console.ReadLine();

            if (!RepositorioEmprestimo.ExisteEmprestimosNaData(tipo, dataVerificar))
            {
                Program.ApresentarMensagemColorida("Nenhum Emprestimo cadastrado na data informada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (Emprestimo e in listaDeEmprestimos)
                {
                    if (String.Equals(e.dataEmprestimo.ToString(tipo), dataVerificar))
                    {
                        Console.WriteLine($"{e.id,-5}  |   {e.amigo.nome,-10}  |   {e.revista.id,-10}  |   "
                                        + $"{e.revista.colecao,-15}  |   {e.dataEmprestimo.ToString("dd/MM/yyyy"),-15}  |   "
                                        + $"{e.dataDevolucao.ToString("dd/MM/yyyy"),-15}  |   {e.Status(),-10}");
                    }
                    
                }

                Console.ResetColor();
            }

            Console.ReadLine();
        }

        #region funções privadas
        private static Emprestimo EncontrarEmprestimoNaLista()
        {
            Emprestimo EmprestimoSelecionada = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id da Emprestimo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                EmprestimoSelecionada = RepositorioEmprestimo.SelecionarEmprestimoPeloId(idSelecionado);

                if (EmprestimoSelecionada == null)
                    Program.ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return EmprestimoSelecionada;
        }

        private static void ListarEmprestimos()
        {
            ArrayList listaDeEmprestimos = RepositorioEmprestimo.SelecionarTodaALista();

            Program.ApresentarMensagemColorida($"{"Id",-5}  |   {"Amigo",-10}  |   {"Revista Id",-10}  |   "
                                             + $"{"Revista coleção",-15}  |   {"Data Emprestimo",-15}  |   {"Data Devolução",-15}  |   {"Status",-5}\n"
                                             + $"".PadRight(110, '-'), ConsoleColor.Red);


            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Emprestimo e in listaDeEmprestimos)
            {
                Console.WriteLine($"{e.id,-5}  |   {e.amigo.nome,-10}  |   {e.revista.id,-10}  |   "
                                        + $"{e.revista.colecao,-15}  |   {e.dataEmprestimo.ToString("dd/MM/yyyy"),-15}  |   "
                                        + $"{e.dataDevolucao.ToString("dd/MM/yyyy"),-15}  |   {e.Status(),-10}");
            }

            Console.ResetColor();
        }

        private static Emprestimo ObterInformacaoEmprestimoUsuario()
        {
            Emprestimo emprestimo = new Emprestimo();

            TelaAmigo.ListarAmigos();
            emprestimo.amigo = TelaAmigo.EncontrarAmigoNaLista();

            TelaRevista.ListarRevistas();
            emprestimo.revista = TelaRevista.EncontrarRevistaNaLista();

            emprestimo.dataEmprestimo = DateTime.Now;

            Console.Write("Digite a data de devolução da Revista: ");
            string[] dataDevolucao = Console.ReadLine().Split("/");
            emprestimo.dataDevolucao = new DateTime(Convert.ToInt32(dataDevolucao[2]),  // Ano
                                                    Convert.ToInt32(dataDevolucao[1]),  // Mes
                                                    Convert.ToInt32(dataDevolucao[0])); // Dia

            return emprestimo;
        }
        #endregion
    }
}
