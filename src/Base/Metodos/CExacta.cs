using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using POO22B_GPJA;

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
        protected string dx;
        protected string dy;

        //-------------------------
        // Constructor
        //-------------------------
        public CExacta(string Ecuacion) : base(Ecuacion)
        {

        }

        public override void PartirEcuacion()
        {
            // Inicializar expresión regular para partir la ecuación
            ExprPartes = new Regex("\\(.*?\\)(dx|dy)");

            // Inicializar lista para almacenar las partes
            PartesEcuacion = new List<string>();

            // Partir la ecuación en coincidencias
            ColeccionPartesEcuacion = ExprPartes.Matches(Ecuacion);

            foreach (Match Coincidencia in ColeccionPartesEcuacion)
            {
                // Añadir partes a la lista
                PartesEcuacion.Add(Coincidencia.Value);
                
                // Información a debug
                MessageBox.Show($"Parte: {Coincidencia}");
            }

            // Guardar dx / dy
            if (PartesEcuacion[0].Contains("dx"))
            {
                dx = PartesEcuacion[0];
            }

            if (PartesEcuacion[0].Contains("dy"))
            {
                dy = PartesEcuacion[0];
            }

            if (PartesEcuacion[1].Contains("dx"))
            {
                dx = PartesEcuacion[1];
            }

            if (PartesEcuacion[1].Contains("dy"))
            {
                dy = PartesEcuacion[1];
            }

            // eliminar dx y dy de los strings

            dx = Regex.Replace(dx, "dx", "");
            dy = Regex.Replace(dy, "dy", "");

            // Mostrar variables
            MessageBox.Show($"Contenidos: {dx} {dy}");

            new CIntegral().DerivarX(dx);
        }
    }
}
