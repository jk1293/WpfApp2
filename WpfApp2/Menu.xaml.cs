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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            s.Show();
            s.text.Text = "Which team do you want to know about?";
            this.Close();
        }

        private void Players_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            s.Show();
            s.text.Text = "Which player do you want to know about?";
            this.Close();
        }

        private void Tournament_Click(object sender, RoutedEventArgs e)
        {
            Tournament t = new Tournament();
            t.Show();


            string dbsCon = @"Data Source=LABSCIFIPC02\LOCALHOST; Initial Catalog=CSKASHAMPION; Integrated Security=True";
            SqlConnection sqlCon_ = new SqlConnection(dbsCon);

            try
            {
                sqlCon_.Open();
                string query = "Select TeamName, Position from Positions";
                SqlCommand cmd = new SqlCommand(query, sqlCon_);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                t.data.ItemsSource = dt.DefaultView;
                adapter.Update(dt);

                sqlCon_.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }         
            this.Close();
        }

        private void Coaches_Click(object sender, RoutedEventArgs e)
        {
            Coaches c = new Coaches();
            c.Show();


            string dbsCon = @"Data Source=LABSCIFIPC02\LOCALHOST; Initial Catalog=CSKASHAMPION; Integrated Security=True";
            SqlConnection sqlCon_ = new SqlConnection(dbsCon);

            try
            {
                sqlCon_.Open();
                string query = "Select FName, LName from Coaches";
                SqlCommand cmd = new SqlCommand(query, sqlCon_);
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                c.data.ItemsSource = dt.DefaultView;
                adapter.Update(dt);

                sqlCon_.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            this.Close();
        }
    }
}
