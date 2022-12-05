using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //-------------------------------------------//
    // Clase que contiene métodos de integración.
    //
    // Integrantes de Integrales:
    // Jorge Antonio Macías Zambrano
    // Jorge Alfredo Hernández Mota
    // Javier Alejandro Hernández Sánchez
    //------------------------------------------//
    public class CIntegral
    {
        //-------------------------
        // Atributos
        //-------------------------

        //-------------------------
        // Constructor
        //-------------------------
        public CIntegral()
        {
        }

        #region Integración
        //--------------------------------
        //Método para integrar
        //--------------------------------
        public static string Integrar(string Monomio)
        {
            // Declaración de variables
            string Coeficiente, Exponente, Variable;
            string NumeradorCO, DenominadorCO;
            int coef = 0, expo, nume, deno, numco = 0, denoco = 0;

            // Selecciona la letra vartiable
            Variable = Regex.Match(Monomio, "[a-z]").Value;

            //Convierte el coeficiente a int
            Coeficiente = Regex.Match(Monomio, "\\-?[0-9]*\\/?-?[0-9]*").Value;

            if (Coeficiente == "")
            {
                coef = 1;
            }

            else // Coeficiente en fracciones
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
                    expo = 2; //Cuando no hay potencia se da por hecho que es 1
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
                            return $"({coef}{Variable}^{expo})/{expo}";
                        }
                    }
                }
            }
        }

        #endregion

        #region Integración (Insertar variable)
        //---------------------------------------------
        //Método para integrar (Insertar variable)
        //---------------------------------------------
        public static string IntegracionInsertarVariable(string Monomio, string VariableAInsertar)
        {
            string Constante;
            string Variable;
            string Exponente;
            string ExponenteFrac;

            char[] caracteres;

            Constante = Regex.Match(Monomio, "-?[0-9]{1,}").Value;
            Variable = Regex.Match(Monomio, "[a-z]").Value;
            Exponente = Regex.Match(Monomio, "\\^-?[0-9]\\/?[0-9]*").Value;

            if (Exponente == "")
            {
                //return $"{Constante}{VariableAInsertar}{Variable}";
                Monomio = $"{Constante}{VariableAInsertar}{Variable}";

                caracteres = Monomio.ToCharArray();

                Array.Sort(caracteres);

                return new string(caracteres);
            }

            Monomio = $"{Constante}{VariableAInsertar}{Variable}^{Exponente}";

            caracteres = Monomio.ToCharArray();

            return new String(caracteres);
        }

        #endregion

        #region Integrar dx/x
        //-------------------------------------------------------------------------
        //Método que resuleve la integral de la forma dx/x
        //-------------------------------------------------------------------------
        public static string IntegrarDXx(string Integral)
        {
            // Variables de resolución
            bool Validez;
            string Resultado;

            string Funcion;
            string SubFuncion;

            // Factores
            int A;
            int B;
            int C;
            int D;

            // Subfactores
            string SubFactorA;
            string SubFactorB;
            string SubFactorC;
            string SubFactorD;

            string Factor;
            string SegundoFactor;
            string Constante;
            string Variable;
            MatchCollection VariablesComparacion;

            // Determina la validez 
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

                                } // Si es número
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
                    }      //Si arriba si hay numeros o fracciones
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
                            }     //SI abajo si hay algo
                            else
                            {   //Si lo de abajo es una fracción
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
                                }      //Si lo de abajo es un número
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
                        { //Si es numero

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
                            }      //SI abajo si hay algo
                            else
                            {      //Si lo de abajo es una fracción
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
                                }     //Si lo de abajo es un número
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

        #endregion

        #region Integrar dx
        //-------------------------------------------------------------------------
        //Método que resulve las integrales de la forma dx y kdx 
        //-------------------------------------------------------------------------
        public static string IntegrarDX(string Expresion)
        {
            // Variables
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

        #endregion
    }
}
