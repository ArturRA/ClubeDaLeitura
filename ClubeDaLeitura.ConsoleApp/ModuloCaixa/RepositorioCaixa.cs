using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class RepositorioCaixa
    {
        private static int id = 1;

        private static ArrayList listaCaixas = new ArrayList();

        public static void Inserir(Caixa caixa)
        {
            caixa.id = id;
            listaCaixas.Add(caixa);
            id++;
        }
        public static void Editar(Caixa caixaParaEditar, Caixa caixaAtualizada)
        {
            caixaParaEditar.cor = caixaAtualizada.cor;
            caixaParaEditar.etiqueta = caixaAtualizada.etiqueta;
        }

        public static ArrayList SelecionarTodaALista()
        {
            return listaCaixas;
        }

        public static Caixa SelecionarCaixaPeloId(int id)
        {
            Caixa caixa = null;

            foreach (Caixa c in listaCaixas)
            {
                if (c.id == id)
                {
                    caixa = c;
                    break;
                }
            }

            return caixa;
        }

        public static void Excluir(Caixa caixaParaExcluir)
        {
            listaCaixas.Remove(caixaParaExcluir);
        }

        public static bool EstaVazio()
        {
            if (listaCaixas.Count == 0)
                return true;
            else
                return false;
        }
    }
}
