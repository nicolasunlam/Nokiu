using Nokiu.Entities.Models;
using System;
using System.Linq;

namespace Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(NokiuContext context) : base(context)
        {

        }
      
        public override bool Update(Person t)
        {
            Person per = GetById(t.Id);
            per.FirstName = t.FirstName;

            if (ctx.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Person GetByUsername(String Username)
        {
            return ctx.Person.Where(pers => pers.FirstName == Username).FirstOrDefault();
        }
    }
}