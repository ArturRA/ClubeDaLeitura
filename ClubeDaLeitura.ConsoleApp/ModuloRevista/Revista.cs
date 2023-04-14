using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : Entidade
    {
        public string colecao;
        public int edicao;
        public int ano;
        public Caixa caixa;
    }
}
