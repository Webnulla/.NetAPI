using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Jobs;
using MetricsAgent.Requests;
using MetricsServiceUi.Client;

namespace MetricsServiceUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Cpu(TimeSpan from, TimeSpan to)
        {
            ManagerUi managerUi = new ManagerUi();
            var request = managerUi.GetCpuMetrics(new MetricsCreateRequest<CpuMetricsController>(from, to));
            CpuChart.ColumnSeriesValues[0].Values.Add(request.Metrics);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cpu(TimeSpan.MinValue, TimeSpan.MaxValue);                       
        }

        private void ButtonDontPush_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RamButton_Click(object sender, RoutedEventArgs e)
        {
            CpuChart.ColumnSeriesValues[0].Values.Add(99d);
        }
    }
}