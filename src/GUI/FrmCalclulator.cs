using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Calculadora_de_ecuaciones_diferenciales
{
    /// <summary>
    /// Desarrolladores:
    /// @Aarón Flores Pasos
    /// @Aram Josue Núñez Gradilla
    /// @Emilio Segura
    /// @Jose Luis Robles Peña
    /// @Luis Gonzalo Rivera Andrade
    /// @Luis Manuel Mantecón Reynaldo
    /// @Christian Ulises Espinoza Huerta
    /// </summary>

    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //Clase FrmCalculator que muestra la interfaz de la calculadora.
    //Fecha: 24/11/2022
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public partial class FrmCalculator : Form
    {
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Atributos.
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Contructor.
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public FrmCalculator()
        {
            InitializeComponent();
            Redondear();
        }

        #region Método para redondear componentes.
        //---------------------------------------------------------------------
        //Crea un rectangulo para redondear el componente.
        //---------------------------------------------------------------------
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        //---------------------------------------------------------------------
        //Redondea los bordes de los componentes.
        //---------------------------------------------------------------------
        private void Redondear()
        {
            //Componentes a los que se le aplica el redondeo.
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }
        #endregion
    }
}
