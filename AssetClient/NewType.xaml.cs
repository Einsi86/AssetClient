using AssetClient.Models;
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
using System.Windows.Shapes;

namespace AssetClient
{
    /// <summary>
    /// Interaction logic for NewType.xaml
    /// </summary>
    public partial class NewType : Window
    {
        public NewType()
        {
            InitializeComponent();
            FillTypeGrid();
        }

        public void FillTypeGrid()
        {
            List<AssetType> Statuses = Data.Types.GetAssetTypes();
            GridType.ItemsSource = Statuses;
        }

        private void btn_addStatus_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_saveAsset_Click(object sender, RoutedEventArgs e)
        {
            if (Inp_description.Text == "")
            {
                return;
            }
            Data.Types.PostAssetType(Inp_description.Text);
            FillTypeGrid();
            Inp_description.Text = "";
        }
    }
}
