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
            PnlPantalla.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PnlPantalla.Width, PnlPantalla.Height, 25, 25));
            BtnLog.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnLog.Width, BtnLog.Height, 15, 15));
            BtnClc.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnClc.Width, BtnClc.Height, 15, 15));
            BtnDel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDel.Width, BtnDel.Height, 15, 15));
            BtnCalcular.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnCalcular.Width, BtnCalcular.Height, 15, 15));
            BtnRaiz.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnRaiz.Width, BtnRaiz.Height, 15, 15));
            BtnLn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnLn.Width, BtnLn.Height, 15, 15));
            BtnPotencia.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnPotencia.Width, BtnPotencia.Height, 15, 15));
            Btn_e.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn_e.Width, Btn_e.Height, 15, 15));
            Btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnLn.Width, BtnLn.Height, 15, 15));
            Btnpiπ.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btnpiπ.Width, Btnpiπ.Height, 15, 15));
            BtnMayorQue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnMayorQue.Width, BtnMayorQue.Height, 15, 15));
            BtnMenorQue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnMenorQue.Width, BtnMenorQue.Height, 15, 15));
            BtnMayorOIgualQue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnMayorOIgualQue.Width, BtnMayorOIgualQue.Height, 15, 15));
            BtnMenorOIgualQue.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnMenorOIgualQue.Width, BtnMenorOIgualQue.Height, 15, 15));
            BtnArrova.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnArrova.Width, BtnArrova.Height, 15, 15));
            BtnAbreParentesis.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnAbreParentesis.Width, BtnAbreParentesis.Height, 15, 15));
            BtnCierraParentesis.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnCierraParentesis.Width, BtnCierraParentesis.Height, 15, 15));
            BtnDivision.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDivision.Width, BtnDivision.Height, 15, 15));
            BtnMultiplicacion.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnMultiplicacion.Width, BtnMultiplicacion.Height, 15, 15));
            BtnT.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnT.Width, BtnT.Height, 15, 15));
            Btn7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn7.Width, Btn7.Height, 15, 15));
            Btn8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn8.Width, Btn8.Height, 15, 15));
            Btn9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn9.Width, Btn9.Height, 15, 15));
            BtnResta.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnResta.Width, BtnResta.Height, 15, 15));
            BtnU.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnU.Width, BtnU.Height, 15, 15));
            Btn4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn4.Width, Btn4.Height, 15, 15));
            Btn5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn5.Width, Btn5.Height, 15, 15));
            Btn6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn6.Width, Btn6.Height, 15, 15));
            BtnSuma.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnSuma.Width, BtnSuma.Height, 15, 15));
            BtnX.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnX.Width, BtnX.Height, 15, 15));
            Btn1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn1.Width, Btn1.Height, 15, 15));
            Btn2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn2.Width, Btn2.Height, 15, 15));
            Btn3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn3.Width, Btn3.Height, 15, 15));
            BtnPunto.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnPunto.Width, BtnPunto.Height, 15, 15));
            BtnY.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnY.Width, BtnY.Height, 15, 15));
            Btn0.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn0.Width, Btn0.Height, 15, 15));
            BtnIgual.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnIgual.Width, BtnIgual.Height, 15, 15));
            BtnComa.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnComa.Width, BtnComa.Height, 15, 15));
            BtnPuntoyComa.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnPuntoyComa.Width, BtnPuntoyComa.Height, 15, 15));
        }
        #endregion

        #region Metodo para mover la ventana.
        //---------------------------------------------------------------------
        //Permitir mover la ventana por la pantalla.
        //---------------------------------------------------------------------
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapure();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wsmg, int wparam, int lparam);
        private void Delizar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapure();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Métodos de botones.
        //---------------------------------------------------------------------
        //Permitir mostrar la ecuación inicial en la parte superior
        //y el resultado de esta en la parte infeior de la pantalla.
        //---------------------------------------------------------------------
        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            TxtEcuacionInicial.Text = TxtResultado.Text;
            TxtResultado.Text = "Resultado";
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            TxtEcuacionInicial.Clear();
            TxtResultado.Clear();
        }

        private void BtnClc_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        private void BtnLog_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        private void Btn_e_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "e";
        }

        private void BtnPotencia_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "^";
        }

        private void BtnLn_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "ln";
        }

        private void BtnRaiz_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "√";
        }

        private void BtnMenorOIgualQue_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "<=";
        }

        private void BtnMayorOIgualQue_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ">=";
        }

        private void BtnMenorQue_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "<";
        }

        private void BtnMayorQue_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ">";
        }

        private void Btnpiπ_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "π";
        }

        private void BtnMultiplicacion_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "*";
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "/";
        }

        private void BtnCierraParentesis_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ")";
        }

        private void BtnAbreParentesis_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "(";
        }

        private void BtnArrova_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "@";
        }

        private void BtnResta_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "-";
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "9";
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "8";
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "7";
        }

        private void BtnT_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "T";
        }

        private void BtnSuma_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "+";
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "6";
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "5";
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "4";
        }

        private void BtnU_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "u";
        }

        private void BtnPunto_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ".";
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "3";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "2";
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "1";
        }

        private void BtnX_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "x";
        }

        private void BtnPuntoyComa_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ";";
        }

        private void BtnComa_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ",";
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "=";
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "0";
        }

        private void BtnY_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "y";
        }

        #endregion
    }
}
