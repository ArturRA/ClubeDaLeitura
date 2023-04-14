using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa : Tela
    {
        private RepositorioCaixa repositorioCaixa = new RepositorioCaixa();

        public string ApresentarMenuCadastroCaixa()
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

        public void InserirNovoAmigo()
        {
            
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Inserindo nova Caixa:\n");

            Caixa novaCaixa = ObterInformacaoCaixaUsuario();

            repositorioCaixa.Inserir(novaCaixa);

            ApresentarMensagemColorida("Caixa inserida com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void VisualizarCaixas()
        {
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Visualizando Caixas:\n");

            if (repositorioCaixa.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarCaixas();
            Console.ReadLine();
        }

        public void EditarCaixa()
        {
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Editando Caixa:\n");

            if (repositorioCaixa.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarCaixas();

            Caixa caixaParaEditar = EncontrarCaixaNaLista();
            Caixa caixaAtualizada = ObterInformacaoCaixaUsuario();
            repositorioCaixa.Editar(caixaParaEditar, caixaAtualizada);

            ApresentarMensagemColorida("Caixa editada com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ExcluirCaixa()
        {
            Console.WriteLine("Cadastro de Caixa\n"
                            + "Excluir Caixa:\n");

            if (repositorioCaixa.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhuma caixa cadastrada!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarCaixas();

            Caixa caixaParaExcluir = EncontrarCaixaNaLista();
            repositorioCaixa.Excluir(caixaParaExcluir);

            ApresentarMensagemColorida("Caixa excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public Caixa EncontrarCaixaNaLista()
        {
            Caixa caixaSelecionada = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id da Caixa: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                caixaSelecionada = repositorioCaixa.SelecionarCaixaPeloId(idSelecionado);

                if (caixaSelecionada == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return caixaSelecionada;
        }

        public void ListarCaixas()
        {
            ArrayList listaDeCaixas = repositorioCaixa.SelecionarTodaALista();

            ApresentarMensagemColorida($"{"Id",-5}  |   {"Cor",-10}  |   {"Etiqueta",-15}\n"
                                              + "".PadRight(40, '-'), ConsoleColor.Red);


            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Caixa c in listaDeCaixas)
            {
                Console.WriteLine($"{c.id,-5}  |   {c.cor,-10}  |   {c.etiqueta,-15}");
            }

            Console.ResetColor();
        }

        public RepositorioCaixa SelecionarTodaALista()
        {
            return repositorioCaixa;
        }

        #region funções privadas
        private Caixa ObterInformacaoCaixaUsuario()
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
