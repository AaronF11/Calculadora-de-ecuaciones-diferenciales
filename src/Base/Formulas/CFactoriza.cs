using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //---------------------------------------------------------------------
    //Clase de factorización. 28/11/2022.   
    //JEGR. Jose Eduardo Garcia Ramirez.
    //JAGL. Juan Antonio Gil Lopez.
    //---------------------------------------------------------------------
    public class CFactoriza
    {
        //----------------------------------
        // Atributos
        //----------------------------------

        //-------------------------
        // Constructor
        //-------------------------
        public CFactoriza()
        {

        }

        //-------------------------
        // Clase que factoriza 
        //-------------------------
        static void CFactor(string[] args) // Cambia el nombre de la función
        {
            //"PrimerNumero" y "SegundoNumero" representa cada uno un numero real 
            //"b y d" Representan el factor comun de cada numero. 
            int PrimerNumero, b, SegundoNumero, d;

            //Inicializa el numero que escribimos

            //(Esto es lo que se pusiera en el textbox pero lo pongo en consola para pruebas)

            Console.WriteLine(" Ingresa un numero: ");
            
            PrimerNumero = int.Parse(Console.ReadLine()); //Primer termino

            Console.WriteLine(" Ingresa otro numero: ");

            SegundoNumero = int.Parse(Console.ReadLine()); //Segundo termino

            //---------------------------------------------------
            //Formula para sacar el comun divisor (Factor Comun).
            //---------------------------------------------------

            for (b = 1; b <= PrimerNumero; b++) //Factor comun del primer numero
            {
                if (PrimerNumero % b == 0) 
                {
                    //Lee y muestra la lista de los factores multiplos del Primer termino
                }
                Console.WriteLine(b + " es un factor de  " + PrimerNumero); 
            }
            Console.ReadLine(); 

            for (d = 1; d <= SegundoNumero; d++) //Factor comun del segundo numero
            {
                if (SegundoNumero % d == 0)
                {
                    //Lee y muestra la lista de los factores multiplos del Segundo termino
                    Console.WriteLine(d + " es un factor de  " + SegundoNumero); 
                }
            }
            Console.ReadLine();

            //Lo siguiente seria hacer un for para tomar los factores comunes de ambos términos y si llega a haber algun
            //numero igual entre ambos factores comunes se toma para ser el FACTOR COMUN AMBOS TERMINOS
        







        }
    }
}
