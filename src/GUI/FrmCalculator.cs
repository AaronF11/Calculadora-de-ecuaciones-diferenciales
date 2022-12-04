using Calculadora_de_ecuaciones_diferenciales.src.Base.Formulas;
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
        public double Coeficiente { get; private set; }
        public double Exponente { get; private set; }
        public string Variable { get; private set; }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Atributos.
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        int Modo;
        int Operacion;

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //Contructor.
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public FrmCalculator()
        {
            InitializeComponent();
        }

        #region Método cuando se crea la ventana.
        //---------------------------------------------------------------------
        //Método que se ejecuta al iniciar la ventana.
        //---------------------------------------------------------------------
        private void FrmCalculator_Load(object sender, EventArgs e)
        {
            Redondear();//! Redondea los bordes de los componentes y de la ventana.
            PnlMenu.Height = 0;//! Esconde el menú.
            Modo = 0; //! Modo inicial de la calculadora.
            Operacion = 0; //! Operación inicial de la calculadora.
        }
        #endregion

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
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            PnlPantalla.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, PnlPantalla.Width, PnlPantalla.Height, 25, 25));
            BtnAc.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnAc.Width, BtnAc.Height, 15, 15));
            BtnDel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDel.Width, BtnDel.Height, 15, 15));
            BtnCalcular.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnCalcular.Width, BtnCalcular.Height, 15, 15));
            BtnRaiz.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnRaiz.Width, BtnRaiz.Height, 15, 15));
            BtnLn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnLn.Width, BtnLn.Height, 15, 15));
            BtnPotencia.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnPotencia.Width, BtnPotencia.Height, 15, 15));
            Btn_e.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn_e.Width, Btn_e.Height, 15, 15));
            BtnD.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnLn.Width, BtnLn.Height, 15, 15));
            Btnpiπ.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btnpiπ.Width, Btnpiπ.Height, 15, 15));
            BtnDY.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDY.Width, BtnDY.Height, 15, 15));
            BtnDX.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDX.Width, BtnDX.Height, 15, 15));
            BtnDYDX.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDYDX.Width, BtnDYDX.Height, 15, 15));
            BtnDXDY.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDXDY.Width, BtnDXDY.Height, 15, 15));
            BtnIntegral.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnIntegral.Width, BtnIntegral.Height, 15, 15));
            BtnAbreParentesis.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnAbreParentesis.Width, BtnAbreParentesis.Height, 15, 15));
            BtnCierraParentesis.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnCierraParentesis.Width, BtnCierraParentesis.Height, 15, 15));
            BtnDivision.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnDivision.Width, BtnDivision.Height, 15, 15));
            BtnMultiplicacion.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnMultiplicacion.Width, BtnMultiplicacion.Height, 15, 15));
            BtnX.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnX.Width, BtnX.Height, 15, 15));
            Btn7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn7.Width, Btn7.Height, 15, 15));
            Btn8.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn8.Width, Btn8.Height, 15, 15));
            Btn9.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn9.Width, Btn9.Height, 15, 15));
            BtnResta.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnResta.Width, BtnResta.Height, 15, 15));
            BtnY.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnY.Width, BtnY.Height, 15, 15));
            Btn4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn4.Width, Btn4.Height, 15, 15));
            Btn5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn5.Width, Btn5.Height, 15, 15));
            Btn6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn6.Width, Btn6.Height, 15, 15));
            BtnSuma.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnSuma.Width, BtnSuma.Height, 15, 15));
            BtnW.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnW.Width, BtnW.Height, 15, 15));
            Btn1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn1.Width, Btn1.Height, 15, 15));
            Btn2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn2.Width, Btn2.Height, 15, 15));
            Btn3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn3.Width, Btn3.Height, 15, 15));
            BtnPunto.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnPunto.Width, BtnPunto.Height, 15, 15));
            BtnZ.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnZ.Width, BtnZ.Height, 15, 15));
            Btn0.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Btn0.Width, Btn0.Height, 15, 15));
            BtnIgual.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BtnIgual.Width, BtnIgual.Height, 15, 15));
        }
        #endregion

        #region Método para mover la ventana.
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

        #region Botones de la barra superior.
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (PnlMenu.Height == 140)
            {
                PnlMenu.Height = 0;
                BtnMenu.BackColor = this.BackColor;
            }
            else if (PnlMenu.Height == 0)
            {
                PnlMenu.Height = 140;
                BtnMenu.BackColor = this.BackColor;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Cambiar modo de la interfaz.
        //---------------------------------------------------------------------
        //Método que alterna los colores de la calculadora (Claro/Oscuro).
        //---------------------------------------------------------------------
        private void Modos(int Modo)
        {
            if (Modo == 1)
            {
                BtnModo.Image = Properties.Resources.Oscuro_2;
                BtnModo.ImageAlign = ContentAlignment.MiddleLeft;
                BtnModo.Text = "Dark";
                BtnModo.TextAlign = ContentAlignment.MiddleCenter;
                BtnModo.ForeColor = Color.FromArgb(84, 84, 84);
                this.BackColor = Color.FromArgb(224, 224, 224);
                BtnMenu.Image = Properties.Resources.Menu;
                BtnMinimizar.Image = Properties.Resources.Minimizar;
                BtnCerrar.Image = Properties.Resources.Cerrar;
                BtnMenu.BackColor = this.BackColor;
                PnlMenu.BackColor = this.BackColor;
                PnlPantalla.BackColor = Color.White;
                TxtEcuacionInicial.BackColor = Color.White;
                TxtResultado.BackColor = Color.White;
                TxtResultado.ForeColor = Color.Black;
                BtnCalcular.BackColor = Color.FromArgb(200, 230, 201);
                BtnCalcular.ForeColor = Color.FromArgb(45, 131, 210);
                BtnAc.BackColor = Color.FromArgb(128, 203, 196);
                BtnDel.BackColor = Color.FromArgb(128, 203, 196);
                BtnD.BackColor = Color.FromArgb(144, 202, 249);
                Btn_e.BackColor = Color.FromArgb(144, 202, 249);
                BtnPotencia.BackColor = Color.FromArgb(144, 202, 249);
                BtnLn.BackColor = Color.FromArgb(144, 202, 249);
                BtnRaiz.BackColor = Color.FromArgb(144, 202, 249);
                BtnDXDY.BackColor = Color.FromArgb(144, 202, 249);
                BtnDYDX.BackColor = Color.FromArgb(144, 202, 249);
                BtnDX.BackColor = Color.FromArgb(144, 202, 249);
                BtnDY.BackColor = Color.FromArgb(144, 202, 249);
                Btnpiπ.BackColor = Color.FromArgb(144, 202, 249);
                BtnIntegral.BackColor = Color.FromArgb(144, 202, 249);
                BtnAbreParentesis.BackColor = Color.FromArgb(144, 202, 249);
                BtnCierraParentesis.BackColor = Color.FromArgb(144, 202, 249);
                BtnDivision.BackColor = Color.FromArgb(206, 147, 216);
                BtnMultiplicacion.BackColor = Color.FromArgb(206, 147, 216);
                BtnResta.BackColor = Color.FromArgb(206, 147, 216);
                BtnSuma.BackColor = Color.FromArgb(206, 147, 216);
                BtnX.BackColor = Color.White;
                BtnX.ForeColor = Color.FromArgb(45, 131, 210);
                Btn7.BackColor = Color.White;
                Btn7.ForeColor = Color.FromArgb(45, 131, 210);
                Btn8.BackColor = Color.White;
                Btn8.ForeColor = Color.FromArgb(45, 131, 210);
                Btn9.BackColor = Color.White;
                Btn9.ForeColor = Color.FromArgb(45, 131, 210);
                BtnY.BackColor = Color.White;
                BtnY.ForeColor = Color.FromArgb(45, 131, 210);
                Btn4.BackColor = Color.White;
                Btn4.ForeColor = Color.FromArgb(45, 131, 210);
                Btn5.BackColor = Color.White;
                Btn5.ForeColor = Color.FromArgb(45, 131, 210);
                Btn6.BackColor = Color.White;
                Btn6.ForeColor = Color.FromArgb(45, 131, 210);
                BtnW.BackColor = Color.White;
                BtnW.ForeColor = Color.FromArgb(45, 131, 210);
                Btn1.BackColor = Color.White;
                Btn1.ForeColor = Color.FromArgb(45, 131, 210);
                Btn2.BackColor = Color.White;
                Btn2.ForeColor = Color.FromArgb(45, 131, 210);
                Btn3.BackColor = Color.White;
                Btn3.ForeColor = Color.FromArgb(45, 131, 210); ;
                BtnPunto.BackColor = Color.White;
                BtnPunto.ForeColor = Color.FromArgb(45, 131, 210);
                BtnZ.BackColor = Color.White;
                BtnZ.ForeColor = Color.FromArgb(45, 131, 210);
                Btn0.BackColor = Color.White;
                Btn0.ForeColor = Color.FromArgb(45, 131, 210);
                BtnIgual.BackColor = Color.White;
                BtnIgual.ForeColor = Color.FromArgb(45, 131, 210);
            }
            else if (Modo == 0)
            {
                BtnModo.Image = Properties.Resources.Claro_2;
                BtnModo.ImageAlign = ContentAlignment.MiddleLeft;
                BtnModo.Text = "Light";
                BtnModo.TextAlign = ContentAlignment.MiddleCenter;
                BtnModo.ForeColor = Color.FromArgb(84, 84, 84);
                this.BackColor = Color.FromArgb(54, 71, 79);
                BtnMenu.Image = Properties.Resources.Menu_2;
                BtnMinimizar.Image = Properties.Resources.Minimizar_2;
                BtnCerrar.Image = Properties.Resources.Cerrar_2;
                BtnMenu.BackColor = this.BackColor;
                PnlMenu.BackColor = Color.FromArgb(141, 163, 171);
                PnlPantalla.BackColor = Color.FromArgb(70, 90, 101);
                TxtEcuacionInicial.BackColor = Color.FromArgb(70, 90, 101);
                TxtResultado.BackColor = Color.FromArgb(70, 90, 101);
                TxtResultado.ForeColor = Color.White;
                BtnCalcular.BackColor = Color.FromArgb(47, 125, 49);
                BtnCalcular.ForeColor = Color.White;
                BtnAc.BackColor = Color.FromArgb(0, 105, 91);
                BtnDel.BackColor = Color.FromArgb(0, 105, 91);
                BtnD.BackColor = Color.FromArgb(2, 119, 189);
                Btn_e.BackColor = Color.FromArgb(2, 119, 189);
                BtnPotencia.BackColor = Color.FromArgb(2, 119, 189);
                BtnLn.BackColor = Color.FromArgb(2, 119, 189);
                BtnRaiz.BackColor = Color.FromArgb(2, 119, 189);
                BtnDXDY.BackColor = Color.FromArgb(2, 119, 189);
                BtnDYDX.BackColor = Color.FromArgb(2, 119, 189);
                BtnDX.BackColor = Color.FromArgb(2, 119, 189);
                BtnDY.BackColor = Color.FromArgb(2, 119, 189);
                Btnpiπ.BackColor = Color.FromArgb(2, 119, 189);
                BtnIntegral.BackColor = Color.FromArgb(2, 119, 189);
                BtnAbreParentesis.BackColor = Color.FromArgb(2, 119, 189);
                BtnCierraParentesis.BackColor = Color.FromArgb(2, 119, 189);
                BtnDivision.BackColor = Color.FromArgb(106, 27, 154);
                BtnMultiplicacion.BackColor = Color.FromArgb(106, 27, 154);
                BtnResta.BackColor = Color.FromArgb(106, 27, 154);
                BtnSuma.BackColor = Color.FromArgb(106, 27, 154);
                BtnX.BackColor = Color.FromArgb(93, 109, 125);
                BtnX.ForeColor = Color.White;
                Btn7.BackColor = Color.FromArgb(93, 109, 125);
                Btn7.ForeColor = Color.White;
                Btn8.BackColor = Color.FromArgb(93, 109, 125);
                Btn8.ForeColor = Color.White;
                Btn9.BackColor = Color.FromArgb(93, 109, 125);
                Btn9.ForeColor = Color.White;
                BtnY.BackColor = Color.FromArgb(93, 109, 125);
                BtnY.ForeColor = Color.White;
                Btn4.BackColor = Color.FromArgb(93, 109, 125);
                Btn4.ForeColor = Color.White;
                Btn5.BackColor = Color.FromArgb(93, 109, 125);
                Btn5.ForeColor = Color.White;
                Btn6.BackColor = Color.FromArgb(93, 109, 125);
                Btn6.ForeColor = Color.White;
                BtnW.BackColor = Color.FromArgb(93, 109, 125);
                BtnW.ForeColor = Color.White;
                Btn1.BackColor = Color.FromArgb(93, 109, 125);
                Btn1.ForeColor = Color.White;
                Btn2.BackColor = Color.FromArgb(93, 109, 125);
                Btn2.ForeColor = Color.White;
                Btn3.BackColor = Color.FromArgb(93, 109, 125);
                Btn3.ForeColor = Color.White;
                BtnPunto.BackColor = Color.FromArgb(93, 109, 125);
                BtnPunto.ForeColor = Color.White;
                BtnZ.BackColor = Color.FromArgb(93, 109, 125);
                BtnZ.ForeColor = Color.White;
                Btn0.BackColor = Color.FromArgb(93, 109, 125);
                Btn0.ForeColor = Color.White;
                BtnIgual.BackColor = Color.FromArgb(93, 109, 125);
                BtnIgual.ForeColor = Color.White;
            }
        }

        //---------------------------------------------------------------------
        //Botón que manda a llamar al método Modos.
        //---------------------------------------------------------------------
        private void BtnModo_Click(object sender, EventArgs e)
        {
            if (Modo == 0)
            {
                Modos(Modo);
                Modo = 1;
            }
            else if(Modo == 1)
            {
                Modos(Modo);
                Modo = 0;
            }
        }
        #endregion

        #region Botones de la calculadora.
        //---------------------------------------------------------------------
        //Permite mostrar la ecuación inicial en la parte superior
        //y el resultado de esta en la parte infeior de la pantalla.
        //---------------------------------------------------------------------
        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            TxtEcuacionInicial.Text = TxtResultado.Text;
            TxtResultado.Text = "";
        }

        //---------------------------------------------------------------------
        //Botón que permite borrar el último caracter.
        //---------------------------------------------------------------------
        private void BtnDel_Click(object sender, EventArgs e)
        {
            string Ec = TxtResultado.Text;
            if (Ec != "")
            {
                Ec = TxtResultado.Text.Remove(TxtResultado.Text.Length - 1);
                TxtResultado.Text = Ec;
            }
        }

        //---------------------------------------------------------------------
        //Botón que permite borrar todos los campos.
        //---------------------------------------------------------------------
        private void BtnAc_Click(object sender, EventArgs e)
        {
            TxtEcuacionInicial.Clear();
            TxtResultado.Clear();
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la d.
        //---------------------------------------------------------------------
        private void BtnD_Click(object sender, EventArgs e)
        {
            TxtResultado.Text += "d";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la e.
        //---------------------------------------------------------------------
        private void Btn_e_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "e";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la ^.
        //---------------------------------------------------------------------
        private void BtnPotencia_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "^";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar el  ln.
        //---------------------------------------------------------------------
        private void BtnLn_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "ln";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la √.
        //---------------------------------------------------------------------
        private void BtnRaiz_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "√";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la dx/dy.
        //---------------------------------------------------------------------
        private void BtnDXDY_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "dx/dy";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la dy/dx.
        //---------------------------------------------------------------------
        private void BtnDYDX_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "dy/dx";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la dy.
        //---------------------------------------------------------------------
        private void BtnDY_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "dy";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la dx.
        //---------------------------------------------------------------------
        private void BtnDX_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "dx";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar el PI.
        //---------------------------------------------------------------------
        private void Btnpiπ_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "π";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una multiplicación a la operación.
        //---------------------------------------------------------------------
        private void BtnMultiplicacion_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "*";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una división a la operación.
        //---------------------------------------------------------------------
        private void BtnDivision_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "/";
        }

        //---------------------------------------------------------------------
        //Botón que permite abrir parentesis.
        //---------------------------------------------------------------------
        private void BtnCierraParentesis_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ")";
        }

        //---------------------------------------------------------------------
        //Botón que permite cerrar parentesis.
        //---------------------------------------------------------------------
        private void BtnAbreParentesis_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "(";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la una integral.
        //---------------------------------------------------------------------
        private void BtnIntegral_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "∫";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar la una resta a la operación.
        //---------------------------------------------------------------------
        private void BtnResta_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "-";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 9 a la operación.
        //---------------------------------------------------------------------
        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "9";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 8 a la operación.
        //---------------------------------------------------------------------
        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "8";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 7 a la operación.
        //---------------------------------------------------------------------
        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "7";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una x a la operación.
        //---------------------------------------------------------------------
        private void BtnX_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "x";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una suma a la operación.
        //---------------------------------------------------------------------
        private void BtnSuma_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "+";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 6 a la operación.
        //---------------------------------------------------------------------
        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "6";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 5 a la operación.
        //---------------------------------------------------------------------
        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "5";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 4 a la operación.
        //---------------------------------------------------------------------
        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "4";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una y a la operación.
        //---------------------------------------------------------------------
        private void BtnY_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "y";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un punto a la operación.
        //---------------------------------------------------------------------
        private void BtnPunto_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + ".";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 3 a la operación.
        //---------------------------------------------------------------------
        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "3";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 2 a la operación.
        //---------------------------------------------------------------------
        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "2";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 1 a la operación.
        //---------------------------------------------------------------------
        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "1";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una w a la operación.
        //---------------------------------------------------------------------
        private void BtnW_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "w";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un igual a la operación.
        //---------------------------------------------------------------------
        private void BtnIgual_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "=";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar un 0 a la operación.
        //---------------------------------------------------------------------
        private void Btn0_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "0";
        }

        //---------------------------------------------------------------------
        //Botón que permite agregar una z a la operación.
        //---------------------------------------------------------------------
        private void BtnZ_Click(object sender, EventArgs e)
        {
            TxtResultado.Text = TxtResultado.Text + "z";
        }
        #endregion
    }
}
