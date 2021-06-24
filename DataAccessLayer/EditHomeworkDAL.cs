using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EditHomeworkDAL
    {
        public bool EditHomework(Homework homework)
        {
            string constr = @"data source=.\sqlexpress;initial catalog=Prometheus;integrated security=true;";
            SqlConnection con = new SqlConnection(constr);
            string querytext = "sp_EditHomework";
            SqlCommand cmd = new SqlCommand(querytext, con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@homeworkId", homework.HomeWorkID);
            cmd.Parameters.AddWithValue("@description", homework.Description);
            cmd.Parameters.AddWithValue("@deadline", homework.Deadline);
            cmd.Parameters.AddWithValue("@reqTime", homework.ReqTime);
            cmd.Parameters.AddWithValue("@longDescription", homework.LongDescription);
          

            bool success = true;
            try
            {
                con.Open();
                int rowsaffected = cmd.ExecuteNonQuery();
                if (rowsaffected == 0)
                    success = false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return success;

        }
    }
}
