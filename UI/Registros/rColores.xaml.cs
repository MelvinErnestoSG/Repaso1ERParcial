using Repaso1ERParcial.BLL;
using Repaso1ERParcial.Entidades;
using System.Windows;

namespace Repaso1ERParcial.UI.Registros
{
    /// <summary>
    /// Interaction logic for rColores.xaml
    /// </summary>
    public partial class rColores : Window
    {
        private Colores color = new Colores();

        public rColores()
        {
            InitializeComponent();
            this.DataContext = color;
        }

        private void Limpiar()
        {
            this.color = new Colores();
            this.DataContext = color;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreTextBox.Text.Length == 0)
            {
                MessageBox.Show("El Campo Nombre No puede Estar Vacio.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                esValido = false;
            }

            return esValido;
        }   

        private void BuscarColoresButton_Click(object sender, RoutedEventArgs e)
        {
            var Encontrado = ColoresBLL.Buscar(Utilidades.ToInt(ColorIdTextBox.Text));

            if (Encontrado != null)
            {
                this.color = Encontrado;
                MessageBox.Show("Color Encontrado.");
            }
            else
            {
                this.color = new Colores();
                MessageBox.Show("Color No Encontrado.");
            }
            this.DataContext = this.color;
        }

        private void NuevoColoresButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarColoresButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            bool Guardo = ColoresBLL.Guardar(color);

            if (Guardo)
            {
                Limpiar();
                MessageBox.Show("Transacción Exitosa!", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Transacción Fallida!", "Fallo.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
