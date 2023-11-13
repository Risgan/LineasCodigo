using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CodigosDeLinea
{
    public partial class Form1 : Form
    {
        string codeBinary = string.Empty;
        int nrzi_prev_bit = 0;
        bool cmi_polarity = false;
        bool ami_polarity = false;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //InputCode.Text = flowLayoutPanel1.Margin.Right.ToString();
            initializeCharts();
            LimpiarSeries();
            ShowCharts();

            //ShowBinaryPulseTrain("001110101010");

        }

        private void initializeCharts()
        {
            ChartNrz.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartNrzi.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartCmi.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartAmi.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartHdb3.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartManchester.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartManchesterDiferencial.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);

        }

        private void LimpiarSeries()
        {
            ChartNrz.Series[0].Points.Clear();
            ChartNrzi.Series[0].Points.Clear();
            ChartCmi.Series[0].Points.Clear();
            ChartAmi.Series[0].Points.Clear();
            ChartHdb3.Series[0].Points.Clear();
            ChartManchester.Series[0].Points.Clear();
            ChartManchesterDiferencial.Series[0].Points.Clear();
            nrzi_prev_bit = 0;
            cmi_polarity = false;
            ami_polarity = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            codeBinary = string.Empty;
            InputCode.Text = string.Empty;
            LimpiarSeries();
        }


        private void InputCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '0' && e.KeyChar != '1' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;                
            }
        }

        private void InputCode_TextChanged(object sender, EventArgs e)
        {
            codeBinary = InputCode.Text;
            Console.WriteLine(codeBinary);
            LimpiarSeries();
            ShowCode();
        }

        private void CheckNrz_CheckedChanged(object sender, EventArgs e)
        {
            ShowCharts();
        }

        private void ShowCharts()
        {
            ChartNrz.Visible = CheckNrz.Checked;
            ChartNrzi.Visible = CheckNrzi.Checked;
            ChartCmi.Visible = CheckCmi.Checked;
            ChartAmi.Visible = CheckAmi.Checked;
            ChartHdb3.Visible = CheckHdb3.Checked;
            ChartManchester.Visible = CheckManchester.Checked;
            ChartManchesterDiferencial.Visible = CheckManchesterDiferencial.Checked;
        }

        private void ShowCode()
        {
            for (int i = 0; i < codeBinary.Length; i++)
            {
                int yValue = (codeBinary[i] == '1') ? 1 : 0;
                AddNrz(yValue, i);
                AddNrzi(yValue, i);
                AddCmi(yValue, i);
                AddAmi(yValue, i);
                //binarySeries.Points.AddXY(i, yValue);
                //binarySeries.Points.AddXY(i + 1, yValue);
            }

        }

        private void AddNrz(int data, int point)
        {
            ChartNrz.Series[0].Points.AddXY(point, data);
            ChartNrz.Series[0].Points.AddXY(point+1, data);
        }

        private void AddNrzi(int data, int point)
        {
            if (data == 1)
            {
                if (nrzi_prev_bit == 1)
                {
                    nrzi_prev_bit = 0;
                }
                else
                {
                    nrzi_prev_bit = 1;
                }
            }
            ChartNrzi.Series[0].Points.AddXY(point, nrzi_prev_bit);
            ChartNrzi.Series[0].Points.AddXY(point + 1, nrzi_prev_bit);

        }

        private void AddCmi(int data, int point)
        {
            if (data == 1)
            {
                if (cmi_polarity)
                {
                    ChartCmi.Series[0].Points.AddXY(point, -1);
                    ChartCmi.Series[0].Points.AddXY(point + 1, -1);
                }
                else
                {
                    ChartCmi.Series[0].Points.AddXY(point, 1);
                    ChartCmi.Series[0].Points.AddXY(point + 1, 1);
                }
                cmi_polarity = !cmi_polarity;
            }
            else
            {
                ChartCmi.Series[0].Points.AddXY(point, -1);
                ChartCmi.Series[0].Points.AddXY(point + 0.5, -1);
                ChartCmi.Series[0].Points.AddXY(point + 0.5, 1);
                ChartCmi.Series[0].Points.AddXY(point + 1, 1);
            }
            //DataPoint newPoint = ChartCmi.Series[0].Points[ChartNrz.Series[0].Points.Count - 2];
            //newPoint.Label = data.ToString();
            //newPoint.SetCustomProperty("LabelStyle", "Top");

        }

        private void AddAmi(int data, int point)
        {
            if (data == 1)
            {
                if (ami_polarity)
                {
                    ChartAmi.Series[0].Points.AddXY(point, -1);
                    ChartAmi.Series[0].Points.AddXY(point + 1, -1);
                }
                else
                {
                    ChartAmi.Series[0].Points.AddXY(point, 1);
                    ChartAmi.Series[0].Points.AddXY(point + 1, 1);
                }
                ami_polarity = !ami_polarity;
            }
            else
            {
                ChartAmi.Series[0].Points.AddXY(point, 0);
                ChartAmi.Series[0].Points.AddXY(point + 1, 0);
            }            
        }


    }
}
