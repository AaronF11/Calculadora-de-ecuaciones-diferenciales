using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Mrtodos
{
    //----------------------------------------------------//
    // Clase que répresenta el método para ecuaciones
    // por factor integrante
    //----------------------------------------------------//
    public class CFactorIntegrante : CMetodo
    {
        //-------------------------
        // Atributos
        //-------------------------

        //-------------------------
        // Constructor
        //-------------------------
        public CFactorIntegrante(string Ecuacion) : base(Ecuacion)
        {
        }

        public override void PartirEcuacion()
        {
            throw new NotImplementedException();
        }

        public override string ResolverEcuacion()
        {
            throw new NotImplementedException();
        }

        public override DialogResult ValidarEcuacion()
        {
            Regex ExprED;

            ExprED = new Regex("dx\\/dy(-|\\+)[a-z]{1,}=[0-9]{1,}(-|\\+)[0-9]*[a-z]{1,}");

            if (ExprED.IsMatch(Ecuacion))
            {
                return DialogResult.OK;
            }

            return DialogResult.No;
        }
    }
}
