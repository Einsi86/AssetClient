using AssetClient.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssetClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Settings.port = "5000";
            FillGrid();
        }

       

        private void FillGrid()
        {
            List<Asset> Assets = Data.AssetsAPI.GetAllAssets(Inp_Description.Text, Inp_AssetType.Text, Inp_User.Text, Inp_status.Text);

         
            GridMain.ItemsSource = Assets.Select(a => new {
                a.assetId,
                a.description,
                a.AssetType,
                a.User,
                a.Status
            }); ;
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                FillGrid();
            }
            
        }

       

        private void GridMain_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
                var cellInfo = GridMain.SelectedCells[0];
                var id = ((cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text);
                

            List<Asset> Assets = Data.AssetsAPI.GetAllAssets("", "", "", "");
            Asset a = Assets.Find(a => a.assetId == int.Parse(id));


            var blur = new BlurEffect();
            var current = this.Background; blur.Radius = 25;
            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;

            EditAsset uw = new EditAsset(a);
            uw.Owner = ((MainWindow)Application.Current.MainWindow);
            uw.ShowDialog();

            this.Effect = null;
            this.Background = current;

            FillGrid();
        }

        private void btn_CreateAsset_Click(object sender, RoutedEventArgs e)
        {
            var blur = new BlurEffect();
            var current = this.Background; blur.Radius = 25;
            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;

            NewAsset uw = new NewAsset();
            uw.Owner = ((MainWindow)Application.Current.MainWindow);
            uw.ShowDialog();

            this.Effect = null;
            this.Background = current;

            FillGrid();
        }

        private void btn_CreateStatus_Click(object sender, RoutedEventArgs e)
        {
            var blur = new BlurEffect();
            var current = this.Background; blur.Radius = 25;
            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;

            NewStatus uw = new NewStatus();
            uw.Owner = ((MainWindow)Application.Current.MainWindow);
            uw.ShowDialog();

            this.Effect = null;
            this.Background = current;

            FillGrid();
        }

        private void btn_CreateUser_Click(object sender, RoutedEventArgs e)
        {
            var blur = new BlurEffect();
            var current = this.Background; blur.Radius = 25;
            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;

            NewUser uw = new NewUser();
            uw.Owner = ((MainWindow)Application.Current.MainWindow);
            uw.ShowDialog();

            this.Effect = null;
            this.Background = current;

            FillGrid();
        }

        private void btn_CreateAssetType_Click(object sender, RoutedEventArgs e)
        {
            
            var blur = new BlurEffect();
            var current = this.Background; blur.Radius = 25;
            this.Background = new SolidColorBrush(Colors.DarkGray);
            this.Effect = blur;
            

            NewType uw = new NewType();
            uw.Owner = ((MainWindow)Application.Current.MainWindow);
            uw.ShowDialog();
            
            this.Effect = null;
            this.Background = current;
            

            FillGrid();
        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
