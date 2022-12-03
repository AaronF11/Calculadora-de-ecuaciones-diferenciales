using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //---------------------------------------------------------------------
    //Clase que deriva.
    // CMJL. Jorge Luis Cruz Macias. 28/11/2022
    // JAGL. Juan Antonio Gil Lopez.
    //---------------------------------------------------------------------

    public class CDerivada
    {
        //----------------------------------
        // Atributos
        //----------------------------------

        //Atributos 
        public double Coeficiente;
        public double Exponente;
        public string Variable;

        //Atributos del segundo termino 
        public int Coeficiente2;
        public int Exponente2;
        public string Variable2;

        //-------------------------
        // Constructor
        //-------------------------
        public CDerivada()
        {

        }

        //-----------------------------------------------------//
        //Método que resuelve derivada: Potencia f(x)=nx^n-1
        //-----------------------------------------------------//
        public string Derivar()
        {
            //En estas variables se aguardan los datos una vez realizadas las operaciones básicas 
            double Coeficiente;
            double Exponente;
            String Variable;

            String ResultadoDerivada;

            //Se realizan las operaciones básicas 
            Coeficiente = this.Exponente * this.Coeficiente;
            Exponente = this.Exponente - 1;
            Variable = this.Variable;

            //Aguarda el resultado final de la derivada 
            return ResultadoDerivada = Coeficiente.ToString() + Variable + "^" + Exponente.ToString();
        }

        //-----------------------------------------------------//
        //Método que resuelve derivada...
        //-----------------------------------------------------//
        public void Derivar2()
        {
            //variables 
            int TerminoUno;
            int TerminoDos;

            int Resultado;
            int resultado2;

            double Coeficiente;
            double Exponente;
            String Variable;

            //Segundo término 
            int Coeficiente2;
            int Exponente2;
            String Variable2;

            string ResultadoExpDerivada;

            //Se deriva lo de adentro
            Coeficiente = this.Coeficiente * this.Exponente;
            Exponente = this.Exponente - 1;

            Coeficiente2 = this.Coeficiente2 * this.Exponente2;
            Exponente2 = this.Exponente2;

            ResultadoExpDerivada = Convert.ToString(this.Exponente * Coeficiente2);
        }
        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 2: "y = ax es igual a y = a" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public void Formula2()
        {
            //-----------------------------------------------
            //Ejemplo de esta formula: f(x)=7x  ->  f(x)=7
            //-----------------------------------------------

            //variables 
            string Funcion;

            //De la funcion se tomaria el coeficiente, exponente y variable

            Coeficiente = this.Coeficiente;
            Exponente = this.Exponente;
            Variable = this.Variable;

            string ResultadoDeFuncion;

            //Formula:

            if(Coeficiente >= 1)
            {
                if (Variable != null && Exponente == 1)
                {
                    ResultadoDeFuncion = Convert.ToString(Coeficiente);
                }
            }
        }
        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 4: "y = x es igual a y = 1" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public void Formula4()
        {
            //-----------------------------------------------
            //Ejemplo de esta formula: f(x)=x  ->  f(x)=1
            //-----------------------------------------------

            //variables 
            string Funcion;

            //De la funcion se tomaria el coeficiente, exponente y variable

            Coeficiente = this.Coeficiente;
            Exponente = this.Exponente;
            Variable = this.Variable;

            string ResultadoDeFuncion;

            //Formula:

            if (Coeficiente == 1)
            {
                if (Variable != null && Exponente == 1)
                {
                    ResultadoDeFuncion = Convert.ToString(Coeficiente);
                }
            }
        }
        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 5: "y = v^n es igual a y = n * v^n-1 * v^1" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public void Formula5()
        {
            //-----------------------------------------------
            //Ejemplo de esta formula: (Metodo en proceso)
            //-----------------------------------------------

            //variables 
            string Funcion;

            //De la funcion se tomaria el coeficiente, exponente y variable

            Coeficiente = this.Coeficiente;
            Exponente = this.Exponente;
            Variable = this.Variable;

            string ResultadoDeFuncion;

            //Formula:
            /* (Se ocupa de la formula 3 que pronto realizara mi compañero)
            if (Coeficiente == 1)
            {
                if (Variable != null && Exponente == 1)
                {
                    ResultadoDeFuncion = Convert.ToString(Coeficiente);
                }
            }
            */
        }

    }
}


