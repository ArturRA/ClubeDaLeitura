using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo
    {
        private static int id = 1;

        private static ArrayList listaEmprestimos = new ArrayList();

        public static void Inserir(Emprestimo emprestimo)
        {
            emprestimo.id = id;
            listaEmprestimos.Add(emprestimo);
            id++;
        }
        public static void EditarStatus(Emprestimo emprestimoParaEditar)
        {
            emprestimoParaEditar.pendente = false;
        }

        public static ArrayList SelecionarTodaALista()
        {
            return listaEmprestimos;
        }

        public static Emprestimo SelecionarEmprestimoPeloId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo e in listaEmprestimos)
            {
                if (e.id == id)
                {
                    emprestimo = e;
                    break;
                }
            }

            return emprestimo;
        }

        public static bool EstaVazio()
        {
            if (listaEmprestimos.Count == 0)
                return true;
            else
                return false;
        }

        public static bool ExisteEmprestimosNaData(string tipoDeData, string dataVerificar)
        {
            bool existeEmprestimosNaData = false;

            // Verifica se existe pelo menos um emprestimo realizado na data informada
            foreach (Emprestimo e in listaEmprestimos)
            {
                if (String.Equals(e.dataEmprestimo.ToString(tipoDeData), dataVerificar))
                {
                    existeEmprestimosNaData = true;
                    break;
                }
            }



            return existeEmprestimosNaData;
        }
    }
}
