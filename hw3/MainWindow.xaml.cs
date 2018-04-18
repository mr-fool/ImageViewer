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

namespace hw3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            scroll.Visibility = Visibility.Hidden;

            List<string> imageFileNames = AssemblyManager.GetAllEmbeddedResourceFilesEndingWith(".png", ".jpg");

            foreach (string fileName in imageFileNames)
            {
                Image image = AssemblyManager.GetImageFromEmbeddedResources(fileName);
                string photoName = fileName.Replace(".png", "").Split('.').Last();
                PhotoTile thumbnail = new PhotoTile();
                thumbnail.ImageView.BeginInit();
                thumbnail.ImageView.Source = image.Source;
                thumbnail.ImageView.EndInit();
                thumbnail.Title.Text = photoName;

                // PhotoTile thumbnail = new PhotoTile(image, photoName);
                // thumbnail.MouseLeftButtonDown += OnThumbnailClicked;

                this.PhotoViewerGrid.Children.Add(thumbnail);
                thumbnail.MouseDown += new MouseButtonEventHandler(Tile_MouseDown);
            }
        }
        private void Tile_MouseDown(object sender, RoutedEventArgs e)
        {

            SplashGrid.Visibility = Visibility.Collapsed;
            PhotoGrid.Visibility = Visibility.Collapsed;
            PhotoTile photo = new PhotoTile();
            photo.ImageView.Source = ((PhotoTile)sender).ImageView.Source;
            back.Click += new RoutedEventHandler(Back);
            
            this.MainGrid.Children.Add(photo);

        }
        private void Button_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Buttom_Click1(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ViewPhoto(object sender, RoutedEventArgs e)
        {
            SplashGrid.Visibility = Visibility.Hidden;
            PhotoGrid.Visibility = Visibility.Visible;
            scroll.Visibility = Visibility.Visible;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            PhotoGrid.Visibility = Visibility.Visible;
            //PhotoViewerGrid.Visibility = Visibility.Hidden;
           // PhotoTile photo = new PhotoTile();
            MainGrid.Children.Remove(PhotoViewerGrid);
            //photo = null;
            
           
            
            
        }
    }
}
