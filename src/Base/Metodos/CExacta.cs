using Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos;
using Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

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
        protected List<string> dxIntegrados;
        protected List<string> dyIntegrados;

        protected MatchCollection dxCoincidencia;
        protected MatchCollection dyCoincidencia;


        //-------------------------
        // Constructor
        //-------------------------
        public CExacta(string Ecuacion) : base(Ecuacion)
        {
            // Inicializar regex para monomios
            ExprMonomios = new Regex("[0-9]*[a-z]*\\^?[0-9]*");
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
            foreach (Match Coincidencia in dxCoincidencia)
            {
                dxMonomios.Add(Coincidencia.Value);
            }

            // Obtener constanes de dy
            foreach (Match Coincidencia in dyCoincidencia)
            {
                dyMonomios.Add(Coincidencia.Value);
            }

            // Eliminar entradas vacias :D
            dxMonomios = dxMonomios.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            dyMonomios = dyMonomios.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
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
        }

        public override string ResolverEcuacion()
        {
            // Pasos para resolver la ED

            // Validar si la ecuación es exacta
            // Llamar el método validar ecuacion en la GUI

            // Obtener signos 
            GuardarSignos();

            // Inicializar lista para guardar los monomios integrados
            dxIntegrados = new List<string>();
            dyIntegrados = new List<string>();

            // Integrar cada monomio presente en dx
            foreach (string monomio in dxMonomios)
            {
                Debug.Print($"{monomio}");

                if (!monomio.Contains("x"))
                {
                    dxIntegrados.Add(CIntegral.IntegracionInsertarVariable(monomio, "x"));
                }
                else
                {
                    dxIntegrados.Add(CIntegral.Integrar(monomio));
                }
            }

            // Integrar cada monomio presente en dy
            foreach (string monomio in dyMonomios)
            {
                Debug.Print($"{monomio}");

                if (!monomio.Contains("y"))
                {
                    dyIntegrados.Add(CIntegral.IntegracionInsertarVariable(monomio, "y"));
                }
                else
                {
                    dyIntegrados.Add(CIntegral.Integrar(monomio));
                }
            }

            // Para debug solamente
            foreach (string MonomioIntegrado in dxIntegrados) { Debug.Print($"dx: {MonomioIntegrado}"); }
            foreach (string MonomioIntegrado in dyIntegrados) { Debug.Print($"dy: {MonomioIntegrado}"); }

            string IMdx;
            string INdy;

            string IDIMdx;

            IMdx = $"{dxIntegrados[0]}{Signos[0]}{dxIntegrados[1]}";
            IDIMdx = CIntegral.IntegracionInsertarVariable(CDerivada.DerivacionVariableA(dxIntegrados[0], "y"), "y");
            INdy = "";

            if (IDIMdx == dxIntegrados[0])
            {
                INdy = $"{Signos[2]}{dyIntegrados[1]}";
            }
            else
            {
                INdy = $"{Signos[1]}{dyIntegrados[0]}{Signos[2]}{dyIntegrados[1]}";
            }

            Debug.Print($"IMdx: {IMdx}, INdy: {INdy}, IDIMdx: {IDIMdx}");

                return $"{IMdx}{INdy}+C";
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

            foreach (string monomio in dxMonomios)
            {
                if (monomio.Contains("y"))
                {
                    // Derivar monomio respecto a la variable y
                    Mdy += $" {CDerivada.DerivacionPotencia(monomio, "y")}";
                }
            }

            foreach (string monomio in dyMonomios)
            {
                if (monomio.Contains("x"))
                {
                    // Derivar monomio respecto a la variable x
                    Ndx += $" {CDerivada.DerivacionPotencia(monomio, "x")}";
                }
            }

            Debug.Print($"Mdy: {Mdy}, Ndx: {Ndx}");

            if (Mdy == Ndx)
            {
                return DialogResult.OK;
            }

            return DialogResult.No;
        }
    }
}
