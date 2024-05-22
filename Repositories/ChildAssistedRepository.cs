using Microsoft.EntityFrameworkCore;
using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Models;
using Backend_TeaTech.Interfaces.Repositories;
using System.Linq.Dynamic.Core;

namespace Backend_TeaTech.Repositories
{
    public class ChildAssistedRepository : IChildAssistedRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ChildAssistedRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public ChildAssisted Add(ChildAssisted childAssisted)
        {
            try
            {
                var childAdd = _connectionContext.ChildAssisteds.Add(childAssisted).Entity;
                _connectionContext.SaveChanges();
                return childAdd;
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }
        public List<ChildAssisted> GetAll()
        {
            try
            {
                return _connectionContext.ChildAssisteds.Include(c => c.Responsible).Include(c => c.Responsible.User).ToList();
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
                ChildAssisted? childAssisted = this.GetById(id);
                if (childAssisted != null)
                {
                    try
                    {
                        _connectionContext.ChildAssisteds.Remove(childAssisted);
                        _connectionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Assisted was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public ChildAssisted? GetById(Guid id)
        {
            try
            {
                try
                {
                    ChildAssisted? childAssisted = _connectionContext.ChildAssisteds.Include(c => c.Responsible.User)
                                                                                    
                                                                                    .FirstOrDefault(c => c.Id.Equals(id));
                    if (childAssisted != null)
                    {
                         return childAssisted;
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
        public ChildAssisted Update(ChildAssisted childAssisted)
        {
            try
            {
                if (this.GetById(childAssisted.Id) != null)
                {
                    try
                    {
                        ChildAssisted childAssistedUpdated = _connectionContext.ChildAssisteds.Update(childAssisted).Entity;
                        _connectionContext.SaveChanges();
                        return childAssistedUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }
                
                }
                else
                {
                    throw new Exception("Assisted was not found");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int CountAllChildAssisted()
        {
            try
            {
                return _connectionContext.ChildAssisteds.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
        }
        public List<ChildAssisted> GetByData(string data, int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            try
            {
                data = data.ToLower();
                var query = _connectionContext.ChildAssisteds
                                              .Include(c => c.Responsible)
                                              .Include(c => c.Responsible.User)
                                              .Where(c => c.Name.ToLower().Contains(data) ||
                                                          c.Responsible.NameResponsibleOne.ToLower().Contains(data) ||
                                                          c.Responsible.NameResponsibleTwo.ToLower().Contains(data) ||
                                                          c.Responsible.ResponsibleCpfOne.ToLower().Contains(data) ||
                                                          c.Responsible.ResponsibleCpfTwo.ToLower().Contains(data) ||
                                                          c.Responsible.ContactOne.ToLower().Contains(data) ||
                                                          c.Responsible.ContactTwo.ToLower().Contains(data) ||
                                                          c.Responsible.User.Email.ToLower().Contains(data));

                if (!string.IsNullOrEmpty(orderBy))
                {
                    query = query.OrderBy(orderBy + " " + orderDirection);
                }

                return query.Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Data not found.", ex);
            }
        }

        public ChildAssisted GetChildByResponsibleId(Guid responsibleId)
        {
            try
            {
                return _connectionContext.ChildAssisteds.FirstOrDefault(c => c.Responsible.Id == responsibleId);

            }catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }
    }
}
