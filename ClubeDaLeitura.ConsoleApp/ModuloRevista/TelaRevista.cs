using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista
    {
        public static string ApresentarMenuCadastroRevista()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Revistas\n"
                            + "-->Digite 1 para Inserir uma nova Revista\n"
                            + "-->Digite 2 para Visulizar as Revistas\n"
                            + "-->Digite 3 para Editar uma Revista\n"
                            + "-->Digite 4 para Excluir uma Revista\n"
                            + "\n"
                            + "-->Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        public static void InserirNovoRevista()
        {

            Console.WriteLine("Cadastro de Revista\n"
                            + "Inserindo nova Revista:\n");

            if (RepositorioCaixa.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            Revista novaRevista =   ObterInformacaoRevistaUsuario();

            RepositorioRevista.Inserir(novaRevista);

            Program.ApresentarMensagemColorida("Revista inserida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void VisualizarRevistas()
        {
            Console.WriteLine("Cadastro de Revista\n"
                            + "Visualizando Revistas:\n");

            if (RepositorioRevista.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarRevistas();
            Console.ReadLine();
        }

        public static void EditarRevista()
        {
            Console.WriteLine("Cadastro de Revista\n"
                            + "Editando Revista:\n");

            if (RepositorioRevista.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarRevistas();

            Revista revistaParaEditar = EncontrarRevistaNaLista();
            Revista revistaAtualizada = ObterInformacaoRevistaUsuario();
            RepositorioRevista.Editar(revistaParaEditar, revistaAtualizada);

            Program.ApresentarMensagemColorida("Revista editada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void ExcluirRevista()
        {
            Console.WriteLine("Cadastro de Revista\n"
                            + "Excluir Revista:\n");

            if (RepositorioRevista.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarRevistas();

            Revista revistaParaExcluir = EncontrarRevistaNaLista();
            RepositorioRevista.Excluir(revistaParaExcluir);

            Program.ApresentarMensagemColorida("Revista excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }



        #region funções privadas
        public static Revista EncontrarRevistaNaLista()
        {
            Revista revistaSelecionada = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id da Revista: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                revistaSelecionada = RepositorioRevista.SelecionarRevistaPeloId(idSelecionado);

                if (revistaSelecionada == null)
                    Program.ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return revistaSelecionada;
        }

        public static void ListarRevistas()
        {
            ArrayList listaDeRevistas = RepositorioRevista.SelecionarTodaALista();

            Program.ApresentarMensagemColorida($"{"Id",-5}  |   {"Coleção",-10}  |   {"Numero edição",-15}  |   "
                                             + $"{"Ano da Revista",-15}  |   {"Id da Caixa",-15}  |   {"Etiqueta da Caixa",-10}\n"
                                              + "".PadRight(100, '-'), ConsoleColor.Red);


            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Revista r in listaDeRevistas)
            {
                Console.WriteLine($"{r.id,-5}  |   {r.colecao,-10}  |   {r.edicao,-15}  |   "
                                             + $"{r.ano,-15}  |   {r.caixa.id,-15}  |   {r.caixa.etiqueta,-10}");
            }

            Console.ResetColor();
        }

        private static Revista ObterInformacaoRevistaUsuario()
        {
            Revista revista = new Revista();

            TelaCaixa.ListarCaixas();

            revista.caixa = TelaCaixa.EncontrarCaixaNaLista();

            Console.Write("Digite o nome da Coleção: ");
            revista.colecao = Console.ReadLine();

            Console.Write("Digite o numero da Edição: ");
            revista.edicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da Revista: ");
            revista.ano = Convert.ToInt32(Console.ReadLine());

            return revista;
        }
        #endregion
    }
}
