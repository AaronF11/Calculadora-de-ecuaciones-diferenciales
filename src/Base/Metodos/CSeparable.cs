using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Mrtodos
{
    //-------------------------------------------------------------//
    // Clase que contiene el método para ecuaciones separables
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
            // Inicializar regex para monomios
            ExprMonomios = new Regex("[0-9]*[a-z]\\^*[0-9]*\\/*[0-9]*");
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

            // Eliminar dx y dy de los strings
            dx = Regex.Replace(dx, "dx", "");
            dy = Regex.Replace(dy, "dy", "");

            // Mostrar variables
            MessageBox.Show($"Contenidos: {dx} {dy}");
        }

        public override DialogResult ValidarEcuacion()
        {
            throw new NotImplementedException();
        }

        public override string ResolverEcuacion()
        {
            throw new NotImplementedException();
        }
    }
}
