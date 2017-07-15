using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelprerClass;
using System.Data;
using System.Data.SqlClient;

namespace MvcAppFirst.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public int deptid { get; set; }
        public int id { get; set; }
        public string Job { get; set; }

        public List<Employee> GetEmployee(int id = 0)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Prc_Employee", DbConnection.GetConnection());
            List<Employee> empList = new List<Employee>();
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = "select";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                
                empList = (from DataRow dr in ds.Tables[0].Rows
                           select new Employee
                           {
                               Name = dr["ename"].ToString(),
                               id = Convert.ToInt32(dr["id"].ToString()),
                               Job = dr["job"].ToString(),
                               deptid = Convert.ToInt32(dr["deptno"].ToString()),
                               Department =dr["dname"].ToString()
                           }).ToList();
            return empList;
            }
            catch (Exception ex)
            {
                empList = null;
                return empList;
            }
            
        }

        public string InsertEmp()
        {
             SqlCommand cmd = new SqlCommand("Prc_Employee", DbConnection.GetConnection());
            List<Employee> empList = new List<Employee>();
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = "insert";
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = Name;
                cmd.Parameters.Add("@job", SqlDbType.VarChar, 100).Value = Job;
                cmd.Parameters.Add("@dept", SqlDbType.Int).Value = deptid;
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return cmd.Parameters["@Msg"].Value.ToString();
            }
            catch (Exception ex)
            {
                return "Error : " + ex.ToString();
            }
        }

        public List<Employee> GetDept()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand("Prc_Employee", DbConnection.GetConnection());
            List<Employee> empList = new List<Employee>();
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = "dept";
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar,200).Direction = ParameterDirection.Output ;
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                empList = (from DataRow dr in ds.Tables[0].Rows
                           select new Employee
                           {
                               deptid = Convert.ToInt32(dr["deptno"].ToString()),
                               Department = dr["dname"].ToString()
                           }).ToList();
                return empList;
            }
            catch (Exception ex)
            {
                empList = null;
                return empList;
            }
            
        }

        public string Update()
        {
            SqlCommand cmd = new SqlCommand("Prc_Employee", DbConnection.GetConnection());
           
            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = "update";
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = Name;
                cmd.Parameters.Add("@job", SqlDbType.VarChar, 100).Value = Job;
                cmd.Parameters.Add("@dept", SqlDbType.Int).Value = deptid;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return cmd.Parameters["@Msg"].Value.ToString();
            }
            catch (Exception ex)
            {
                return "Error : " + ex.ToString();
            }
        }

        public string delete()
        {
            SqlCommand cmd = new SqlCommand("Prc_Employee", DbConnection.GetConnection());

            try
            {
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = "delete";
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.Parameters.Add("@Msg", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                return cmd.Parameters["@Msg"].Value.ToString();
            }
            catch (Exception ex)
            {
                return "Error : " + ex.ToString();
            }
        }


    }
}