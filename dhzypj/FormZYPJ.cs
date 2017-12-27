using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dhzypj
{
    public partial class FormZYPJ : Form
    {
        public FormZYPJ()
        {
            InitializeComponent();
        }

        private void txtQZ_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void txtZL_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void txtMQ_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void txtPN_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void txtNL_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void txtNaiL_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void txtDD_TextChanged(object sender, EventArgs e)
        {
            ShowCurZYPJ();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ShowCurZYPJ()
        {
            try
            {
                int nQZ = string.IsNullOrEmpty(txtQZ.Text) ? 0 : Convert.ToInt32(txtQZ.Text);
                int nZL = string.IsNullOrEmpty(txtZL.Text) ? 0 : Convert.ToInt32(txtZL.Text);
                int nNL = string.IsNullOrEmpty(txtNL.Text) ? 0 : Convert.ToInt32(txtNL.Text);
                int nNaiL = string.IsNullOrEmpty(txtNaiL.Text) ? 0 : Convert.ToInt32(txtNaiL.Text);
                int nDD = string.IsNullOrEmpty(txtDD.Text) ? 0 : Convert.ToInt32(txtDD.Text);
                int nPN = string.IsNullOrEmpty(txtPN.Text) ? 0 : Convert.ToInt32(txtPN.Text);
                int nMQ = string.IsNullOrEmpty(txtMQ.Text) ? 0 : Convert.ToInt32(txtMQ.Text);

                int nZYPJ = CalcZYPJ(nQZ, nZL, nNL, nNaiL, nDD, nPN, nMQ);
                lblCurZYPJ.Text = nZYPJ.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private int CalcZYPJ(int nQZ, int nZL, int nNL, int nNaiL, int nDD, int nPN, int nMQ)
        {
            List<double> sx = new List<double>();

            sx.Add(nQZ);
            sx.Add(nZL);
            sx.Add(nNL);
            sx.Add(nNaiL);
            sx.Add(nDD);
            sx.Add(nPN);
            sx.Add(nMQ);

            sx.Sort();

            double nZYPJ = 600.0 * Math.Pow(sx[6], 0.2) + 180.0 * Math.Pow(sx[5], 0.2) + 150.0 * Math.Pow(sx[4], 0.2) + 120.0 * Math.Pow(sx[3], 0.2) + 90.0 * Math.Pow(sx[2], 0.2) + 60.0 * Math.Pow(sx[1], 0.2) + 30.0 * Math.Pow(sx[0], 0.2);
            return (int)nZYPJ;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

        }
    }
}
