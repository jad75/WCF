using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            //create a proxy class of WCF Service
            EmployeeService.EmployeeWcfServiceClient client = new EmployeeService.EmployeeWcfServiceClient();
            //Get employee object with specific ID  from WCF Service
            EmployeeService.Employee employee = client.GetEmployee(Convert.ToInt32(txtID.Text));

            //assign employee object properties to corresponding TextBoxes
            txtName.Text = employee.Name;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();

            lblMessage.Text = "Employee retrieved";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeService.EmployeeWcfServiceClient client = new EmployeeService.EmployeeWcfServiceClient();

            EmployeeService.Employee employee = new EmployeeService.Employee();
            employee.Id = Convert.ToInt32(txtID.Text);
            employee.Name = txtName.Text;
            employee.Gender = txtGender.Text;
            employee.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);

           
            client.SaveEmployee(employee);

            lblMessage.Text = "Employee saved";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //create a proxy class of WCF Service
            EmployeeService.EmployeeWcfServiceClient client = new EmployeeService.EmployeeWcfServiceClient();
            //Get employee object with specific ID  from WCF Service
             client.DeleteEmployee(Convert.ToInt32(txtID.Text));
            lblMessage.Text = "Employee deleted";
        }
    }
}