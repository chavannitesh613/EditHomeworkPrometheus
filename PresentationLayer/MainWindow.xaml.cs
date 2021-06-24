using BusinessLayer;
using Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateComboBox();
        }

        private void CreateComboBox()
        {
            SqlConnection con = new SqlConnection(@"data source=.\sqlexpress;initial catalog=Prometheus;integrated security=true");
            SqlCommand sql = new SqlCommand("select HomeWorkId from Homework", con);
            con.Open();
            SqlDataReader reader = sql.ExecuteReader();
            txtHomeWorkId.ItemsSource = reader;
            txtHomeWorkId.DisplayMemberPath = "HomeWorkId";
            txtHomeWorkId.SelectedValuePath = "HomeWorkId";
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Homework homework = new Homework();
                homework.HomeWorkID = Convert.ToInt32(txtHomeWorkId.Text);
                homework.Description = txtDescription.Text;
                homework.Deadline = Convert.ToDateTime(txtDeadline.Text);
                homework.ReqTime = Convert.ToInt32(txtReqTime.Text);
                homework.LongDescription = txtLongDescription.Text;
                homework.PlanningDescription = txtPlanningDescription.Text;

                EditHomeworkBL editHomeworkBL = new EditHomeworkBL();
                bool success;
                success = editHomeworkBL.EditHomework(homework);
                if (success)
                    MessageBox.Show("Record updated successfully");
                else
                    MessageBox.Show("Record not updated");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void menuStudentLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuTeacherLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void menuAdminLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

