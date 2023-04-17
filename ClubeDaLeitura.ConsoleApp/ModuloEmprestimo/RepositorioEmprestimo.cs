using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

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

        public bool ExistePendencias()
        {
            foreach (Emprestimo e in listaRegistros)
            {
                if (e.pendente)
                    return true;
            }
            return false;
        }

        public bool ExisteRevistaParaEmprestar(TelaRevista telaRevista)
        {
            foreach (Revista r in telaRevista.SelecionarRepositorio().SelecionarTodaALista())
            {
                if (PodeSerEmprestada(r))
                    return true;
            }

            return false;
        }

        public bool PodeSerEmprestada(Revista revista)
        {
            foreach (Emprestimo e in listaRegistros)
            {
                if (e.revista == revista && e.pendente)
                    return false;
            }

            return true;
        }

        internal bool ExisteAmigoParaEmprestar(TelaAmigo telaAmigo)
        {
            foreach (Amigo a in telaAmigo.SelecionarRepositorio().SelecionarTodaALista())
            {
                if (PodeFazerEmprestimo(a))
                    return true;
            }

            return false;
        }

        public bool PodeFazerEmprestimo(Amigo amigo)
        {
            foreach (Emprestimo e in listaRegistros)
            {
                if (e.amigo == amigo && e.pendente)
                    return false;
            }

            return true;
        }
    }
}
