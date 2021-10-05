using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;


namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie=new List<Serie>();

        

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;;
        }
        public void Exclui(int id)
        {
            listaSerie[id].Excluir();

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
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {

            return listaSerie[id];
        }
        public bool PesquisarId(int numero)
        {
            for(var i=0;i<listaSerie.Count;i++)
            {
                if(listaSerie[i].RetornaId()==numero)
                    return true;
            }
            return false;

        }
        
    }
}