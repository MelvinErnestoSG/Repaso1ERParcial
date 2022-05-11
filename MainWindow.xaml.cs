using System.Windows;
using Repaso1ERParcial.UI.Registros;
using Repaso1ERParcial.UI.Consultas;

namespace Repaso1ERParcial
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

        private void RegistroColoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rColores rColores = new rColores();
            rColores.Show();
        }

        private void ConsultaColoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cColores cColores = new cColores();
            cColores.Show();
        }
    }
}
