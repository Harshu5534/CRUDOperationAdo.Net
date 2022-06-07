using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOperations
{
    public class EmpRepository
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=payroll_Service_Example";
            con = new SqlConnection(constr);
        }
        //To Add Employee details    
        public void AddEmployee(EmpModel obj)
        {
            try
            {
                connection();
                SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", obj.Name);
                com.Parameters.AddWithValue("@Gender", obj.Gender);
                com.Parameters.AddWithValue("@Salary", obj.Salary);
                com.Parameters.AddWithValue("@StartDate", obj.StartDate);
                com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
                com.Parameters.AddWithValue("@Address", obj.Address);
                com.Parameters.AddWithValue("@DepartMent", obj.DepartMent);
                com.Parameters.AddWithValue("@Deduction", obj.Deduction);
                com.Parameters.AddWithValue("@Taxable_Pay", obj.Taxable_Pay);
                com.Parameters.AddWithValue("@Net_Pay", obj.Net_Pay);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {
                    Console.WriteLine("New Employee Data Added SuccessFully");
                }
                else
                {
                    Console.WriteLine("New Employee Data Not Added");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
    }
}
    

