using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //-----------------------------------------------//
    // Clase que contiene métodos de derivación.
    //
    // Jorge Luis Cruz Macias.
    // Juan Antonio Gil Lopez.
    //-----------------------------------------------//

    public class CDerivada
    {
        //-------------------------
        // Constructor
        //-------------------------
        public CDerivada()
        {

        }

        #region Derivación Potencia
        //-----------------------------------------------------------
        // Método que resuelve derivada: Potencia f(x)= n * x^n-1
        //-----------------------------------------------------------
        public static string DerivacionPotencia(string Monomio)
        {
            // Variables
            int Constante;
            int Exponente;
            int Numerador;
            int Denominador;

            string ExponenteStr;
            string Variable;
            bool EsConstanteFraccionario;

            // Valores iniciales
            EsConstanteFraccionario = false;
            Numerador = 0;
            Denominador = 0;
            Exponente = 0;

            // Comprueba si es constante fraccionario
            if (Regex.IsMatch(Monomio, "[0-9]*\\/[0-9]"))
            {
                string _Numerador;
                string _Denominador;

                _Numerador = Regex.Match(Monomio, "[0-9]{1,}").Value;
                _Denominador = Regex.Replace(Regex.Match(Monomio, "\\/[0-9]{1,}").Value, "\\/", "");

                Numerador = Int32.Parse(_Numerador);
                Denominador = Int32.Parse(_Denominador);

                EsConstanteFraccionario = true;
            }

            // Comrueba si la constante es un número entero
            if (Regex.IsMatch(Monomio, "-?[0-9]{1,}"))
            {
                Constante = Int32.Parse(Regex.Match(Monomio, "-?[0-9]{1,}").Value);
            }

            // Si no encuentra el exponente es 1
            else
            {
                // Suena estupido pero funciona :D
                Constante = 1;
            }

            // Obtener variable
            Variable = Regex.Match(Monomio, "[a-z]").Value;

            // Obtener exponente entero / fraccionario
            ExponenteStr = Regex.Match(Monomio, "\\^-?[0-9]*\\/?[0-9]*").Value;

            if (!ExponenteStr.Contains("^") &&
                Exponente == 0 &&
                Constante == 1) 
            {
                return "";
            }

            if (!ExponenteStr.Contains("^") && 
                Exponente == 0 &&  
                Constante != 0)
            {
                return $"{Constante}";
            }


            //if (!ExponenteStr.Contains("^") &&
            //    Exponente == 0 &&
            //    Constante != 0)
            //{
            //    return $"{Constante}";
            //}

            // Exponente entero
            if (ExponenteStr.Contains("^") &&
                !ExponenteStr.Contains("/"))
            {
                Exponente = Int32.Parse(Regex.Replace(ExponenteStr, "\\^", ""));

                if (EsConstanteFraccionario)
                {
                    Numerador *= Exponente;
                }

                Constante *= Exponente;

                Exponente -= 1;

                if (Exponente == 1 &&
                    !EsConstanteFraccionario)
                {
                    return $"{Constante}{Variable}";
                }

                if (Exponente == 1 &&
                    EsConstanteFraccionario)
                {
                    return $"({Numerador}/{Denominador}){Variable}";
                }

                return $"{Constante}{Variable}^{Exponente}";
            }

            // Exponente fraccionario
            if (ExponenteStr.Contains("^") &&
                ExponenteStr.Contains("/"))
            {
                string _Numerador;
                string _Denominador;
                int Num;
                int Den;
                int AuxNum;
                int AuxDen;

                _Numerador = Regex.Match(Monomio, "\\^[0-9]").Value;
                _Denominador = Regex.Match(Monomio, "\\/[0-9]").Value;

                Num = Int32.Parse(Regex.Replace(_Numerador, "\\^", ""));
                Den = Int32.Parse(Regex.Replace(_Denominador, "\\/", ""));

                AuxNum = Num;
                AuxDen = Den;

                if (Num != Den)
                {
                    Num -= Den;
                }

                return $"{Constante}{Variable}^{Num}/{Den}";
            }

            return "Hubo un error en la derivación";
        }

        #endregion

        #region Derivación Potenciá en función de (variable)

        public static string DerivacionPotencia(string Monomio, string VariableADerivar)
        {
            // Variables
            List<string> Variables;
            MatchCollection Coincidencias;
            Variables = new List<string>();
            string NuevoMonomio;


            // Asignación de valores
            Coincidencias = Regex.Matches(Monomio, "[0-9]*[a-z]\\^?[0-9]*\\/?[0-9]*");
            NuevoMonomio = "";

            foreach (Match Coincidencia in Coincidencias)
            {
                if (Coincidencia.Value.Contains(VariableADerivar))
                {
                    NuevoMonomio += $"{DerivacionPotencia(Coincidencia.Value)}";
                }
                else
                {
                    NuevoMonomio += $"{Coincidencia.Value}";
                }
            }

            return NuevoMonomio;
        }

        #endregion

        #region Derivación variable "a"
        //--------------------------------------------------------------------
        // Método que resuelve la derivada: "y = ax es igual a y'= a" 
        //--------------------------------------------------------------------
        public static string DerivacionVariableA(string Monomio, string VariableADerivar)
        {
            if (Regex.IsMatch(Monomio, "-?[0-9]*[a-z]{1}"))

            {
                return $"{Regex.Replace(Monomio, VariableADerivar, "")}";
            }

            return "";
        }

        #endregion

        #region Derivación de constante
        //-----------------------------------------------------
        // Método que resuelve la derivada: F = k  ---> F'=0
        //-----------------------------------------------------
        public static string DerivacionConstante(string mono3)
        {
            //Variables de datos nesesarios para realizar la derivada
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

        #endregion

        #region Derivación de variable
        //------------------------------------------------------------------------
        // Método que resuelve la derivada: "y = x es igual a y = 1" 
        //------------------------------------------------------------------------
        public static string DerivacionVariable(string Monomio)
        {
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

        #endregion

        #region Derivación de una función elevada a un exponente
        //-----------------------------------------------------------------------------
        //Método que resuelve la derivada: "y = v^n es igual a y = n * v^n-1 * v^1" 
        //-----------------------------------------------------------------------------
        public static string DerivacionFuncionElevadaAExp(string Monomio)
        {
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

        #endregion
    }
}


