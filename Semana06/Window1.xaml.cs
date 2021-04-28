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
using System.Windows.Shapes;
using Entity;
using Business;
using Semana06.ViewModel;

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ListaViewModel viewModel;
        public Window1()
        {
            InitializeComponent();
            viewModel = new ListaViewModel();
            this.DataContext = viewModel;
        }
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {
            BCategoria Bcategoria = null;
            try
            {
                Bcategoria = new BCategoria();
                dgvCategoria.ItemsSource = Bcategoria.List(0);
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                Bcategoria = null;
            }
        }
        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            MainWindow manCategoria = new MainWindow(0);
            manCategoria.ShowDialog();
            Cargar();
        }
        private void DgvCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idCategoria;
            var item = (Categoria)dgvCategoria.SelectedItem;
            if (null == item) return;
            idCategoria = Convert.ToInt32(item.IdCategoria);
            MainWindow manCategoria = new MainWindow(idCategoria);
            manCategoria.ShowDialog();
            Cargar();
        }
    }
}
