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
        public static void Factoriza(string[] args) // Cambia el nombre de la función
        {
            //variables 
            int Coeficiente1;
            int Coeficiente2;
            int Exponente;

            string Variable;
            string CoeficienteComun;

            //Inicialización

            Coeficiente1 = 0;
            Coeficiente2 = 0;
            Exponente = 0;
            Variable = "";
            CoeficienteComun = "";


            // Seleccionamos el mayor y el menor para asignarlos
            // a las variables "a" y "b" respectivamente

            int a = Math.Max(Coeficiente1, Coeficiente2);
            int b = Math.Min(Coeficiente1, Coeficiente2);

            // Variable que guardará el resultado:
            int MaximoComunDivisor;

            // Ciclo encargado de hacer las iteraciones
            do
            {
                MaximoComunDivisor = b; // Guardamos el divisor en el resultado
                b = a % b;              // Guardamos el resto en el divisor
                a = MaximoComunDivisor; // El divisor pasa al dividendo
            } while (b != 0);

            // Mostramos como resultado el último resto no nulo
            CoeficienteComun = Convert.ToString(MaximoComunDivisor);


        }
    }
}
