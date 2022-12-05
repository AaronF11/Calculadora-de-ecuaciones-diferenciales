using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Mrtodos
{
    //----------------------------------------------------------//
    // Clase que contiene el método para ecuaciones exactas.
    //
    // Integrantes:
    // Jorge Antonio Macías Zambrano.
    //----------------------------------------------------------//
    public class CExacta : CMetodo
    {
        //-------------------------
        // Atributos
        //-------------------------
        protected CDerivada Derivada;
        protected CIntegral Integral;
        protected List<string> dxMonomios;
        protected List<string> dyMonomios;

        protected MatchCollection dxCoincidencia;
        protected MatchCollection dyCoincidencia;


        //-------------------------
        // Constructor
        //-------------------------
        public CExacta(string Ecuacion) : base(Ecuacion)
        {
            // Inicializar regex para monomios
            ExprMonomios = new Regex("[0-9]*[a-z]\\^*[0-9]*\\/*[0-9]*");
        }

        public void ObtenerMonomios()
        {
            // Inicializar lista de constantes
            dxMonomios = new List<string>();
            dyMonomios = new List<string>();

            // Limpiar listas
            dxMonomios.Clear();
            dyMonomios.Clear();

            // Obtener constantes
            dxCoincidencia = ExprMonomios.Matches(dx);
            dyCoincidencia = ExprMonomios.Matches(dy);

            // Obtener constantes de dx
            foreach(Match Coincidencia in dxCoincidencia)
            {
                dxMonomios.Add(Coincidencia.Value);
                MessageBox.Show(Coincidencia.Value);
            }

            // Obtener constanes de dy
            foreach(Match Coincidencia in dyCoincidencia)
            {
                dyMonomios.Add(Coincidencia.Value); 
                MessageBox.Show(Coincidencia.Value);
            }

            //MessageBox.Show(CDerivada.Derivar(dxMonomios[0]));
            
            //MessageBox.Show(Integral.Integrar(dxMonomios[0])); Comentado en lo que se resuelve xd
            
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

        public override string ResolverEcuacion()
        {
            // Pasos para resolver la ED

            // Validar si la ecuación es exacta
            // Llamar el método validar ecuacion en la GUI

            // Acomodar M y N que son Mdx y Ndy
            string IntegralMdx;


            return $"";
        }

        public override DialogResult ValidarEcuacion()
        {
            // Pasos para comprobar la ED

            // Agarrar los monomios presentes en dx/M
            // y derivarlos respecto a y e ignorar aquellas variables que no sean y

            // Agarrar los monomios presentes en dy/N
            // y derivarlos respecto a x e ignorar aquellas variables que no sean y

            // Meter los resultados en un string de cada lado
            // para posteriormente comprobar si el valor es identico
            // si no retornar en el dialog result como no valido

            // return DialogResult.No;

            // o caso contrario 

            // return DialogResult.Ok;

            string Mdy;
            string Ndx;

            Mdy = "";
            Ndx = "";

            foreach(string monomio in dxMonomios)
            {
                if (monomio.Contains("y"))
                {
                    // Derivar monomio respecto a la variable y
                    Mdy = CDerivada.DerivacionPotencia(monomio);
                }
            }

            foreach(string monomio in dyMonomios)
            {
                if (monomio.Contains("x"))
                {
                    // Derivar monomio respecto a la variable x
                    Ndx = CDerivada.DerivacionPotencia(monomio);
                }
            }

            if (Mdy == Ndx)
            {
                return DialogResult.OK;
            }

            return DialogResult.No;
        }
    }
}
