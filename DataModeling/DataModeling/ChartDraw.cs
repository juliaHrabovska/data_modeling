using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataModeling
{
    class ChartDraw
    {
        public static void showChart(List<double> chartDots, String seriesName, SeriesChartType type, Color color, Object chartObj)
        {
            Series series = new Series(seriesName);
            series.ChartType = type;
            series.Color = color;
            Chart chart = (Chart)chartObj;
            chart.Series.Add(series);
            chart.ChartAreas[0].AxisX.Minimum = Math.Round(chartDots[0], 0);
            chart.ChartAreas[0].AxisX.Maximum = Math.Round(chartDots[chartDots.Count - 2], 0);
            for (int i = 0; i < chartDots.Count; i += 2)
            {
                series.Points.AddXY(chartDots[i], chartDots[i + 1]);
            }
        }

    }
}
