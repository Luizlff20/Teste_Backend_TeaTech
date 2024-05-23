using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Models;
using Microsoft.EntityFrameworkCore;
using Backend_TeaTech.Infrastructure;

namespace Backend_TeaTech.Repositories
{
    public class PreAnalysisRepository : IPreAnalysisRepository
    {
        private readonly ConnectionContext _connectionContext;

        public PreAnalysisRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }

        public PreAnalysis Add(PreAnalysis preAnalysis)
        {
            try
            {
                var preAnalysisAdd = _connectionContext.PreAnalysiss.Add(preAnalysis).Entity;
                _connectionContext.SaveChanges();
                return preAnalysisAdd;
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
                PreAnalysis? preAnalysis = this.GetById(id);
                if (preAnalysis != null)
                {
                    try
                    {
                        _connectionContext.PreAnalysiss.Remove(preAnalysis);
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

        public List<PreAnalysis> GetAll()
        {
            try
            {
                return _connectionContext.PreAnalysiss.Include(p => p.Employee)
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

        public PreAnalysis GetById(Guid id)
        {
            try
            {
                try
                {
                    PreAnalysis? preAnalysis = _connectionContext.PreAnalysiss.Include(p => p.Employee.User)
                                                                              .Include(p => p.ChildAssisted.Responsible.User)
                                                                              .FirstOrDefault(c => c.Id.Equals(id));
                    if (preAnalysis != null)
                    {
                        return preAnalysis;
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

        public PreAnalysis Update(PreAnalysis preAnalysis)
        {
            try
            {
                if (this.GetById(preAnalysis.Id) != null)
                {
                    try
                    {
                        PreAnalysis preAnalysisUpdated = _connectionContext.PreAnalysiss.Update(preAnalysis).Entity;
                        _connectionContext.SaveChanges();
                        return preAnalysisUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("PreAnalysis was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PreAnalysis? GetByChildAssistedId(Guid id)
        {
            try
            {
                PreAnalysis? preAnalysis = _connectionContext.PreAnalysiss.FirstOrDefault(pa => pa.ChildAssisted.Id == id);
                if (preAnalysis != null)
                {
                    try
                    {
                        return preAnalysis;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
