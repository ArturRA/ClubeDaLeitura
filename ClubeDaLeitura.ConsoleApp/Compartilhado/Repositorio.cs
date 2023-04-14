using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Repositorio
    {
        public int contadorDeId = 1;

        public ArrayList listaRegistros = new ArrayList();

        public void Inserir<T>(T entidade) where T : Entidade
        {
            entidade.id = contadorDeId;
            listaRegistros.Add(entidade);
            contadorDeId++;
        }

        //public Entidade SelecionarRevistaPeloId(int id)
        //{
        //    Entidade entidade = null;

        //    foreach (Entidade r in listaRegistros)
        //    {
        //        if (r.id == id)
        //        {
        //            entidade = r;
        //            break;
        //        }
        //    }

        //    return entidade;
        //}

        public ArrayList SelecionarTodaALista()
        {
            return listaRegistros;
        }

        public bool EstaVazio()
        {
            if (listaRegistros.Count == 0)
                return true;
            else
                return false;
        }
    }
}
