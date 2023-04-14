using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : Repositorio
    {
        public void EditarStatus(Emprestimo emprestimoParaEditar)
        {
            emprestimoParaEditar.pendente = false;
        }

        public Emprestimo SelecionarEmprestimoPeloId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo e in listaRegistros)
            {
                if (e.id == id)
                {
                    emprestimo = e;
                    break;
                }
            }

            return emprestimo;
        }

        public bool ExisteEmprestimosNaData(string tipoDeData, string dataVerificar)
        {
            bool existeEmprestimosNaData = false;

            // Verifica se existe pelo menos um emprestimo realizado na data informada
            foreach (Emprestimo e in listaRegistros)
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
