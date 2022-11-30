using System;
using System.Collections.Generic;
using System.Linq;
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
        static void CFactor(string[] args)
        {
            //"a" representa um numero real y "b" Representa el factor comun
            int a, b;

            //Agarra a escribiendo cual es el numero
            Console.WriteLine(" Ingresa un numero: ");

            //Inicializa el numero que escribimos
            a = int.Parse(Console.ReadLine());

            //Formula para sacar el comun divisor (Factor Comun).
            for (b = 1; b <= a; b++)
            {
                if (a % b == 0)
                {
                    Console.WriteLine(b + " es un factor de  " + a);
                }
            }
            Console.ReadLine();

        }
    }
}
