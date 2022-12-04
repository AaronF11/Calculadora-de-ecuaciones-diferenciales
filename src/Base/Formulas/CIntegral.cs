using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //-------------------------
    // Clase que integra.
    //-------------------------
    public class CIntegral
    {
        //Integrantes de Integrales:
        //Jorge Alfredo Hernández Mota
        //Javier Alejandro Hernández Sánchez

        //-------------------------
        // Atributos
        //-------------------------
      //int y;
        //protected MatchCollection VariablesComparacion;
       // protected string Resultado;
       // protected string Factor;
       // protected string Integral;
       // protected bool Validez;
        //protected string Variable;
       // protected string VariableReducida;
       // protected string Constante;
        //-------------------------
        // Constructor
        //-------------------------
        public CIntegral()
        {
        }
        //-------------------------------------------------------------------------
        //Metodo para integrar
        //-------------------------------------------------------------------------
        public static string Integrar(string Monomio)
        {
            //Declaracion de variables
            string Coeficiente, Exponente, Variable;
            string NumeradorCO, DenominadorCO;
            int coef = 0, expo, nume, deno, numco = 0, denoco = 0;

            //Selecciona la letra vartiable
            Variable = Regex.Match(Monomio, "[a-z]").Value;

            //Convierte el coeficiente a int
            Coeficiente = Regex.Match(Monomio, "\\-?[0-9]*\\/?-?[0-9]*").Value;
            if (Coeficiente == "")
            {
                coef = 1;
            }
            else //Coeficiente en fracciones
            {
                if (Coeficiente.Contains("/"))
                {
                    NumeradorCO = Regex.Match(Coeficiente, "\\-?[0-9]{1,}").Value;
                    DenominadorCO = Regex.Match(Coeficiente, "\\/-?[0-9]{1,}").Value;
                    DenominadorCO = Regex.Replace(DenominadorCO, "\\/", "");

                    numco = Int32.Parse(NumeradorCO);
                    denoco = Int32.Parse(DenominadorCO);
                }
                else
                {
                    coef = Int32.Parse(Coeficiente);
                }
            }

            //Determina si es termino independiete
            if (Variable == "")
            {
                Variable = "x";

                if (coef == 0) //Independiente en fraccion
                {
                    return $"{numco}/{denoco}{Variable}";
                }
                else //Independiente entero
                {
                    return $"{coef}{Variable}";
                }
            }
            else
            {
                //Convierte el exponente a int y le suma 1
                Exponente = Regex.Match(Monomio, "\\^-?[0-9]{1,}\\/?[0-9]*").Value;

                if (Exponente.Contains("^") && !Exponente.Contains("/"))
                {
                    expo = Int32.Parse(Regex.Replace(Exponente, "\\^", "")) + 1;
                }
                else if (Exponente.Contains("^") && Exponente.Contains("/"))
                {
                    expo = 0;
                }
                else
                {
                    expo = 2; //Cuando no hay potencia se da por hechoo que es 1
                }

                //Determina si el exponente es fraccion
                string Numerador, Denominador;

                if (Exponente.Contains("^") && Exponente.Contains("/"))
                {
                    //Lee la fraccion
                    Numerador = Regex.Match(Exponente, "\\^-?[0-9]*").Value;
                    Denominador = Regex.Match(Exponente, "\\/-?[0-9]*").Value;
                    Numerador = Regex.Replace(Numerador, "\\^", "");
                    Denominador = Regex.Replace(Denominador, "\\/", "");
                    nume = Int32.Parse(Numerador);
                    deno = Int32.Parse(Denominador);

                    nume += deno;

                    if (coef == 0)//Coeficiente y exponente en fracciones
                    {
                        return $"{numco}/{denoco}{Variable}^{nume}/{deno}";
                    }
                    else //Exponente en fracciones
                    {
                        return $"{coef}{Variable}^{nume}/{deno}";
                    }
                }
                else
                {
                    if (coef % expo == 0) //Resultado simplificado
                    {
                        if (coef == 0)
                        {
                            return $"{numco}/{denoco}{Variable}^{expo}";
                        }
                        else
                        {
                            coef /= expo;
                            return $"{coef}{Variable}^{expo}";
                        }
                    }
                    else //Resultado sin simplificar
                    {
                        if (coef == 0)
                        {
                            return $"{numco}/{denoco}{Variable}^{expo})/{expo}";
                        }
                        else
                        {
                            return $"{coef}{Variable}^{expo})/{expo}";
                        }
                    }
                }
            }
        }
    }

        //-------------------------------------------------------------------------
        //Método que resuleve la integral de la forma dx/x
        //-------------------------------------------------------------------------

        //Método por Javier Hernandez
        public static string IntegrarDXSX(string Expresion)
        {
            string Resultado;
            string Integral = Expresion;
            bool Validez;
            string Factor;
            string Constante;
            string Variable;
            MatchCollection VariablesComparacion;

            if (Validez = Regex.IsMatch(Integral, "^(-|\\+?)([0-9]\\/[0-9])*[0-9]*[a-z]*\\/(-|\\+?)*([0-9]\\/[0-9])*[0-9]*[a-z]"))
            {
                Factor = Convert.ToString(Regex.Match(Integral, "^(-|\\+?)([0-9]/[0-9])*[0-9]*[^d]*"));
                if (Factor == "")
                {
                    Factor = "1";
                }
                else if (Factor == "-")
                {
                    Factor = "-1";
                }
                else if (Factor == "+")
                {
                    Factor = "1";
                }

                Constante = Convert.ToString(Regex.Match(Integral, "d[a-z]?"));
                Variable = Convert.ToString(Regex.Match(Integral, "[a-z]\\/(-|\\+?)([0-9]\\/[0-9])*[0-9]*[a-z]"));
                VariablesComparacion = Regex.Matches(Variable, "[a-z]");
                Resultado = "";


                MessageBox.Show(Factor);
                MessageBox.Show(Constante);
                MessageBox.Show(Variable);
                foreach (var Item in VariablesComparacion)
                {
                    MessageBox.Show(Item.ToString());
                }
                return Resultado;
            }
            else
            {
                MessageBox.Show("No es");
                return Integral;
            }
        }

        //-------------------------------------------------------------------------
        //Método que resulve las integrales de la forma dx y kdx 
        //-------------------------------------------------------------------------

        //Método por Javier Hernández
        public static string IntegrarDX(string Expresion)
        {
            string Constante = Expresion;
            string Variable;
            string Resultado;

            if (Regex.IsMatch(Expresion, "^(-|\\+?)*([0-9]\\/[0-9])*[0-9]*"))
            {
                Constante = Convert.ToString(Regex.Match(Expresion, "^(-|\\+?)*[^dx]*"));
                if (Constante == "")
                {
                    Constante = "1";
                }
                else if (Constante == "-")
                {
                    Constante = "-1";
                }
                else if (Constante == "+")
                {
                    Constante = "1";
                }

                Variable = Convert.ToString(Regex.Match(Expresion, "[^0-9+-/d ^]"));

                Resultado = Constante + Variable + " + C";
                MessageBox.Show(Resultado);
                return Resultado;
            }
            else
            {
                MessageBox.Show("Integral no válida");
                return Constante;
            }
        }

    }
}
