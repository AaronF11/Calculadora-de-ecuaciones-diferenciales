using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //---------------------------------------------------------------------
    //Clase que Deriva.
    // CMJL. Jorge Luis Cruz Macias. 28/11/2022
    // JAGL. Juan Antonio Gil Lopez.
    //---------------------------------------------------------------------

    public class CDerivada
    {
        //-------------------------
        // Constructor
        //-------------------------
        public CDerivada()
        {

        }

        //-----------------------------------------------------//
        //Método que resuelve derivada: Potencia f(x)=nx^n-1
        //-----------------------------------------------------//
        public static string Derivar(string Monomio)
        {

            //Variables Datos nesesarios para realizar derivada
            int Coeficiente;
            int Exponente;
            String Variable;
            String SignoExp;

            //Inicialización 

            Coeficiente = 0;
            Exponente = 0;
            SignoExp = "";
            Variable = "";
            //En estas variables se aguardan los datos una vez realizadas las operaciones básicas 

            int NuevoCoeficiente;  //--> Resultado de la multiplicación Exponente por coeficiente
            int REExponente;       //--> Resultado de la resta al Exponente 

            String ResultadoDerivada;//--> Contiene la cadena de caracteres la cual representa el resultado de una derivada

            //Contiene el Valor del exponente en tipo String
            String ExponenteSt;

            //Se realizan las operaciones básicas 
            NuevoCoeficiente = Exponente * Coeficiente;
            REExponente = Exponente - 1;



            //Se le asigno el valor a SignoExp
            SignoExp = "^";

            //Si el Exponente =1 , el Exponente no se pone 

            if (REExponente == 1)
            {
                ExponenteSt = Exponente.ToString();
                ExponenteSt = "";
                SignoExp = "";
            }
            //Si es diferente a 1, Si se pone exponente y se coloca el signo "^"
            else
            {
                ExponenteSt = REExponente.ToString();
                SignoExp = "^";
            }


            //Muestra el Resultado
            return ResultadoDerivada = Coeficiente.ToString() + Variable + SignoExp + ExponenteSt;
        }




        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 2: "y = ax es igual a y = a" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public static string Formula2(string Monomio2)
        {
            //-----------------------------------------------
            //Ejemplo de esta formula: f(x)=7x  ->  f(x)=7
            //-----------------------------------------------

            //variables 
            int Coeficiente;
            int Exponente;
            string Variable;

            string ResultadoDeFuncion;

            //Iniasilización

            Coeficiente = 0;
            Exponente = 0;
            Variable = "";
            ResultadoDeFuncion = "";

            //Formula:

            if (Coeficiente >= 1)
            {
                if (Variable != null && Exponente == 1)
                {
                    ResultadoDeFuncion = Convert.ToString(Coeficiente);
                }
            }
            return ResultadoDeFuncion;
        }
        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 4: "y = x es igual a y = 1" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public static string Formula4(string Monomio4)
        {
            //-----------------------------------------------
            //Ejemplo de esta formula: f(x)=x  ->  f(x)=1
            //-----------------------------------------------

            //variables 
            int Coeficiente;
            int Exponente;
            string Variable;

            string ResultadoDeFuncion;

            //Iniacialización

            Coeficiente = 0;
            Exponente = 0;
            Variable = "";
            ResultadoDeFuncion = "";

            //Formula:

            if (Coeficiente == 1)
            {
                if (Variable != null && Exponente == 1)
                {
                    ResultadoDeFuncion = Convert.ToString(Coeficiente);
                }
            }
            return ResultadoDeFuncion;
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
            int Coeficiente;
            int Exponente;
            string Variable;

            string ResultadoDeFuncion;

            //Iniacialización

            Coeficiente = 0;
            Exponente = 0;
            Variable = "";
            ResultadoDeFuncion = "";


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


