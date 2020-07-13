using EmployeeDirectory.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDirectory.DAL
{
    public class EmployeeData
    {
        private readonly string _connectionString;
        public EmployeeData(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DEV");
        }
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_GetAllEmployees", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            employees.Add(new Employee
                            {
                                ID = Convert.ToInt64(dataReader["ID"]),
                                Name = Convert.ToString(dataReader["Name"]),
                                Email = Convert.ToString(dataReader["Email"]),
                                JobTitle = Convert.ToString(dataReader["JobTitle"]),
                                JoiningDate = Convert.ToDateTime(dataReader["JoiningDate"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employees;
        }

        public long InsertEmployee(Employee employee)
        {
            long employeeID = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_InsertEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
                        cmd.Parameters.Add(new SqlParameter("@Email", employee.Email));
                        cmd.Parameters.Add(new SqlParameter("@JobTitle", employee.JobTitle));
                        cmd.Parameters.Add(new SqlParameter("@JoiningDate", employee.JoiningDate));
                        con.Open();
                        employeeID = Convert.ToInt64(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeID;
        }

        public Employee GetEmployee(long ID)
        {
            Employee employee = null;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_GetEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID", ID));
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            employee = new Employee
                            {
                                ID = Convert.ToInt64(dataReader["ID"]),
                                Name = Convert.ToString(dataReader["Name"]),
                                Email = Convert.ToString(dataReader["Email"]),
                                JobTitle = Convert.ToString(dataReader["JobTitle"]),
                                JoiningDate = Convert.ToDateTime(dataReader["JoiningDate"]),
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employee;
        }

        public bool UpdateEmployee(Employee employee)
        {
            bool isSuccess = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_UpdateEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID", employee.ID));
                        cmd.Parameters.Add(new SqlParameter("@Name", employee.Name));
                        cmd.Parameters.Add(new SqlParameter("@Email", employee.Email));
                        cmd.Parameters.Add(new SqlParameter("@JobTitle", employee.JobTitle));
                        cmd.Parameters.Add(new SqlParameter("@JoiningDate", employee.JoiningDate));
                        con.Open();
                        isSuccess = cmd.ExecuteNonQuery()>0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }

        public bool DeleteEmployee(long ID)
        {
            bool isSuccess = false;
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("USP_DeleteEmployee", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@EmployeeID", ID));
                        con.Open();
                        isSuccess = cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
    }
}

