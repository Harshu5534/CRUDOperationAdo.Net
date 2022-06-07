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
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();

            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                new EmpModel
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    Salary = Convert.ToInt32(dr["Salary"]),
                    StartDate = Convert.ToDateTime(dr["StartDate"]),
                    PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                    Address = Convert.ToString(dr["Address"]),
                    Deduction = Convert.ToString(dr["Deduction"]),
                    Taxable_Pay = Convert.ToString(dr["Taxable_Pay"]),
                    Net_Pay = Convert.ToString(dr["Net_Pay"]),
                }
                );
            }
            return EmpList;
        }
        //To Update Employee details    
        public bool UpdateEmployee(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.Id);
            //com.Parameters.AddWithValue("@Name", obj.Name);
            //com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@Salary", obj.Salary);
            //com.Parameters.AddWithValue("@StartDate", obj.StartDate);
            //com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            //com.Parameters.AddWithValue("@Address", obj.Address);
            //com.Parameters.AddWithValue("@Deduction", obj.Deduction);
            //com.Parameters.AddWithValue("@Taxable_Pay", obj.Taxable_Pay);
            //com.Parameters.AddWithValue("@Net_Pay", obj.Net_Pay);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        //To delete Employee details    
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
    

