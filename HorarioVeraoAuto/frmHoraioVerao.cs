using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HorarioVeraoAuto;


namespace HorarioVeraoAuto
{
    public partial class frmHoraioVerao : Form
    {
        public frmHoraioVerao()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            if (Int32.TryParse(txtAno.Text, out int Ano))
            {
                // Limpa text box
                txtResultado.Text = "Horário de Verão Brasileiro em " + Ano.ToString();
                txtResultado.AppendText("\r\n\r\n");
                // Domingo de Carnaval
                DateTime V_car = HorarioVerao.ObterDomingoDeCarnaval(Ano);
                txtResultado.AppendText("Domingo de Carnaval:          " + V_car.ToShortDateString());
                txtResultado.AppendText("\r\n\r\n");

                // Pascoa do Senhor
                DateTime V_pas = HorarioVerao.ObterDomingoDePascoa(Ano);
                txtResultado.AppendText("Domingo de Pascoa:            " + V_pas.ToShortDateString());
                txtResultado.AppendText("\r\n\r\n");


                // Calcula Inicio do Horário de Verão
                DateTime V_ini = HorarioVerao.ObterInicioHorarioVerao(Ano);
                txtResultado.AppendText("Início do Horário de Verão:   " + V_ini.ToShortDateString());
                txtResultado.AppendText("\r\n\r\n");

                // Calcula Fim do Horário de Verão
                DateTime V_fim = HorarioVerao.ObterFimHorarioVerao(Ano);
                txtResultado.AppendText("Término do Horário de Verão:  " + V_fim.ToShortDateString());
                txtResultado.AppendText("\r\n\r\n");

            }
            else
            {
                MessageBox.Show("Erro ao Converter Ano");
            }



            
        }
    }
}
