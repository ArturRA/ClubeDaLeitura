using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa : Repositorio
    {
        public void Editar(Caixa caixaParaEditar, Caixa caixaAtualizada)
        {
            caixaParaEditar.cor = caixaAtualizada.cor;
            caixaParaEditar.etiqueta = caixaAtualizada.etiqueta;
        }

        public Caixa SelecionarCaixaPeloId(int id)
        {
            Caixa caixa = null;

            foreach (Caixa c in listaRegistros)
            {
                if (c.id == id)
                {
                    caixa = c;
                    break;
                }
            }

            return caixa;
        }

        public void Excluir(Caixa caixaParaExcluir)
        {
            listaRegistros.Remove(caixaParaExcluir);
        }
    }
}
