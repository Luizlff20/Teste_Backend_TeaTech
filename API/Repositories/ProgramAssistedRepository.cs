using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_TeaTech.Repositories
{
    public class ProgramAssistedRepository : IProgramAssistedRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ProgramAssistedRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public ProgramAssisted Add(ProgramAssisted programAssisted)
        {
            try
            {
                var programAssistedAdd = _connectionContext.Programs.Add(programAssisted).Entity;
                _connectionContext.SaveChanges();
                return programAssistedAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
        }

        public void DeleteById(Guid id)
        {
            try
            {
                ProgramAssisted? programAssisted = this.GetById(id);
                if (programAssisted != null)
                {
                    try
                    {
                        _connectionContext.Programs.Remove(programAssisted);
                        _connectionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Program was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProgramAssisted> GetAll()
        {
            try
            {
                return _connectionContext.Programs.Include(p => p.Employee)
                                                      .Include(p => p.ChildAssisted)
                                                      .Include(p => p.ChildAssisted.Responsible)
                                                      .Include(p => p.ChildAssisted.Responsible.User)
                                                      .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
        }

        public ProgramAssisted? GetByChildAssistedId(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProgramAssisted GetById(Guid id)
        {
            try
            {
                try
                {
                    ProgramAssisted? programAssisted = _connectionContext.Programs.Include(p => p.Employee.User)
                                                                              .Include(p => p.ChildAssisted.Responsible.User)
                                                                              .FirstOrDefault(c => c.Id.Equals(id));
                    if (programAssisted != null)
                    {
                        return programAssisted;
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

        public ProgramAssisted Update(ProgramAssisted programAssisted)
        {
            try
            {
                if (this.GetById(programAssisted.Id) != null)
                {
                    try
                    {
                        ProgramAssisted programAssistedUpdate = _connectionContext.Programs.Update(programAssisted).Entity;
                        _connectionContext.SaveChanges();
                        return programAssistedUpdate;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Program was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
