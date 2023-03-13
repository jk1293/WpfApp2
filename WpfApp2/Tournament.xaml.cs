using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Tournament.xaml
    /// </summary>
    public partial class Tournament : Window
    {
        public Tournament()
        {
            InitializeComponent();
            //string dbsCon = @"Data Source=LABSCIFIPC02\LOCALHOST; Initial Catalog=CSKASHAMPION; Integrated Security=True";
            //SqlConnection sqlCon_ = new SqlConnection(dbsCon);

            //try
            //{
            //    sqlCon_.Open();
            //    string query = "Select TeamName, Ranking from Positions";
            //    SqlCommand cmd = new SqlCommand(query, sqlCon_);
            //    cmd.ExecuteNonQuery();
            //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
            //    data.ItemsSource = dt.DefaultView;
            //    adapter.Update(dt);

            //    MessageBox.Show("Successful loading");
            //    sqlCon_.Close();

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Menu m = new Menu();
            m.Show();
            this.Close();
        }
    }
}
