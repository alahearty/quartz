using quartz.application.Users.Interfaces;
using Quartz.Application.Interfaces;
using Quartz.Domain.Users;
using Quartz.Persistence.Nhibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.persistence.nhibernate.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly INhibernateTransaction nhibernateTransaction;

        public UserRepository(INhibernateTransaction nhibernateTransaction)
        {
            this.nhibernateTransaction = nhibernateTransaction;
        }

        public IQuartzTransaction Transaction => nhibernateTransaction;

        public void Save(User entity)
        {
            nhibernateTransaction.Session.Save(entity);
        }

        public async Task SaveAsync(User entity)
        {
            await nhibernateTransaction.Session.SaveAsync(entity);
        }

        public void Delete(User entity)
        {
            nhibernateTransaction.Session.Delete(entity);
        }

        public async Task DeleteAsync(User entity)
        {
            await nhibernateTransaction.Session.DeleteAsync(entity);
        }

        public IList<User> GetAll()
        {
            return nhibernateTransaction.Session.Query<User>().ToList();
        }

        public void Update(User entity)
        {
            nhibernateTransaction.Session.Update(entity);
        }

        public async Task UpdateAsync(User entity)
        {
            await nhibernateTransaction.Session.UpdateAsync(entity);
        }

        public User GetByName(string name)
        {
            return nhibernateTransaction.Session.QueryOver<User>()
            .WhereRestrictionOn(x => x.FirstName).IsInsensitiveLike(name)
            .SingleOrDefault();
        }

        public User GetById(int id)
        {
            return nhibernateTransaction.Session.Get<User>(id);
        }
    }
}
