using EmployeeDirectory.DAL;
using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDirectory.BAL
{
    public class EmployeeDirectoryService
    {
        private readonly EmployeeData _employeeData;
        public EmployeeDirectoryService(EmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        public List<Employee> GetAllEmployees() {
          return  _employeeData.GetAllEmployees();
        }
        public long AddEmployee(Employee employee)
        {
            return _employeeData.InsertEmployee(employee);
        }
        public Employee GetEmployee(long ID)
        {
            return _employeeData.GetEmployee(ID);
        }
        public bool UpdateEmployee(Employee employee)
        {
            return _employeeData.UpdateEmployee(employee);
        }
        public bool DeleteEmployee(long ID)
        {
            return _employeeData.DeleteEmployee(ID);
        }
    }
}
