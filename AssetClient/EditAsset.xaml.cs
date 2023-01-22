using AssetClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
    /// Interaction logic for EditAsset.xaml
    /// </summary>
    public partial class EditAsset : Window
    {
        public EditAsset(Asset AssetSent)
        {
            InitializeComponent();
            setInputBoxes(AssetSent);
            GetDataForComboBoxes();
            FillComboBoxes();
            GetTransToTable();
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
                cmb_status.Items.Add( new KeyValuePair<int, string>(s.StatusId,s.Description) );               
            }

        }

        public void GetDataForComboBoxes()
        {
             Users = Data.Types.GetUsers();
             AssetTypes = Data.Types.GetAssetTypes();
             Statuses = Data.Types.GetStatuses();
        }

        public void setInputBoxes(Asset AssetSent)
        {
            Inp_AssetID.Text = AssetSent.assetId.ToString();
            Inp_description.Text = AssetSent.description.ToString();
            Inp_longDescription.Text = AssetSent.longDescription.ToString();
            cmb_assetType.SelectedValue = AssetSent.AssetTypeId;
            cmb_status.SelectedValue = AssetSent.StatusId;
            cmb_user.SelectedValue = AssetSent.UserId;




        }

        private void KeyUp(object sender, TextChangedEventArgs e)
        {

        }

        public void GetTransToTable()
        {
            List<Trans> Transactions = Data.TransAPI.GetTransByAssetID (int.Parse(Inp_AssetID.Text));
            GridTrans.ItemsSource = Transactions.Select(t => new {
                t.Comment,
                t.Created
                
            });

        }

        private void btn_addComment_Click(object sender, RoutedEventArgs e)
        {
            if (inp_comment.Text != "")
            {
                Data.TransAPI.PostTrans(int.Parse(Inp_AssetID.Text), inp_comment.Text);
                GetTransToTable();
                inp_comment.Text = "";

            }
        }

        private void btn_saveAsset_Click(object sender, RoutedEventArgs e)
        {
            List<Asset> Assets = Data.AssetsAPI.GetAllAssets("", "", "", "");
            Asset a = Assets.Find(a => a.assetId == int.Parse(Inp_AssetID.Text));

            Data.AssetsAPI.PutAsset(
                a.assetId, 
                Inp_description.Text, 
                Inp_longDescription.Text,
                int.Parse(cmb_assetType.SelectedValue.ToString()),
                int.Parse(cmb_status.SelectedValue.ToString()),
                int.Parse(cmb_user.SelectedValue.ToString())
                );
            this.Close();
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
