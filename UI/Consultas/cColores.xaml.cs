using Repaso1ERParcial.BLL;
using Repaso1ERParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Repaso1ERParcial.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cColores.xaml
    /// </summary>
    public partial class cColores : Window
    {
        public cColores()
        {
            InitializeComponent();
        }

        private void ConsultarColoresButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Colores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        listado = ColoresBLL.GetList(c => true);
                        break;

                    case 1:
                        listado = ColoresBLL.GetList(c => c.ColoresId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 2:                       
                        listado = ColoresBLL.GetList(c => c.Nombre.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                MessageBox.Show("Debe Guardar Información En La Base De Datos.", "Buscando", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
