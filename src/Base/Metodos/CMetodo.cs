using Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas;
using POO22B_GPJA;
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

        protected Regex ExprSignos;
        protected Regex ExprPartes;

        protected string dx;
        protected string dy;
        protected CDerivada Derivada;
        protected CIntegral Integral;
        protected List<string> dxMonomios;
        protected List<string> dyMonomios;

        protected Regex ExprMonomios;
        protected MatchCollection dxCoincidencia;
        protected MatchCollection dyCoincidencia;


        //-------------------------
        // Constructor
        //-------------------------
        public CMetodo(string Ecuacion)
        {
            this.Ecuacion = Ecuacion;

            // Inicializar regex para monomios
            ExprMonomios = new Regex("[0-9]*[a-z]\\^*[0-9]*\\/*[0-9]*");
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
        public abstract void ResolverEcuacion();

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

                // Información de Debug
               MessageBox.Show(Coincidencia.Value);
            }
        }
    }
}
