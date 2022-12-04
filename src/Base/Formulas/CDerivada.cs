using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // Variables
            int Constante;
            int Exponente;

            string ExponenteStr;
            string Variable;

            // variables para derivar exp fracc
            int Numerador;
            int Denominador;
            string _Numerador;
            string _Denominador;

            Constante = Int32.Parse(Regex.Match(Monomio, "-?[0-9]{1,}").Value);
            Variable = Regex.Match(Monomio, "[a-z]").Value;
            ExponenteStr = Regex.Match(Monomio, "\\^-?[0-9]{1,}\\/?[0-9]*").Value;

            if (ExponenteStr.Contains("^") &&
                !ExponenteStr.Contains("/"))
            {
                Exponente = Int32.Parse(Regex.Replace(ExponenteStr, "\\^", ""));

                Constante *= Exponente;

                Exponente -= 1;

                if (Exponente == 1)
                {
                    return $"{Constante}{Variable}";
                }

                return $"{Constante}{Variable}^{Exponente}";
            }

            if (ExponenteStr.Contains("^") &&
                ExponenteStr.Contains("/"))
            {
                _Numerador = Regex.Match(Monomio, "\\^[0-9]").Value;
                _Denominador = Regex.Match(Monomio, "\\/[0-9]").Value;

                Numerador = Int32.Parse(Regex.Replace(_Numerador, "\\^", ""));
                Denominador = Int32.Parse(Regex.Replace(_Denominador, "\\/", ""));

                int auxNum;
                int auxDen;

                auxNum = Numerador;
                auxDen = Denominador;

                if (Numerador != Denominador)
                {
                    Numerador += Denominador;
                }

                if (Numerador % Denominador == 0)
                {
                    Constante = Numerador / Denominador;
                }
                else
                {
                    Numerador *= Constante;
                    Denominador *= Constante;

                    if (auxNum != auxDen)
                    {
                        auxNum += auxDen;
                    }

                    return $"{Numerador}/{Denominador}{Variable}^{auxNum}/{auxDen}";
                }

                if (Numerador != Denominador)
                {
                    Numerador += Denominador;
                }

                return $"{Constante}{Variable}^{Numerador}/{Denominador}";
            }

            return "Hubo un error en la derivación";
        }

        //---------------------------------------------------------------------------//
        //Método que resuelve la formula 2: "y = ax es igual a y = a" 
        //Juan Antonio Gil Lopez
        //---------------------------------------------------------------------------//
        public static string Formula2(string Monomio)
        {
            //-----------------------------------------------
            //Ejemplo de esta formula: f(x)=7x  ->  f(x)=7
            //-----------------------------------------------

            if (Regex.IsMatch(Monomio, "-?[0-9]{1,}[a-z]{1}"))
            {
                return $"{Regex.Replace(Monomio,"[a-z]", "")}";
            }

            return "";

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
        public static string Formula4(string Monomio)
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
        public static string Formula5(string Monomio)
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


