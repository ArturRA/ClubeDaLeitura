using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class RepositorioRevista : Repositorio
    {
        public void Editar(Revista revistaParaEditar, Revista revistaAtualizada)
        {
            revistaParaEditar.colecao = revistaAtualizada.colecao;
            revistaParaEditar.edicao = revistaAtualizada.edicao;
            revistaParaEditar.ano = revistaAtualizada.ano;
            revistaParaEditar.caixa = revistaAtualizada.caixa;
        }

        public Revista SelecionarRevistaPeloId(int id)
        {
            Revista revista = null;

            foreach (Revista r in listaRegistros)
            {
                if (r.id == id)
                {
                    revista = r;
                    break;
                }
            }

            return revista;
        }

        public void Excluir(Revista revistaParaExcluir)
        {
            listaRegistros.Remove(revistaParaExcluir);
        }
    }
}
