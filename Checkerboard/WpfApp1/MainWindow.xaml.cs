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

namespace WpfApp1
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < 8; i++)                 // Прорисовка клеток
            {
                for (int j = 0; j < 8; j++)
                {
                    Rectangle rectangle = new Rectangle();

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            rectangle.Fill = Brushes.Black;
                        }
                        else
                        {
                            rectangle.Fill = Brushes.LightGoldenrodYellow;
                        }

                    }
                    else
                    {
                        if (j % 2 == 1)
                        {
                            rectangle.Fill = Brushes.Black;
                        }
                        else
                        {
                            rectangle.Fill = Brushes.LightGoldenrodYellow;

                        }
                    }

                    Grid.SetColumn(rectangle, j);
                    Grid.SetRow(rectangle, i);
                    grig.Children.Add(rectangle);




                }
            }

            for (int i = 0; i < 8; i++)                 // Прорисовка шашек, Интересно было сделать квадратами
            {
                for (int j = 0; j < 8; j++)
                {

                    Rectangle rect = new Rectangle();

                    if (i % 2 == 0 && i < 2)
                    {
                        if (j % 2 == 0)
                        {
                            rect.Fill = Brushes.Blue;
                        }
                    }
                    if (i % 2 == 1 && i < 2)
                    {
                        if (j % 2 == 1)
                        {
                            rect.Fill = Brushes.Blue;
                        }
                    }

                    if (i % 2 == 0 && i > 5)
                    {
                        if (j % 2 == 0)
                        {
                            rect.Fill = Brushes.Red;
                        }
                    }
                    if (i % 2 == 1 && i > 5)
                    {
                        if (j % 2 == 1)
                        {
                            rect.Fill = Brushes.Red;
                        }
                    }

                    rect.RadiusX = 90;
                    rect.RadiusY = 90;
                    
                    Grid.SetColumn(rect, j);
                    Grid.SetRow(rect, i);
                    grig.Children.Add(rect);
                }
            }
        }
    }
}
