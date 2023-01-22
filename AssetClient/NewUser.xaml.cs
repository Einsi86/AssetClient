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
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_saveAsset_Click(object sender, RoutedEventArgs e)
        {
            if (Inp_Name.Text == "" || Inp_Email.Text == "" || Inp_Phone.Text == "" || Inp_Location.Text == "")
            {
                MessageBox.Show("Please fill out all fields!");
                return;
            }
            
            UserPost u = new UserPost();
            u.Name = Inp_Name.Text;
            u.Email = Inp_Email.Text;
            u.Phone = Inp_Phone.Text;
            u.Location = Inp_Location.Text;

            Data.Types.PostUser(u);
            this.Close();
        }
    }
}
