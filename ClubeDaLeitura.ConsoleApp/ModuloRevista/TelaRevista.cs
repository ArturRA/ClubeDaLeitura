using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class TelaRevista : Tela
    {
        private RepositorioRevista repositorioRevista = new RepositorioRevista();

        public string ApresentarMenuCadastroRevista()
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

        public void InserirNovoRevista(TelaCaixa telaCaixa)
        {

            Console.WriteLine("Cadastro de Revista\n"
                            + "Inserindo nova Revista:\n");

            if (telaCaixa.SelecionarTodaALista().EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            Revista novaRevista =   ObterInformacaoRevistaUsuario(telaCaixa);

            repositorioRevista.Inserir(novaRevista);

            ApresentarMensagemColorida("Revista inserida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void VisualizarRevistas()
        {
            Console.WriteLine("Cadastro de Revista\n"
                            + "Visualizando Revistas:\n");

            if (repositorioRevista.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarRevistas();
            Console.ReadLine();
        }

        public void EditarRevista(TelaCaixa telaCaixa)
        {
            Console.WriteLine("Cadastro de Revista\n"
                            + "Editando Revista:\n");

            if (repositorioRevista.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarRevistas();

            Revista revistaParaEditar = EncontrarRevistaNaLista();
            Revista revistaAtualizada = ObterInformacaoRevistaUsuario(telaCaixa);
            repositorioRevista.Editar(revistaParaEditar, revistaAtualizada);

            ApresentarMensagemColorida("Revista editada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ExcluirRevista()
        {
            Console.WriteLine("Cadastro de Revista\n"
                            + "Excluir Revista:\n");

            if (repositorioRevista.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma Revista cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarRevistas();

            Revista revistaParaExcluir = EncontrarRevistaNaLista();
            repositorioRevista.Excluir(revistaParaExcluir);

            ApresentarMensagemColorida("Revista excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }



        #region funções privadas
        public Revista EncontrarRevistaNaLista()
        {
            Revista revistaSelecionada = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id da Revista: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                revistaSelecionada = repositorioRevista.SelecionarRevistaPeloId(idSelecionado);

                if (revistaSelecionada == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return revistaSelecionada;
        }

        public void ListarRevistas()
        {
            ArrayList listaDeRevistas = repositorioRevista.SelecionarTodaALista();

            ApresentarMensagemColorida($"{"Id",-5}  |   {"Coleção",-10}  |   {"Numero edição",-15}  |   "
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

        public RepositorioRevista SelecionarTodaALista()
        {
            return repositorioRevista;
        }

        private Revista ObterInformacaoRevistaUsuario(TelaCaixa telaCaixa)
        {
            Revista revista = new Revista();

            telaCaixa.ListarCaixas();

            revista.caixa = telaCaixa.EncontrarCaixaNaLista();

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
