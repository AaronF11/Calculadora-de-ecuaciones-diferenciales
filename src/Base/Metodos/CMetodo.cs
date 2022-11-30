using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

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

        private string Ecuacion;
    
        private MatchCollection ColeccionSignos;
        private MatchCollection ColeccionPartesEcuacion;

        private Regex ExprSignos;
        private Regex ExprPartes;

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
                Debug.Print(Coincidencia.Value);
            }
        }
    }
}
