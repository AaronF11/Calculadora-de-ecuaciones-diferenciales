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
