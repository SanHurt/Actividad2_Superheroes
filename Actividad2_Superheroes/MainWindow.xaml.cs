using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Actividad2_Superheroes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Crear enum para Siguiente y Anterior (pasar imágenes)
        private int numeroActualSuperHeroe = 1;
        List<Superheroe> superheroes;
        public enum CambiarPersonaje
        {
            Siguiente = 1,
            Anterior = -1,
            Actual = 0
        }
        public MainWindow()
        {
            InitializeComponent();
            buttonAceptar.IsDefault = true;
            superheroes = Superheroe.GetSamples();
            ActualizaLista((int)CambiarPersonaje.Actual);
           
        }
        private void AddSuperheroe(Superheroe s)
        {
            superheroes.Add(s);
            MessageBox.Show("Superhéroe añadido");
        }
        private void ActualizaLista(CambiarPersonaje tipo)
        {
            numeroActualSuperHeroe += (int)tipo;
            numeroHeroe.Text = numeroActualSuperHeroe + " / " + superheroes.Count;
            //Asignar dataContext. Actualizar nº de flecha (sig [1/3...])
            dockPanelVer.DataContext = superheroes[numeroActualSuperHeroe - 1];
        }

        private void Siguiente_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (numeroActualSuperHeroe < superheroes.Count)
                ActualizaLista(CambiarPersonaje.Siguiente);
        }

        private void Anterior_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (1 < numeroActualSuperHeroe)
                ActualizaLista(CambiarPersonaje.Anterior);
        }


        private void buttonAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxNombre.Text != "" && textBoxImagen.Text != "")
            {
                string nombre = textBoxNombre.Text;
                string imagen = textBoxImagen.Text;
                bool vengador = (bool)checkBoxVengador.IsChecked;
                bool xmen = (bool)checkBoxXMen.IsChecked;
                bool heroe = (bool)radioButtonHeroe.IsChecked;
                bool villano = (bool)radioButtonVillano.IsChecked;
                Superheroe superheroe = new Superheroe(nombre, imagen, vengador, xmen, heroe, villano);
                AddSuperheroe(superheroe);
            }
            else
                MessageBox.Show("Rellena los campos");
        }

        private void buttonLimpiar_Click(object sender, RoutedEventArgs e)
        {
            textBoxNombre.Text = "";
            textBoxImagen.Text = "";
            checkBoxVengador.IsChecked = false;
            checkBoxXMen.IsChecked = false;
            radioButtonHeroe.IsChecked = true;
            radioButtonVillano.IsChecked = false;
        }
        
    }
}
