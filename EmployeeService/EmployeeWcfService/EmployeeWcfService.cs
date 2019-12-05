using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EmployeeWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmployeeWcfService" in both code and config file together.
    public class EmployeeWcfService : IEmployeeWcfService
    {
        public void DeleteEmployee(int Id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmdDelete = new SqlCommand("spDeleteEmployee", con);
                
                cmdDelete.CommandType = CommandType.StoredProcedure;
                
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = Id;
                // add parameter
                cmdDelete.Parameters.Add(parameterId);
                
               

                // open connection, execute command, close connection
                con.Open();
                cmdDelete.ExecuteNonQuery();
                //con.Close();
            }
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = new Employee();
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@Id";
                parameterId.Value = Id;
                cmd.Parameters.Add(parameterId);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee.Id = Convert.ToInt32(reader["Id"]);
                    employee.Name = reader["Name"].ToString();
                    employee.Gender = reader["Gender"].ToString();
                    employee.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                }
            }
            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameterId = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = employee.Id
                };
                cmd.Parameters.Add(parameterId);

                SqlParameter parameterName = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = employee.Name
                };
                cmd.Parameters.Add(parameterName);

                SqlParameter parameterGender = new SqlParameter
                {
                    ParameterName = "@Gender",
                    Value = employee.Gender
                };
                cmd.Parameters.Add(parameterGender);

                SqlParameter parameterDateOfBirth = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = employee.DateOfBirth
                };
                cmd.Parameters.Add(parameterDateOfBirth);

                con.Open(); // open the Connection
                cmd.ExecuteNonQuery(); // execute the Query
            }
        }
    }
}
