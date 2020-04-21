using System;
using System.Collections.Generic;
using System.Data;
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
using Bussiness;

namespace Semana04_Capas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                DateTime fechaFin = Convert.ToDateTime(txtFechaFin.Text);
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(fechaInicio, fechaFin);
            }
            catch(Exception)
            {
                MessageBox.Show("Comunicar con el admin");
            }
            finally
            {
                bPedido = null;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BDetallePedido bDetallePedido = null;
            try
            {
                bDetallePedido = new BDetallePedido();
                int idPedido;
                var item = dgvPedido.SelectedItem as DataRowView;
                if (item == null) return;
                idPedido = Convert.ToInt32(item.Row["IdPedido"]);
                dgvDetallePedido.ItemsSource = bDetallePedido.GetDetallePedidosPorId(idPedido);
                txtTotal.Text = Convert.ToString(bDetallePedido.GetDetalleTotalPorId(idPedido));
            }
            catch(Exception)
            {
                MessageBox.Show("Comunicar con el admin");
            }
            finally
            {
                bDetallePedido = null;
            }
        }
    }
}
