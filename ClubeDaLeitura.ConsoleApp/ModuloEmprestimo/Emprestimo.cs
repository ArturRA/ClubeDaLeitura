using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo
    {
        public int id;
        public Amigo amigo;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;
        public bool pendente = true;

        public string Status()
        {
            if (pendente)
                return "Pendente";
            else
                return "Quitado";
        }

    }
}
