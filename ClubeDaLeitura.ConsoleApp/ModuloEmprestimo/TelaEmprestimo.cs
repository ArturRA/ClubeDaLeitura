using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class TelaEmprestimo : Tela
    {
        private RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();

        public string ApresentarMenuCadastroEmprestimo()
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

        public void InserirNovoEmprestimo(TelaAmigo telaAmigo, TelaRevista telaRevista)
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Inserindo novo Emprestimo:\n");

            if (telaRevista.SelecionarTodaALista().EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            if (telaAmigo.SelecionarTodaALista().EstaVazio())
            {
                ApresentarMensagemColorida("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            Emprestimo novoEmprestimo = ObterInformacaoEmprestimoUsuario(telaAmigo, telaRevista);

            repositorioEmprestimo.Inserir(novoEmprestimo);

            ApresentarMensagemColorida("Emprestimo inserida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void FazerDevolucao()
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Fazer Devolução:\n");

            if (repositorioEmprestimo.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma Emprestimo cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarEmprestimos();

            Emprestimo emprestimoParaEditar = EncontrarEmprestimoNaLista();
            repositorioEmprestimo.EditarStatus(emprestimoParaEditar);

            ApresentarMensagemColorida("Revista devolvida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void VisualizarEmprestimos()
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Visualizando Emprestimos:\n");

            if (repositorioEmprestimo.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhum Emprestimo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarEmprestimos();
            Console.ReadLine();
        }

        public void VisualizarEmprestimosDeUmPeriodo(string tipo)
        {
            Console.WriteLine("Cadastro de Emprestimo\n"
                            + "Visualizando Emprestimos:\n");

            if (repositorioEmprestimo.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhum Emprestimo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarEmprestimos();

            ArrayList listaDeEmprestimos = repositorioEmprestimo.SelecionarTodaALista();

            Console.Write($"Digite o {tipo} que deseja verificar: ");
            string dataVerificar = Console.ReadLine();

            if (!repositorioEmprestimo.ExisteEmprestimosNaData(tipo, dataVerificar))
            {
                ApresentarMensagemColorida("Nenhum Emprestimo cadastrado na data informada!", ConsoleColor.DarkYellow);
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
        private Emprestimo EncontrarEmprestimoNaLista()
        {
            Emprestimo EmprestimoSelecionada = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id da Emprestimo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                EmprestimoSelecionada = repositorioEmprestimo.SelecionarEmprestimoPeloId(idSelecionado);

                if (EmprestimoSelecionada == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return EmprestimoSelecionada;
        }

        private void ListarEmprestimos()
        {
            ArrayList listaDeEmprestimos = repositorioEmprestimo.SelecionarTodaALista();

            ApresentarMensagemColorida($"{"Id",-5}  |   {"Amigo",-10}  |   {"Revista Id",-10}  |   "
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

        private Emprestimo ObterInformacaoEmprestimoUsuario(TelaAmigo telaAmigo, TelaRevista telaRevista)
        {
            Emprestimo emprestimo = new Emprestimo();

            telaAmigo.ListarAmigos();
            emprestimo.amigo = telaAmigo.EncontrarAmigoNaLista();

            telaRevista.ListarRevistas();
            emprestimo.revista = telaRevista.EncontrarRevistaNaLista();

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
