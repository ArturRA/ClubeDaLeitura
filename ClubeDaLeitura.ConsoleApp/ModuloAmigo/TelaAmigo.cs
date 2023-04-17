using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : Tela
    {
        private RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

        public string ApresentarMenuCadastroAmigo()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Amigos\n"
                            + "-->Digite 1 para Inserir um novo Amigo\n"
                            + "-->Digite 2 para Visulizar os Amigos\n"
                            + "-->Digite 3 para Editar um Amigo\n"
                            + "-->Digite 4 para Excluir um Amigo\n"
                            + "\n"
                            + "-->Digite s para voltar para o menu principal");

            string opcao = Console.ReadLine();

            Console.Clear();

            return opcao;
        }

        public void InserirNovoAmigo()
        {

            Console.WriteLine("Cadastro de Amigo\n"
                            + "Inserindo novo Amigo:\n");

            Amigo novoAmigo = ObterInformacaoAmigoUsuario();

            repositorioAmigo.Inserir(novoAmigo);

            ApresentarMensagemColorida("Amigo inserido com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void VisualizarAmigos()
        {
            Console.WriteLine("Cadastro de Amigo\n"
                            + "Visualizando Amigos:\n");

            if (repositorioAmigo.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarAmigos();
            Console.ReadLine();
        }

        public void EditarAmigo()
        {
            Console.WriteLine("Cadastro de Amigo\n"
                            + "Editando Amigo:\n");

            if (repositorioAmigo.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarAmigos();

            Amigo amigoParaEditar = EncontrarAmigoNaLista();
            Amigo amigoAtualizada = ObterInformacaoAmigoUsuario();
            repositorioAmigo.Editar(amigoParaEditar, amigoAtualizada);

            ApresentarMensagemColorida("Amigo editado com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public void ExcluirCaixa()
        {
            Console.WriteLine("Cadastro de Amigo\n"
                            + "Excluir Amigo:\n");

            if (repositorioAmigo.EstaVazio())
            {
                ApresentarMensagemColorida("Nenhum amigo cadastrado!", ConsoleColor.DarkYellow);
                Console.ReadLine();
                return;
            }

            ListarAmigos();

            Amigo amigoParaExcluir = EncontrarAmigoNaLista();
            repositorioAmigo.Excluir(amigoParaExcluir);

            ApresentarMensagemColorida("Amigo excluído com sucesso!", ConsoleColor.Green);
            Console.ReadLine();
        }

        public Amigo EncontrarAmigoNaLista()
        {
            Amigo amigoSelecionado = null;
            int idSelecionado;
            while (true)
            {
                Console.Write("Digite o Id do Amigo: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                amigoSelecionado = repositorioAmigo.SelecionarAmigoPeloId(idSelecionado);

                if (amigoSelecionado == null)
                    ApresentarMensagemColorida("Id inválido, tente novamente", ConsoleColor.Red);
                else
                    break;
            }

            return amigoSelecionado;
        }

        public void ListarAmigos()
        {
            ArrayList listaDeAmigos = repositorioAmigo.SelecionarTodaALista();

            ApresentarMensagemColorida($"{"Id",-5}  |   {"Nome",-15}  |   {"Nome Responsavel",-20}  |   "
                                             + $"{"Telefone",-20}  |   {"Endereço",-20}\n"
                                              + "".PadRight(100, '-'), ConsoleColor.Red);


            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Amigo a in listaDeAmigos)
            {
                Console.WriteLine($"{a.id,-5}  |   {a.nome,-15}  |   {a.nomeResponsavel,-20}  |   "
                                             + $"{a.telefone,-20}  |   {a.endereco,-20}");
            }

            Console.ResetColor();
        }

        public RepositorioAmigo SelecionarRepositorio()
        {
            return repositorioAmigo;
        }

        #region funções privadas
        private Amigo ObterInformacaoAmigoUsuario()
        {
            Amigo amigo = new Amigo();

            Console.Write("Digite o nome do Amigo: ");
            amigo.nome = Console.ReadLine();

            Console.Write("Digite o nome do responsavel do Amigo: ");
            amigo.nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do Amigo: ");
            amigo.telefone = Console.ReadLine();

            Console.Write("Digite o endereço do Amigo: ");
            amigo.endereco = Console.ReadLine();

            return amigo;
        }
        #endregion
    }
}
