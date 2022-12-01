using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_de_ecuaciones_diferenciales
{
    public partial class FrmLoadingScreen : Form
    {
        public FrmLoadingScreen()
        {
            InitializeComponent();
        }

        private void TmrLoadingScreen_Tick(object sender, EventArgs e)
        {
            PbLoading.Value += 1;

            if (PbLoading.Value > 15)
            {
                LblLoadingStatus.Text = "Añadiendo botones...";
            }

            if (PbLoading.Value > 35)
            {
                LblLoadingStatus.Text = "Analizando fórmulas...";
            }

            if (PbLoading.Value > 65)
            {
                LblLoadingStatus.Text = "        Comprobando\n          soluciones...";
            }

            if (PbLoading.Value > 90)
            {
                LblLoadingStatus.Text = "Iniciando calculadora...";
            }

            if (PbLoading.Value == 100)
            {
                LblLoadingStatus.Text = "¡Listo!";
                FrmCalculator Flm = new FrmCalculator();
                Flm.Show();
                this.Hide();
                TmrLoadingScreen.Stop();
            }
        }
    }
}
