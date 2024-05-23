using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Models;
using Backend_TeaTech.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend_TeaTech.Repositories
{
    public class ResponsibleRepository : IResponsibleRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ResponsibleRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public Responsible Add(Responsible responsible)
        {
            try
            {
                var responsibleAdd = _connectionContext.Responsibles.Add(responsible).Entity;
                _connectionContext.SaveChanges();
                return responsibleAdd;
            }catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }

        public void DeleteById(Guid id)
        {
            try
            {
                Responsible? responsible = this.GetById(id);
                if (responsible != null)
                {
                    try
                    {
                        _connectionContext.Responsibles.Remove(responsible);
                        _connectionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Responsible was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Responsible> GetAll()
        {
            try
            {
                return _connectionContext.Responsibles.Include(r => r.User).ToList();
            }catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }

        public Responsible? GetById(Guid id)
        {
            try
            {
                try
                {
                    Responsible? responsible = _connectionContext.Responsibles.Include(r => r.User)
                                                                     .FirstOrDefault(c => c.Id.Equals(id));

                    if (responsible != null)
                    {
                        return responsible;
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

        public Responsible GetByIdUser(Guid id)
        {
            try
            {
                try
                {
                    Responsible? responsible = _connectionContext.Responsibles.FirstOrDefault(c => c.User.Id == id);
                    if (responsible != null)
                    {
                        return responsible;
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

        public Responsible Update(Responsible responsible)
        {
            try
            {
                if (this.GetById(responsible.Id) != null)
                {
                    try
                    {
                        Responsible responsibleUpdated = _connectionContext.Responsibles.Update(responsible).Entity;
                        _connectionContext.SaveChanges();
                        return responsibleUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Responsible was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
