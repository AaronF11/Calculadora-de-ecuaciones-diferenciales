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
            Console.WriteLine("Ingrese el primer número");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo número");
            int num2 = Convert.ToInt32(Console.ReadLine());

            // Seleccionamos el mayor y el menor para asignarlos
            // a las variables "a" y "b" respectivamente
            int a = Math.Max(num1, num2);
            int b = Math.Min(num1, num2);

            // Declaramos la variable que guardará el resultado
            int MaximoComunDivisor;

            // Creamos el ciclo encargado de hacer las iteraciones
            do
            {
                MaximoComunDivisor = b; // Guardamos el divisor en el resultado
                b = a % b; // Guardamos el resto en el divisor
                a = MaximoComunDivisor; // El divisor pasa al dividendo
            } while (b != 0);

            // Mostramos como resultado el último resto no nulo
            Console.WriteLine("El M.C.D. entre " + num1 + " y " + num2 + " es: " + MaximoComunDivisor);

            Console.ReadKey(true);
        }
    }
}
