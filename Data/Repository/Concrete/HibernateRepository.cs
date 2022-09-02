using Data.Repository.Abstract;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Concrete
{
    public class HibernateRepository<Entity> : IHibernateRepository<Entity> where Entity : class
    {
        //HibernateRepository class which is implements IHibernateRepository
        private readonly ISession session;
        private ITransaction transaction;

        public HibernateRepository(ISession session)
        {
            this.session = session;
            // Dependency Injection
        }

        public IQueryable<Entity> Entities => session.Query<Entity>(); // Query process

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction(); //Begin tran process
        }

        public void Commit()
        {
            transaction.Commit(); //Commit process
        }

        public void Rollback()
        {
            transaction.Rollback(); //Rollback process
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
            //Close tran process
        }

        public void Save(Entity entity)
        {
            session.Save(entity); //Entity save
        }

        public void Update(Entity entity)
        {
            session.Update(entity);//Entity update
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                session.Delete(entity);
            }
            //Entity delete if entity not null
        }

        public List<Entity> GetAll()
        {
            return session.Query<Entity>().ToList(); // Get all returns list
        }

        public Entity GetById(int id)
        {
            var entity = session.Get<Entity>(id);
            return entity; // Get by id process returns Entity
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return session.Query<Entity>().Where(where).AsQueryable(); // Default Where query which is returns IEnumerable<Entity>
        }

        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression)
        {
            return session.Query<Entity>().Where(expression).ToList();// Default find query which is returns IEnumerable<Entity>
        }


    }
}
