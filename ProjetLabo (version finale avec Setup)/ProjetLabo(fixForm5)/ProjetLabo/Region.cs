using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetLabo
{
    class Region
    {
        private int idRegion;
        private string nomRegion;

        //constructeur
        public Region(int idRegion, string nomRegion)
        {
            this.idRegion = idRegion;
            this.nomRegion = nomRegion;
        }

        //getters
        public int getId()
        {
            return idRegion;
        }
        public string getNom()
        {
            return nomRegion;
        }
    }
}
