using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matOsnovlab1
{
    public partial class Form1 : Form
    {
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

            double x = 0.001;
            double y= 0.001;
            double y2= 0.001;
            double a= 2.8;

        
            while (x < 1)
            {
                y = a * (x-x*x);
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
           for(double i=0;i<10;i+=1)
            {
                y = a * (x - x * x);
               
                chart2.Series[2].Points.AddXY(x, y); //Рисуем паутину

                x = y;
                chart2.Series[2].Points.AddXY(x, y);
            }
        }
    }
}
