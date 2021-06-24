using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EditHomeworkBL
    {
        public bool EditHomework(Homework homework)
        {
            bool success;
            try
            {
                if (String.IsNullOrEmpty(Convert.ToString(homework.HomeWorkID)))
                    success = false;
                else if (homework.HomeWorkID <= 0)
                    success = false;

                if (string.IsNullOrEmpty(homework.Description))
                    success = false;
                else if (homework.Deadline <= DateTime.Now)
                    success = false;
                else if (string.IsNullOrEmpty(Convert.ToString(homework.Deadline)))
                    success = false;
                else if (string.IsNullOrEmpty(homework.ReqTime))
                    success = false;

                else if (string.IsNullOrEmpty(homework.LongDescription))
                    success = false;

                else
                {
                    EditHomeworkDAL editHomeworkDAL = new EditHomeworkDAL();

                    success = editHomeworkDAL.EditHomework(homework);

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return success;
        }
    }
}
