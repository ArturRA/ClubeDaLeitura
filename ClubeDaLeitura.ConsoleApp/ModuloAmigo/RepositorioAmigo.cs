using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class RepositorioAmigo : Repositorio
    {
        public void Editar(Amigo amigoParaEditar, Amigo amigoAtualizada)
        {
            amigoParaEditar.nome = amigoAtualizada.nome;
            amigoParaEditar.nomeResponsavel = amigoAtualizada.nomeResponsavel;
            amigoParaEditar.telefone = amigoAtualizada.telefone;
            amigoParaEditar.endereco = amigoAtualizada.endereco;
        }

        public Amigo SelecionarAmigoPeloId(int id)
        {
            Amigo amigo = null;

            foreach (Amigo a in listaRegistros)
            {
                if (a.id == id)
                {
                    amigo = a;
                    break;
                }
            }

            return amigo;
        }

        public void Excluir(Amigo amigoParaExcluir)
        {
            listaRegistros.Remove(amigoParaExcluir);
        }
    }
}
