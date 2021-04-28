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
using Entity;
using Business;
using Semana06.ViewModel;

namespace Semana06
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManCategoriaViewModel viewModel;
        public int ID { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ManCategoriaViewModel();
            this.DataContext = viewModel;
        }
        public MainWindow(int Id)
        {
            ID = Id;
            if (ID > 0)
            {
                BCategoria bCategoria = new BCategoria();
                List<Categoria> categorias = new List<Categoria>();
                categorias = bCategoria.List(ID);
                if (categorias.Count > 0)
                {
                    lblID.Content = categorias[0].IdCategoria.ToString();
                    txtNombre.Text = categorias[0].NombreCategoria;
                    txtDescripcion.Text = categorias[0].Descripcion;
                }
            }
        }
        private void BtnConsultar_Click(object sender, RoutedEventArgs e) 
        {
            
        }
        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BCategoria Bcategoria = null;
            bool result = true;
            try
            {
                Bcategoria = new BCategoria();
                if (ID > 0)
                    result = Bcategoria.Actualizar(new Categoria { IdCategoria = ID, NombreCategoria = txtNombre.Text });
                else
                    result = Bcategoria.Insertar(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });

                if (!result)
                    MessageBox.Show("Comunicarse con el Administrador");

                Close();
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
        private void BntCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
