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
    // JAGL. Juan Antonio Gil Lopez. 28/11/2022
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
        //Método que resuelve derivada: Potencia f(x)= n * x^n-1
        //Jorge Luis Cruz
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

            if (Coeficiente != 0 && Variable != null && Exponente == 1)
            {
                ResultadoDeFuncion = Convert.ToString(Coeficiente);
            }
            return ResultadoDeFuncion;
        }
        //-------------------------------------------------------------------------------
        //Formula 3 que resuelve F = k  ---> F'=0
        //Jorge Luis Cruz
        //-------------------------------------------------------------------------------
        public static string Formula3(string mono3)
        {
            //Variables Datos nesesarios para realizar derivada
            int Coeficiente;
            int Exponente;
            String Variable;

            String Respuesta;

            //Inicialización 

            Coeficiente = 0;
            Exponente = 0;
            Variable = "";
            Respuesta = "";

            if (Exponente == 0)
            {
                if (Variable == null)
                {
                    Coeficiente = 0;
                    Respuesta = Coeficiente.ToString();
                }
            }
            return Respuesta;
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

            if (Coeficiente == 1 && Variable != null && Exponente == 1)
            { 
                    ResultadoDeFuncion = Convert.ToString(Coeficiente);
            }
            return ResultadoDeFuncion;
        }
        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 5: "y = v^n es igual a y = n * v^n-1 * v^1" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public static string Formula5(string Monomio5)
        {
            //----------------------------------------------------------
            //Esta formula toma como base a la primera formula
            //----------------------------------------------------------

            //Variables 
            int Coeficiente;
            int ExponenteMonomio;
            String Variable;
            String SignoExp;
            int DerivadaDeVariable;
            int ExponenteDeVariable;
            int ResultadoDeFuncion;

            int NuevoCoeficiente;  //--> Resultado de la multiplicación Exponente por coeficiente
            int REExponente;       //--> Resultado de la resta al Exponente 

            String ResultadoDerivada;//--> Contiene la cadena de caracteres la cual representa el resultado de una derivada

            //Inicialización 
            Coeficiente = 0;
            ExponenteMonomio = 0; //--> Este exponente es el que tiene el monomio (en la formula se pone como "n").
            SignoExp = "";
            Variable = "";
            ExponenteDeVariable = 0; //--> Este exponente es el que tiene la variable "x".

            //Se realiza el metodo de la primera formula
            NuevoCoeficiente = ExponenteMonomio * Coeficiente; //n * v
            REExponente = ExponenteMonomio - 1; //v^n-1

            //Aqui se deriva v
            DerivadaDeVariable = Coeficiente * ExponenteDeVariable; //v * m
            ExponenteDeVariable = ExponenteDeVariable - 1;    //m - 1

            //Se multiplica el nuevo coeficiente por la derivada v
            ResultadoDeFuncion = NuevoCoeficiente * DerivadaDeVariable; //v2 * v1

            //Se le asigno el valor a SignoExp
            SignoExp = "^";

            //Muestra el Resultado
            return ResultadoDerivada = "(" + ResultadoDeFuncion + Variable + SignoExp + ExponenteDeVariable + ")" + SignoExp + REExponente;
        }
    }
}


