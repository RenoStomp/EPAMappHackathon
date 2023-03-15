using EPAMapp.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace EPAMapp.DAL.DataBaseExists
{
    public static class Exist<T, Tmodel, H>
        where T : BaseEntity
        where Tmodel : class
        where H : AccountHolder
    {
        public static bool DataBaseIsNotExist(DbContext context)
        {
            if (context.Set<T>() == default(DbSet<T>))
                return true;

            return false;
        }
        public static bool EntityIsNotExist(T entity)
        {
            if (entity == null)
                return true;

            return false;
        }
        public static bool EntityIsNotExist(Tmodel entity)
        {
            if (entity == null)
                return true;

            return false;
        }
        public static bool EntityIsNotExist(H entity)
        {
            if (entity == null)
                return true;

            return false;
        }
        public static bool EntityIsNotExist(List<T> entities)
        {
            if (entities == null || !entities.Any())
                return true;

            return false;
        }
        public static bool EntityIsNotExist(List<Tmodel> entities)
        {
            if (entities == null || !entities.Any())
                return true;

            return false;
        }
        public static bool EntityIsNotExist(List<H> entities)
        {
            if (entities == null || !entities.Any())
                return true;

            return false;
        }
    }
}
