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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = flowLayoutPanel1.Margin.Right.ToString();
            initializeCharts();
            ShowBinaryPulseTrain("001110101010");

        }

        private void ShowBinaryPulseTrain(string binarySequence)
        {
            // Configurar el gráfico
            //ChartNrz.Series.Clear();
            //ChartNrz.ChartAreas.Clear();

            //ChartArea chartArea = new ChartArea();
            //ChartNrz.ChartAreas.Add(chartArea);

            //Series binarySeries = new Series("BinaryPulseTrain");
            //binarySeries.ChartType = SeriesChartType.StepLine;

            //// Convertir la secuencia binaria en una serie de puntos para el gráfico
            //for (int i = 0; i < binarySequence.Length; i++)
            //{
            //    int yValue = (binarySequence[i] == '1') ? 1 : 0;
            //    binarySeries.Points.AddXY(i, yValue);
            //    binarySeries.Points.AddXY(i + 1, yValue);
            //}

            //ChartNrz.Series.Add(binarySeries);

            //// Configurar ejes y título
            //chartArea.AxisX.Title = "Bits";
            //chartArea.AxisY.Title = "Nivel";
            //ChartNrz.Titles.Add("Binary Pulse Train");

            //// Configurar el grid
            //chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            //chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            //chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            //// Ajustar el rango del eje Y
            //chartArea.AxisY.Minimum = -2;
            //chartArea.AxisY.Maximum = 2;
            //chartArea.AxisY.Interval = 1; // Establecer el intervalo del eje Y a 1

            //// Cambiar el color y el grosor de la línea
            //binarySeries.Color = System.Drawing.Color.Red;
            //binarySeries.BorderWidth = 2;

            //Size screenSize = SystemInformation.PrimaryMonitorSize;
            //Size windowSize = this.Size;


            // Ajustar el tamaño del gráfico
            //ChartNrz.Size = new System.Drawing.Size(flowLayoutPanel1.Width-(flowLayoutPanel1.Margin.Right*2), 400);
        }

        private void initializeCharts()
        {
            ChartNrz.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartNrz.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartCmi.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartAmi.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartHdb3.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartManchester.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);
            ChartManchesterDiferencial.Size = new System.Drawing.Size(flowLayoutPanel1.Width - (flowLayoutPanel1.Margin.Right * 2), 400);

        }

    }
}
