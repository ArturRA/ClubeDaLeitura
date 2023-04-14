using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class RepositorioAmigo
    {
        private static int id = 1;

        private static ArrayList listaAmigos = new ArrayList();

        public static void Inserir(Amigo amigo)
        {
            amigo.id = id;
            listaAmigos.Add(amigo);
            id++;
        }
        public static void Editar(Amigo amigoParaEditar, Amigo amigoAtualizada)
        {
            amigoParaEditar.nome = amigoAtualizada.nome;
            amigoParaEditar.nomeResponsavel = amigoAtualizada.nomeResponsavel;
            amigoParaEditar.telefone = amigoAtualizada.telefone;
            amigoParaEditar.endereco = amigoAtualizada.endereco;
        }

        public static ArrayList SelecionarTodaALista()
        {
            return listaAmigos;
        }

        public static Amigo SelecionarAmigoPeloId(int id)
        {
            Amigo amigo = null;

            foreach (Amigo a in listaAmigos)
            {
                if (a.id == id)
                {
                    amigo = a;
                    break;
                }
            }

            return amigo;
        }

        public static void Excluir(Amigo amigoParaExcluir)
        {
            listaAmigos.Remove(amigoParaExcluir);
        }

        public static bool EstaVazio()
        {
            if (listaAmigos.Count == 0)
                return true;
            else
                return false;
        }
    }
}
