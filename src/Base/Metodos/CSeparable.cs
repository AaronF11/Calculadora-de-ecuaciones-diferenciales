using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Mrtodos
{
    //-------------------------------------------------------------//
    // Clase que répresenta el método para ecuaciones separables
    //-------------------------------------------------------------//
    public class CSeparable : CMetodo
    {
        //-------------------------
        // Atributos
        //-------------------------

        //-------------------------
        // Constructor
        //-------------------------
        public CSeparable(string Ecuacion) : base(Ecuacion)
        {
        }

        public override void PartirEcuacion()
        {
            throw new NotImplementedException();
        }

        public override void ResolverEcuacion()
        {
            throw new NotImplementedException();
        }

        public override DialogResult ValidarEcuacion()
        {
            throw new NotImplementedException();
        }
    }
}
