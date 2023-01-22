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
    /// Interaction logic for NewStatus.xaml
    /// </summary>
    public partial class NewStatus : Window
    {
        public NewStatus()
        {
            InitializeComponent();
            FillStatusGrid();
        }

        public void FillStatusGrid()
        {
            List<Status> Statuses = Data.Types.GetStatuses();
            GridStatus.ItemsSource = Statuses;
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
            Data.Types.PostStatus(Inp_description.Text);
            FillStatusGrid();
            Inp_description.Text = "";
        }
    }
}
