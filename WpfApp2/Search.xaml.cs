using System;
using System.Collections.Generic;
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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Window
    {      
        public Search()
        {
            InitializeComponent();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LABSCIFIPC02\LOCALHOST; Initial Catalog=CSKASHAMPION; Integrated Security=True");
            
            if (e.Key == Key.Return)
            {
                if (text.Text == "Which team do you want to know about?")
                {
                    Team t = new Team();
                    try
                    {                  

                        sqlcon.Open();
                        string query = $"Select * from Teams where TeamName = '" + team1.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();                        t.Show();

                            t.country.Text = reader["Country"].ToString();
                            t.date.Text = reader["date_established"].ToString();
                            t.players.Text = reader["numberofplayers"].ToString();
                            t.trophies.Text = reader["numberoftrophies"].ToString();
                            t.ranking.Text = reader["ranking"].ToString();

                        t.team.Text = team1.Text;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { sqlcon.Close(); }

                }
                else if (text.Text == "Which player do you want to know about?")
                {
                    Player p = new Player();
                    try
                    {

                        sqlcon.Open();
                        string query = $"Select * from Players where LName = '" + team1.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        cmd.ExecuteNonQuery();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read(); p.Show();

                        p.ShirtNumber.Text = reader["ShirtNumber"].ToString();
                        p.Nationality.Text = reader["Nationality"].ToString();
                        p.Goals.Text = reader["Goals"].ToString();
                        p.Assists.Text = reader["Assists"].ToString();

                        p.name.Text = team1.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Check if you entered correctly only the last name");
                    }
                    finally { sqlcon.Close(); }

                    this.Close();
                }
                else  { MessageBox.Show("there is a mistake somewhere, try restartingif it does not work the application is down"); }
            }
        }
    }
}
