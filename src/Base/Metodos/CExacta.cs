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
        
        //-------------------------
        // Constructor
        //-------------------------
        public CExacta(string Ecuacion) : base(Ecuacion)
        {
        }

        public void ObtenerConstantes()
        {
            // Inicializar lista de constantes
            dxConstantes = new List<string>();
            dyConstantes = new List<string>();

            // Limpiar listas
            dxConstantes.Clear();
            dyConstantes.Clear();

            // Obtener constantes
            dxCoincidencia = ExprMonomios.Matches(dx);
            dyCoincidencia = ExprMonomios.Matches(dy);

            // Obtener constantes de dx
            foreach(Match Coincidencia in dxCoincidencia)
            {
                dxConstantes.Add(Coincidencia.Value);
                MessageBox.Show(Coincidencia.Value);
            }

            // Obtener constanes de dy
            foreach(Match Coincidencia in dyCoincidencia)
            {
                dyConstantes.Add(Coincidencia.Value); 
                MessageBox.Show(Coincidencia.Value);
            }

            Integral = new CIntegral();

            //MessageBox.Show(Integral.Integrar(dxConstantes[0])); Comentado en lo que se resuelve xd
            
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

            new CIntegral().IntegrarX(dx);
        }

        public override void ResolverEcuacion()
        {
            throw new NotImplementedException();
        }

        public override DialogResult ValidarEcuacion()
        {
            // Pasos para comprobar la ED

            // Agarrar los monomios presentes en dx/M
            // y derivarlos respecto a y

            // Agarrar los monomios presentes en dy/N
            // y derivarlos respecto a x

            // Meter los resultados en un string de cada lado
            // para posteriormente comprobar si el valor es identico
            // si no retornar en el dialog result como no valido

            // return DialogResult.No;

            // o caso contrario 

            // return DialogResult.Ok;

            throw new NotImplementedException();
        }
    }
}
