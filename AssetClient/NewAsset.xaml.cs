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
    /// Interaction logic for NewAsset.xaml
    /// </summary>
    public partial class NewAsset : Window
    {
        public NewAsset()
        {
            InitializeComponent();
            GetDataForComboBoxes();
            FillComboBoxes();
        }

        List<User> Users;
        List<AssetType> AssetTypes;
        List<Status> Statuses;

        public void FillComboBoxes()
        {
            cmb_user.SelectedValuePath = "Key";
            cmb_user.DisplayMemberPath = "Value";

            cmb_assetType.SelectedValuePath = "Key";
            cmb_assetType.DisplayMemberPath = "Value";

            cmb_status.SelectedValuePath = "Key";
            cmb_status.DisplayMemberPath = "Value";


            foreach (var u in Users)
            {
                cmb_user.Items.Add(new KeyValuePair<int, string>(u.UserId, u.Name));
            }
            foreach (var a in AssetTypes)
            {
                cmb_assetType.Items.Add(new KeyValuePair<int, string>(a.AssetTypeId, a.Description));
            }

            foreach (var s in Statuses)
            {
                cmb_status.Items.Add(new KeyValuePair<int, string>(s.StatusId, s.Description));
            }

        }

        public void GetDataForComboBoxes()
        {
            Users = Data.Types.GetUsers();
            AssetTypes = Data.Types.GetAssetTypes();
            Statuses = Data.Types.GetStatuses();
        }


        private void btn_saveAsset_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_user.SelectedValue == null || cmb_user.SelectedValue == null || cmb_status.SelectedValue == null || Inp_description.Text == "" )
            {
                MessageBox.Show("Vanta að fylla út í reiti!");
                return;
            }


            AssetPost a = new AssetPost();
            a.description = Inp_description.Text;
            a.longDescription = Inp_longDescription.Text;
            a.AssetTypeId = int.Parse(cmb_assetType.SelectedValue.ToString());
            a.UserId = int.Parse(cmb_user.SelectedValue.ToString());
            a.StatusId = int.Parse(cmb_status.SelectedValue.ToString());

            Data.AssetsAPI.PostAsset(a);

            this.Close();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
