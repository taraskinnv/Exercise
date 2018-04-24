using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }
        DataClasses1DataContext db = new DataClasses1DataContext();
        private void Window_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            string [] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
             for (int i=0; i<files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                if (info.Extension == ".PNG"|| info.Extension == ".jpg" || info.Extension == ".png")
                {
                    listbox.Items.Add(files[i]);
                    Picture picture = new Picture();
                    picture.picture1 = files[i];
                    db.Picture.InsertOnSubmit(picture);
                    db.SubmitChanges();
                }
            }
        }

        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string lb = ((sender as ListBox).SelectedItem as string);
                image.Source = new BitmapImage(new Uri(lb));
            }
            catch (Exception){}
        }

        public void Refresh()
        {
            var pic = db.Picture.ToArray<Picture>();
            foreach (var v in pic)
            {
                listbox.Items.Add(v.picture1.ToString());
            }
        }
    }
}
