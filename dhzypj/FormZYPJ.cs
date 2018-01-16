using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace dhzypj
{
    public partial class FormZYPJ : Form
    {
        List<string> m_sxName = new List<string>();
        List<TextBox> m_sxCtrl = new List<TextBox>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public FormZYPJ()
        {
            InitializeComponent();
            m_sxName.Add("气质");
            m_sxName.Add("智力");
            m_sxName.Add("内力");
            m_sxName.Add("耐力");
            m_sxName.Add("道德");
            m_sxName.Add("叛逆");
            m_sxName.Add("名气");

            m_sxCtrl.Add(txtQZ);
            m_sxCtrl.Add(txtZL);
            m_sxCtrl.Add(txtNL);
            m_sxCtrl.Add(txtNaiL);
            m_sxCtrl.Add(txtDD);
            m_sxCtrl.Add(txtPN);
            m_sxCtrl.Add(txtMQ);
        }

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormZYPJ_Load(object sender, EventArgs e)
        {
            string sConfigFile = Application.StartupPath + @"/config.cfg";
            if (File.Exists(sConfigFile))
            {
                StreamReader sr = new StreamReader(sConfigFile, Encoding.UTF8);
                txtQZ.Text = sr.ReadLine();
                txtZL.Text = sr.ReadLine();
                txtNL.Text = sr.ReadLine();
                txtNaiL.Text = sr.ReadLine();
                txtDD.Text = sr.ReadLine();
                txtPN.Text = sr.ReadLine();
                txtMQ.Text = sr.ReadLine();
                txtWX.Text = sr.ReadLine();
                sr.Close();
                sr.Dispose();
            }
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormZYPJ_FormClosing(object sender, FormClosingEventArgs e)
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
                int nWX = string.IsNullOrEmpty(txtWX.Text) ? 0 : Convert.ToInt32(txtWX.Text);

                string sConfigFile = Application.StartupPath + @"/config.cfg";
                if (File.Exists(sConfigFile))
                    File.Delete(sConfigFile);

                StreamWriter sw = new StreamWriter(sConfigFile, true, Encoding.UTF8);
                sw.WriteLine(nQZ.ToString());
                sw.WriteLine(nZL.ToString());
                sw.WriteLine(nNL.ToString());
                sw.WriteLine(nNaiL.ToString());
                sw.WriteLine(nDD.ToString());
                sw.WriteLine(nPN.ToString());
                sw.WriteLine(nMQ.ToString());
                sw.WriteLine(nWX.ToString());
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// 检查属性录入框中数据的正确性
        /// </summary>
        /// <param name="txtBox"></param>
        private void CheckValueValid(TextBox txtBox)
        {
            try
            {
                string sText = txtBox.Text;
                if (string.IsNullOrEmpty(sText))
                    return;

                int nValue = Convert.ToInt32(sText);

                //属性值不能超过1200
                if (nValue > 1200)
                    txtBox.Text = "1200";

                //属性值不能低于0
                if (nValue < 0)
                    txtBox.Text = "";

                //去掉属性值前面多余的0
                if (sText.CompareTo("0") != 0 && sText.TrimStart('0').CompareTo(sText) != 0)
                    txtBox.Text = sText.TrimStart('0');
            }
            catch (Exception ex)
            {
                //异常录入置空属性值
                txtBox.Text = "";
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// 气质
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQZ_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 智力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtZL_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 名气
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMQ_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 叛逆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPN_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 内力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNL_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 耐力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNaiL_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 道德
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDD_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 玩性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWX_TextChanged(object sender, EventArgs e)
        {
            CheckValueValid(sender as TextBox);
            ShowCurZYPJ();
        }

        /// <summary>
        /// 计算并显示当前职业评价
        /// </summary>
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
                int nWX = string.IsNullOrEmpty(txtWX.Text) ? 0 : Convert.ToInt32(txtWX.Text);

                int nZYPJ = CalcZYPJ(nQZ, nZL, nNL, nNaiL, nDD, nPN, nMQ, nWX);
                lblCurZYPJ.Text = nZYPJ.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        /// <summary>
        /// 职业评价计算函数
        /// </summary>
        /// <param name="nQZ">气质</param>
        /// <param name="nZL">智力</param>
        /// <param name="nNL">内力</param>
        /// <param name="nNaiL">耐力</param>
        /// <param name="nDD">道德</param>
        /// <param name="nPN">叛逆</param>
        /// <param name="nMQ">名气</param>
        /// <returns>职业评价</returns>
        private int CalcZYPJ(int nQZ, int nZL, int nNL, int nNaiL, int nDD, int nPN, int nMQ, int nWX)
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

            double dZYPJ = 600.0 * Math.Pow(sx[6], 0.2) + 180.0 * Math.Pow(sx[5], 0.2) + 150.0 * Math.Pow(sx[4], 0.2) + 120.0 * Math.Pow(sx[3], 0.2) + 90.0 * Math.Pow(sx[2], 0.2) + 60.0 * Math.Pow(sx[1], 0.2) + 30.0 * Math.Pow(sx[0], 0.2);
            int nZYPJ = (int)dZYPJ - 20 * nWX;
            return nZYPJ < 0 ? 0 : nZYPJ;
        }

        /// <summary>
        /// 计算如何加点才能职业评价最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> sx = new List<int>();
                sx.Add(string.IsNullOrEmpty(txtQZ.Text) ? 0 : Convert.ToInt32(txtQZ.Text));
                sx.Add(string.IsNullOrEmpty(txtZL.Text) ? 0 : Convert.ToInt32(txtZL.Text));
                sx.Add(string.IsNullOrEmpty(txtNL.Text) ? 0 : Convert.ToInt32(txtNL.Text));
                sx.Add(string.IsNullOrEmpty(txtNaiL.Text) ? 0 : Convert.ToInt32(txtNaiL.Text));
                sx.Add(string.IsNullOrEmpty(txtDD.Text) ? 0 : Convert.ToInt32(txtDD.Text));
                sx.Add(string.IsNullOrEmpty(txtPN.Text) ? 0 : Convert.ToInt32(txtPN.Text));
                sx.Add(string.IsNullOrEmpty(txtMQ.Text) ? 0 : Convert.ToInt32(txtMQ.Text));
                int nWX = string.IsNullOrEmpty(txtWX.Text) ? 0 : Convert.ToInt32(txtWX.Text);

                int nJD = string.IsNullOrEmpty(txtJD.Text) ? 0 : Convert.ToInt32(txtJD.Text);

                int nMaxZYPJ = 0;
                int nMaxZYPJIndex = 0;
                for (int i = 0; i < sx.Count; i++)
                {
                    int[] sxCopy = new int[7];
                    sx.CopyTo(sxCopy);
                    sxCopy[i] += nJD;
                    if (sxCopy[i] > 1200)
                        sxCopy[i] = 1200;

                    int nZYPJ = CalcZYPJ(sxCopy[0], sxCopy[1], sxCopy[2], sxCopy[3], sxCopy[4], sxCopy[5], sxCopy[6], nWX);

                    if (nZYPJ > nMaxZYPJ)
                    {
                        nMaxZYPJ = nZYPJ;
                        nMaxZYPJIndex = i;
                    }
                }

                if (MessageBox.Show("为[" + m_sxName[nMaxZYPJIndex] + "]加" + nJD.ToString() + "点会获得最大职业评价：" + nMaxZYPJ.ToString() + "，是否立即加点？", "提示", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    m_sxCtrl[nMaxZYPJIndex].Text = (sx[nMaxZYPJIndex] + nJD).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

    }
}
