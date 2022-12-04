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
        //Método que resuleve la integral de ña forma dx/x
        //-------------------------------------------------------------------------

        //Método por Javier Hernandez
        public static string IntegrarDXSX(string Integral)
        {

        bool Validez;
        string SegundoFactor;
        string SubFactorA;
        string SubFactorB;
        string SubFactorC;
        string SubFactorD;
        string Factor;
        string Constante;
        string Variable;
        MatchCollection VariablesComparacion;
        string SubFuncion;
        string Funcion;
        string Resultado;
        int A;
        int B;
        int C;
        int D;

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
                
                string x = VariablesComparacion[0].ToString();
                string x2 = VariablesComparacion[1].ToString();
                if (x == x2)
                {
                    SubFuncion = Convert.ToString(Regex.Match(Integral, "(\\/([0-9]\\/[0-9])*[0-9]*[a-z](-|\\+)[0-9])"));
                    SubFuncion = Convert.ToString(Regex.Match(SubFuncion, "(([0-9]\\/[0-9])*[0-9]*[a-z](-|\\+)[0-9])"));
                    SegundoFactor = Convert.ToString(Regex.Match(Variable, "([0-9]\\/[0-9]|[0-9])"));
                    Funcion = Convert.ToString(Regex.Match(Integral, "([a-z](-|\\+)[0-9])"));

                    //Si arriba no hay numeros o fracciones
                    if (Factor == "1" || Factor == "-1")
                    {
                        //Si no hay numeros (o fracciones) arriba ni abajo
                        if (SegundoFactor == "")
                        {
                            //----------------------------------------------------------------------------------------------
                            //If repetitivo de cada caso que revisa si existe una función en el denominador (abajo) 
                            //o no y la incluye en el resultado si si existe
                            //----------------------------------------------------------------------------------------------
                            if (Funcion == "")
                            {
                                //Si no hay función abajo
                                Resultado = Factor + "ln " + "|" + x + "|" + " + C";
                                return Resultado;
                            }
                            else
                            {
                                Resultado = Factor + "ln " + "|" + SubFuncion + "|" + " + C";
                                return Resultado;
                            }
                        }

                        //Si abajo si hay numeros o fracciones
                        if (SegundoFactor != "")
                        {
                            //Si es una fracción
                            if (Validez = Regex.IsMatch(SegundoFactor, "([0-9]\\/[0-9])"))
                            {
                                SubFactorA = SegundoFactor.Substring(0, 1);
                                SubFactorB = SegundoFactor.Substring(2, 1);
                                if (Factor == "-1")
                                {
                                    if (Funcion == "")
                                    {
                                        SegundoFactor = SubFactorB + "/" + SubFactorA;
                                        Resultado = "-" + SegundoFactor + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        SegundoFactor = SubFactorB + "/" + SubFactorA;
                                        Resultado = "-" + SegundoFactor + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }
                                }
                                else
                                {
                                    SegundoFactor = SubFactorB + "/" + SubFactorA;
                                    if (Funcion == "")
                                    {
                                        Resultado = SegundoFactor + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = SegundoFactor + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }

                                }//Si es número
                            }
                            else
                            {
                                //Paso el numero a fracción como denominador
                                SegundoFactor = "1/" + SegundoFactor;
                                if (Factor == "-1")
                                {
                                    if (Funcion == "")
                                    {
                                        Resultado = "-" + SegundoFactor + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = "-" + SegundoFactor + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }
                                }
                                else
                                {
                                    if (Funcion == "")
                                    {
                                        Resultado = SegundoFactor + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = SegundoFactor + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }

                                }
                            }
                        }
                    }//Si arriba si hay numeros o fracciones
                    else
                    {
                        //Si es fraccion
                        if (Validez = Regex.IsMatch(Factor, "([0-9]\\/[0-9])"))
                        {
                            //Si abajo no hay nada
                            if (SegundoFactor == "")
                            {
                                if (Funcion == "")
                                {
                                    Resultado = Factor + "ln " + "|" + x + "|" + " + C";
                                    return Resultado;
                                }
                                else
                                {
                                    Resultado = Factor + "ln " + "|" + SubFuncion + "|" + " + C";
                                    return Resultado;
                                }
                            }//SI abajo si hay algo
                            else
                            {//Si lo de abajo es una fracción
                                if (Validez = Regex.IsMatch(SegundoFactor, "([0-9]\\/[0-9])"))
                                {
                                    SubFactorA = Factor.Substring(0, 1);
                                    SubFactorB = Factor.Substring(2, 1);
                                    SubFactorC = SegundoFactor.Substring(0, 1);
                                    SubFactorD = SegundoFactor.Substring(2, 1);
                                    A = Convert.ToInt32(SubFactorA);
                                    B = Convert.ToInt32(SubFactorB);
                                    C = Convert.ToInt32(SubFactorC);
                                    D = Convert.ToInt32(SubFactorD);
                                    if (Funcion == "")
                                    {
                                        Resultado = Resultado = A * D + "/" + B * C + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = Resultado = A * D + "/" + B * C + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }
                                }//Si lo de abajo es un número
                                else
                                {
                                    SubFactorA = Factor.Substring(0, 1);
                                    SubFactorB = Factor.Substring(2, 1);
                                    A = Convert.ToInt32(SubFactorA);
                                    B = Convert.ToInt32(SubFactorB);
                                    C = Convert.ToInt32(SegundoFactor);
                                    if (Funcion == "")
                                    {
                                        Resultado = Resultado = A + "/" + B * C + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = Resultado = A + "/" + B * C + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }
                                }
                            }
                        }
                        else
                        //Si es numero
                        {
                            //Si abajo no hay nada
                            if (SegundoFactor == "")
                            {
                                if (Funcion == "")
                                {
                                    Resultado = Factor + "ln " + "|" + x + "|" + " + C";
                                    return Resultado;
                                }
                                else
                                {
                                    Resultado = Factor + "ln " + "|" + SubFuncion + "|" + " + C";
                                    return Resultado;
                                }
                            }//SI abajo si hay algo
                            else
                            {//Si lo de abajo es una fracción
                                if (Validez = Regex.IsMatch(SegundoFactor, "([0-9]\\/[0-9])"))
                                {
                                    SubFactorC = SegundoFactor.Substring(0, 1);
                                    SubFactorD = SegundoFactor.Substring(2, 1);
                                    A = Convert.ToInt32(Factor);
                                    C = Convert.ToInt32(SubFactorC);
                                    D = Convert.ToInt32(SubFactorD);
                                    if (Funcion == "")
                                    {
                                        Resultado = Resultado = A * D + "/" + C + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = Resultado = A * D + "/" + C + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }
                                }//Si lo de abajo es un número
                                else
                                {
                                    A = Convert.ToInt32(Factor);
                                    D = Convert.ToInt32(SegundoFactor);
                                    if (Funcion == "")
                                    {
                                        Resultado = Resultado = A + "/" + D + "ln " + "|" + x + "|" + " + C";
                                        return Resultado;
                                    }
                                    else
                                    {
                                        Resultado = Resultado = A + "/" + D + "ln " + "|" + SubFuncion + "|" + " + C";
                                        return Resultado;
                                    }
                                }
                            }
                        }
                    }
                    //MessageBox.Show(Resultado);
                    return Integral;
                }
                else
                {
                    MessageBox.Show("Ecuación no válida");
                    return Integral;
                }
            }
            else
            {
                MessageBox.Show("Ecuación no compatible");
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
