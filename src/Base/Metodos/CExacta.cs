using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Mrtodos
{
    //----------------------------------------------------------//
    // Clase que répresenta el método para ecuaciones exactas
    //----------------------------------------------------------//
    public class CExacta : CMetodo
    {
        //-------------------------
        // Atributos
        //-------------------------

        //-------------------------
        // Constructor
        //-------------------------
        public CExacta(string Ecuacion) : base(Ecuacion)
        {

        }

        public override void PartirEcuacion()
        {
            throw new NotImplementedException();
        }
    }
}
