﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas
{
    //---------------------------------------------------------------------
    //Clase que Deriva.
    // CMJL. Jorge Luis Cruz Macias. 28/11/2022   
    //---------------------------------------------------------------------

    public class CDerivada
    {
        //Atributos 
        public int Coeficiente;
        public int Exponente;
        public string Variable;
        //Atributos del segundo termino 

        public int Coeficiente2;
        public int Exponente2;
        public string Variable2;



        //Metodo constructor 

        public CDerivada(double Coeficiente,double Exponente, String Variable)
        {
            Coeficiente = Coeficiente;
            Exponente = Exponente;  
            Variable = Variable;    


        }

        //Metodo que  resuelve derivada Potencia f(x)=nx^n-1
         public void Derivar()
         {
           

            //En estas variables se aguardan los datos  una vez realizadas las operaciones Basicas 

            int NuevoCoeficiente;
            int NuevoExponente;
            String NuevaVariable;

            String ResultadoDerivada;

           

            //Se realizan las operaciones Basicas 

            NuevoCoeficiente= Exponente * Coeficiente;
            NuevoExponente = Exponente-1;

            //Aguarda el resultado final de La derivada 

             ResultadoDerivada = NuevoCoeficiente.ToString()+Exponente+NuevoExponente.ToString();

            

            
         }

        public void Derivar2()
        {
            //variables 

            int TerminoUno;
            int TerminoDos;

           

            int Resultado;
            int resultado2;


           

            int NuevoCoeficiente;
            int NuevoExponente;
            String NuevaVariable;

            //Segundo Termino 

            int NuevoCoeficiente2;
            int NuevoExponente2;
            String NuevaVariable2;


             int ResultadoExpDerivada;
           




            //Se deriva lo de adentro

            NuevoCoeficiente = Coeficiente * Exponente;
            NuevoExponente = Exponente-1;


            NuevoCoeficiente2=Coeficiente2* Exponente2;
            NuevoExponente2 = Exponente2;

            ResultadoExpDerivada = Exponente * NuevoCoeficiente2;
        }




    }
}
