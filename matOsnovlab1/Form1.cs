using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace matOsnovlab1
{
     
    public partial class Form1 : Form
    {
        double Function(double x, double a)
        {
            return a * (x - x * x);
        }
        public Form1()
        {
            InitializeComponent();
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series.Add("serise");
            chart2.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series.Add("serise2");
            chart2.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            chart2.Series.Add("serise3");
            chart2.Series[3].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;


        }

        private void button2_Click(object sender, EventArgs e)
        {

            double[] a = { 2.8, 3.2 , 3.5, 3.55, 3.98 };
            for (int r1 = 0; r1 < a.Length; r1 += 1)
            {
                double x = 0.001;
                double y = 0.001;
                double y2 = 0.001;
                // double a = 2.8;123123


                this.chart2.Series[0].Points.Clear();
                this.chart2.Series[1].Points.Clear();
                this.chart2.Series[2].Points.Clear();

                while (x < 1)
                {
                    y = Function(x, a[r1]);
                    //y = a[r1] * (x - x * x);
                    x = x + 0.001;
                    chart2.Series[0].Points.AddXY(x, y); //Рисуем параболу
                }

                x = 0.001;
                y = 0.001;

                chart2.Series[1].Color = Color.Red;
                while (x < 1)
                {
                    y = x;
                    x = x + 0.001;
                    chart2.Series[1].Points.AddXY(x, y); //Рисуем линию
                }

                x = 0.05;
                y = 0;

                chart2.Series[2].Color = Color.Lime;
                for (int i = 0; i < 10; i += 1)
                {
                    y = Function(x, a[r1]);
                   // y = a[r1] * (x - x * x);

                    chart2.Series[2].Points.AddXY(x, y); //Рисуем паутину

                    x = y;
                    chart2.Series[2].Points.AddXY(x, y);
                }
                string testStr = "data/" + r1 + "a.jpeg";
                chart2.SaveImage(testStr, System.Drawing.Imaging.ImageFormat.Jpeg);
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double x = 0.001;
            double y;
            // double a = 1;
            double aDef;
            //this.chart2.ChartAreas[3].AxisY.Minimum = 2;

           
            double[] a2 = { 0.5, 1, 1.3, 1.5, 2 };

            for (int r1 = 0; r1 < a2.Length; r1 += 1)
            {
                progressBar1.Maximum += Convert.ToInt32(((4-a2[r1])/0.00001));
            }

            progressBar1.Value = 0;

            for (int r1 = 0; r1 < a2.Length; r1 += 1)
            {

                this.chart2.Series[3].Points.Clear();
                this.chart2.Series[3].MarkerSize = 2;
                aDef = a2[r1];
                y = x;
                while (a2[r1] < 4)
                {
                    x = y;
                    y = Function(x, a2[r1]);
                    if (a2[r1] > (aDef + 1.5))
                    {
                        chart2.Series[3].Points.AddXY(a2[r1], x); //Рисуем параболу
                        //Thread.Sleep(50);
                    }
                    a2[r1] += 0.00001;

                    progressBar1.Value += 1;
                }
                string testStr = "data/" + r1 + "aZadan2.jpeg";
                chart2.SaveImage(testStr, System.Drawing.Imaging.ImageFormat.Jpeg);
            }

        }
    }
}
