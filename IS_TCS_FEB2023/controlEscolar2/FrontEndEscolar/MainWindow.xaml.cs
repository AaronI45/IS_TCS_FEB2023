using ServicioControlEscolar;
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

namespace FrontEndEscolar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServicioControlEscolar.Service1Client servicio;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClicIniciarSesion(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Password;
            if (!ChecarCamposVacios(username, password))
            {
                //iniciar sesion
            }

        }

        private bool ChecarCamposVacios(string username, string password)
        {
            bool hayCamposVacios = false;
            if (string.IsNullOrEmpty(username))
            {
                lbUsername.Content = "Campo requerido";
                hayCamposVacios = true;
            }
            else
            {
                lbUsername.Content = "";
            }
            if (string.IsNullOrEmpty(password))
            {
                lbPassword.Content = "Campo requerido";
                hayCamposVacios = true;
            }
            else
            {
                lbPassword.Content = "";
            }
            return hayCamposVacios;
        }
    }
}
