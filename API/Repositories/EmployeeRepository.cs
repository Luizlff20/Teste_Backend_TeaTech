using Backend_TeaTech.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Models;
using Backend_TeaTech.Enum;

namespace Backend_TeaTech.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _connectionContext;

        public EmployeeRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }

        public Employee Add(Employee employee)
        {
            try
            {
                var employeeAdd = _connectionContext.Employees.Add(employee).Entity;
                _connectionContext.SaveChanges();
                return employeeAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
        }

        public void DeleteByID(Guid id)
        {
            try
            {
                Employee? employee = this.GetByID(id);
                if (employee != null)
                {
                    try
                    {
                        _connectionContext.Employees.Remove(employee);
                        _connectionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Employee was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                return _connectionContext.Employees.Include(e => e.User).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
        }

        public List<Employee> GetAllApplicatores()
        {
            try
            {
                return _connectionContext.Employees
                                         .Where(e => e.OccupationType == OccupationType.Applicator)
                                         .Include(e => e.User)
                                         .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message, ex);
            }
        }

        public Employee GetByID(Guid id)
        {
            try
            {
                try
                {
                    Employee? employee = _connectionContext.Employees.Include(e => e.User)
                                                                     .FirstOrDefault(c => c.Id.Equals(id));
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Internal database error - Message: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee GetByIdUser(Guid id)
        {
            try
            {
                try
                {
                    Employee? employee = _connectionContext.Employees.FirstOrDefault(c => c.User.Id == id);
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Internal database error - Message: " + ex.Message);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee Update(Employee employee)
        {
            try
            {
                if (this.GetByID(employee.Id) != null)
                {
                    try
                    {
                        Employee employeeUpdated = _connectionContext.Employees.Update(employee).Entity;
                        _connectionContext.SaveChanges();
                        return employeeUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Employee was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
