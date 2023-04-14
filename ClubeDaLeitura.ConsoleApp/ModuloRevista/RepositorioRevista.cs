using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class RepositorioRevista
    {
        private static int id = 1;

        private static ArrayList listaRevistas = new ArrayList();

        public static void Inserir(Revista revista)
        {
            revista.id = id;
            listaRevistas.Add(revista);
            id++;
        }
        public static void Editar(Revista revistaParaEditar, Revista revistaAtualizada)
        {
            revistaParaEditar.colecao = revistaAtualizada.colecao;
            revistaParaEditar.edicao = revistaAtualizada.edicao;
            revistaParaEditar.ano = revistaAtualizada.ano;
            revistaParaEditar.caixa = revistaAtualizada.caixa;
        }

        public static ArrayList SelecionarTodaALista()
        {
            return listaRevistas;
        }

        public static Revista SelecionarRevistaPeloId(int id)
        {
            Revista revista = null;

            foreach (Revista r in listaRevistas)
            {
                if (r.id == id)
                {
                    revista = r;
                    break;
                }
            }

            return revista;
        }

        public static void Excluir(Revista revistaParaExcluir)
        {
            listaRevistas.Remove(revistaParaExcluir);
        }

        public static bool EstaVazio()
        {
            if (listaRevistas.Count == 0)
                return true;
            else
                return false;
        }
    }
}
