using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace POO22B_GPJA
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
        protected string X;
        protected string Resultado;
        protected string Factor;
        protected string Integral;
        protected bool Validez;
        protected string Variable;

        //-------------------------
        // Constructor
        //-------------------------
        public CIntegral()
        {
        }

        //-------------------------------------------------------------------------
        //Método Integrador que recibe a la ecuación de la forma dx/x como string
        //-------------------------------------------------------------------------
        //Método por Javier Hernandez
        public string IntegrarX(string Integral)
        {
            this.Integral = Integral;

            //If que verifica que el formato de la ecuación a integrar sea correcta
            Validez = Regex.IsMatch(Integral, "^(-|\\+?)+[0-9]*([0-9]+\\/+[0-9])*[a-z]*d[a-z]+\\/[a-z]");
            
            if (Validez)
            {
                //Obtiene la primera parte de la ecuación, todo lo que esté antes de "dx"
                Factor = Convert.ToString(Regex.Match(Integral, "^(-|\\+?)[0-9]*([0-9]+\\/+[0-9])*[^d]*"));

                //Obtiene las variables sobre las que se va a integrar
                Variable = Convert.ToString(Regex.Match(Integral, "([a-z]\\/[a-z])"));

                //If que comprueba que ambas variables de integración sean iguales
                if (Variable.Substring(0, 1) == Variable.Substring(2, 1))
                {
                    //Obtiene la variable de integración una vez que se comprueba que es correcta
                    X = Variable.Substring(0, 1);

                    //Se organiza el resultado:
                    Resultado = Factor + " ln " + "|" + X + "|" + " + C";
                    return Resultado;
                }
            
                MessageBox.Show("Integral no válida");
                
                return null;
            }
            MessageBox.Show("Integral no válida");
            return null;
        }
    }
}
