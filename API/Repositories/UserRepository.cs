using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Models;
using Backend_TeaTech.Interfaces.Repositories;

namespace Backend_TeaTech.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _connectionContextUser;

        public UserRepository(ConnectionContext context)
        {
            _connectionContextUser = context;
        }
        public User Add(User user)
        {
            try
            {
                var userAdd = _connectionContextUser.Users.Add(user).Entity;
                _connectionContextUser.SaveChanges();
                return userAdd;
            }catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }

        }

        public void DeleteById(Guid id)
        {
            try
            {
                User? user = this.GetById(id);
                if (user != null)
                {
                    try
                    {
                        _connectionContextUser.Users.Remove(user);
                        _connectionContextUser.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("User was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return _connectionContextUser.Users.ToList();
            }catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }

        public User GetByEmail(string email)
        {
            try
            {
                return _connectionContextUser.Users.FirstOrDefault(user => user.Email == email);
            }catch (Exception ex)
            {
                throw new Exception("Internal database error - Message: " + ex.Message);
            }
            
        }

        public User? GetById(Guid id)
        {
            try
            {
                try
                {
                    User? user = _connectionContextUser.Users.Find(id);

                    if (user != null)
                    {
                        return user;
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

        public User Update(User user)
        {
            try
            {
                if (this.GetById(user.Id) != null)
                {
                    try
                    {
                        User userUpdated = _connectionContextUser.Users.Update(user).Entity;
                        _connectionContextUser.SaveChanges();
                        return userUpdated;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Internal database error - Message: " + ex.Message);
                    }

                }
                else
                {
                    throw new Exception("User was not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
