using System;
using System.Collections.Generic;
using Dio.projUm.Interfaces;

namespace Dio.projUm
{
    public class SerieRepositorioo : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
           listaSerie[id] = objeto; 
        } 

        public void Exclui(int id)
        {
            listaSerie[id].Excluir(); // ele nao vai excluir, so vai marca como vdd o id marcado
            //metodo excluir esta na classe serie
        }



        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count; // ele vai contando ja que é baseado em 0
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}