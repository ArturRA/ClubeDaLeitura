using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa
    {
        public static string ApresentarMenuCadastroCaixa()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Caixas\n"
                            + "-->Digite 1 para Inserir uma nova Caixa\n"
                            + "-->Digite 2 para Visulizar as Caixas\n"
                            + "-->Digite 3 para Editar uma Caixa\n"
                            + "-->Digite 4 para Excluir uma Caixa\n"
                            + "\n"
                            + "-->Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        public static void InserirNovoAmigo()
        {
            
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Inserindo nova Caixa:\n");

            Caixa novaCaixa = ObterInformacaoCaixaUsuario();

            RepositorioCaixa.Inserir(novaCaixa);

            Program.ApresentarMensagemColorida("Caixa inserida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void VisualizarCaixas()
        {
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Visualizando Caixas:\n");

            if (RepositorioCaixa.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarCaixas();
            Console.ReadLine();
        }

        public static void EditarCaixa()
        {
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Editando Caixa:\n");

            if (RepositorioCaixa.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarCaixas();

            Caixa caixaParaEditar = EncontrarCaixaNaLista();
            Caixa caixaAtualizada = ObterInformacaoCaixaUsuario();
            RepositorioCaixa.Editar(caixaParaEditar, caixaAtualizada);

            Program.ApresentarMensagemColorida("Caixa editada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static void ExcluirCaixa()
        {
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Excluir Caixa:\n");

            if (RepositorioCaixa.EstaVazio())
            {
                Program.ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarCaixas();

            Caixa caixaParaExcluir = EncontrarCaixaNaLista();
            RepositorioCaixa.Excluir(caixaParaExcluir);

            Program.ApresentarMensagemColorida("Caixa excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public static Caixa EncontrarCaixaNaLista()
        {
            Caixa caixaSelecionada = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id da Caixa: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                caixaSelecionada = RepositorioCaixa.SelecionarCaixaPeloId(idSelecionado);

                if (caixaSelecionada == null)
                    Program.ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return caixaSelecionada;
        }

        public static void ListarCaixas()
        {
            ArrayList listaDeCaixas = RepositorioCaixa.SelecionarTodaALista();

            Program.ApresentarMensagemColorida($"{"Id",-5}  |   {"Cor",-10}  |   {"Etiqueta",-15}\n"
                                              + "".PadRight(40, '-'), ConsoleColor.Red);


            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Caixa c in listaDeCaixas)
            {
                Console.WriteLine($"{c.id,-5}  |   {c.cor,-10}  |   {c.etiqueta,-15}");
            }

            Console.ResetColor();
        }

        #region funções privadas
        private static Caixa ObterInformacaoCaixaUsuario()
        {
            Caixa caixa = new Caixa();

            Console.Write("Digite a cor da Caixa: ");
            caixa.cor = Console.ReadLine();

            Console.Write("Digite a etiqueta da Caixa: ");
            caixa.etiqueta = Console.ReadLine();

            return caixa;
        }
        #endregion
    }
}
