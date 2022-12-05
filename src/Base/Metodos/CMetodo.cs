using Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Metodos
{
    //+-------------------------------------------------------+//
    //| Clase que representa los atributos base               |
    //| para ser utilizados en los métodos de resolución para |
    //| ecuaciones dif.                                       |
    //+-------------------------------------------------------+//
    public abstract class CMetodo
    {
        //-------------------------
        // Atributos
        //-------------------------
        public List<string> Signos;
        public List<string> PartesEcuacion;
        
        protected List<string> Monomios;
        protected string Ecuacion;

        protected MatchCollection ColeccionSignos;
        protected MatchCollection ColeccionPartesEcuacion;

        protected Regex ExprMonomios;
        protected Regex ExprSignos;
        protected Regex ExprPartes;

        protected string dx;
        protected string dy;

        //-------------------------
        // Constructor
        //-------------------------
        public CMetodo(string Ecuacion)
        {
            this.Ecuacion = Ecuacion;
        }

        // +-------------------------------------------------------------------+
        // | Como el método parte la ecuación para ser tratada posteriormente  |
        // +-------------------------------------------------------------------+
        public abstract void PartirEcuacion();

        // +-------------------------------------------------------------------+
        // | Analiza la entrada del usuario, para validar si coincide con el   |
        // | Tipo                                                              |
        // +-------------------------------------------------------------------+
        public abstract DialogResult ValidarEcuacion();

        // +-------------------------------------------------------------------+
        // | Resuelve la ecuación del tipo requerido.                          |
        // +-------------------------------------------------------------------+
        public abstract string ResolverEcuacion();

        // +-------------------------------------------------------------------+
        // | Recoger los signos de la ecuación y almacenarlos                  |
        // +-------------------------------------------------------------------+
        public void GuardarSignos()
        {
            // Inicializar expresión regular para obtener signos
            ExprSignos = new Regex("(-|\\+)");

            // Buscar los signos en la entrada (ecuación)
            ColeccionSignos = ExprSignos.Matches(Ecuacion);

            // Inicializar lista para guardar los signos
            Signos = new List<string>();

            foreach(Match Coincidencia in ColeccionSignos)
            {
                // Añadir signos a la lista
                Signos.Add(Coincidencia.Value);
            }
        }
    }
}
