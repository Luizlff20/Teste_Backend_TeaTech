using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_TeaTech.Repositories
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly ConnectionContext _connectionContext;

        public AssessmentRepository(ConnectionContext context)
        {
            _connectionContext = context;
        }
        public Assessment Add(Assessment assessment)
        {
            try
            {
                var assessmentAdd = _connectionContext.Assessments.Add(assessment).Entity;
                _connectionContext.SaveChanges();
                return assessmentAdd;
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
                Assessment? assessment = this.GetById(id);
                if (assessment != null)
                {
                    try
                    {
                        _connectionContext.Assessments.Remove(assessment);
                        _connectionContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Assessment was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Assessment> GetAll()
        {
            try
            {
                return _connectionContext.Assessments.Include(p => p.Employee)
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

        public Assessment? GetByChildAssistedId(Guid id)
        {
            try
            {
                Assessment? assessment = _connectionContext.Assessments.FirstOrDefault(a => a.ChildAssisted.Id == id);
                if (assessment != null)
                {
                    try
                    {
                        return assessment;
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

        public Assessment GetById(Guid id)
        {
            try
            {
                try
                {
                    Assessment? assessment = _connectionContext.Assessments.Include(p => p.Employee.User)
                                                                              .Include(p => p.ChildAssisted.Responsible.User)
                                                                              .FirstOrDefault(c => c.Id.Equals(id));
                    if (assessment != null)
                    {
                        return assessment;
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

        public Assessment Update(Assessment assessment)
        {
            try
            {
                if (this.GetById(assessment.Id) != null)
                {
                    try
                    {
                        Assessment assessmentUpdated = _connectionContext.Assessments.Update(assessment).Entity;
                        _connectionContext.SaveChanges();
                        return assessmentUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("Assessment was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
