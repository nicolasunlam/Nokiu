using Nokiu.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(NokiuContext contexto) : base(contexto)
        {

        }
        public override void Update(Person t)
        {
            Person per = GetById(t.Id);
            per.FirstName = t.FirstName;

            ctx.SaveChanges();
        }

        public Person GetByUsername(String Username)
        {
            return ctx.Person.Where(pers => pers.FirstName == Username).FirstOrDefault();
        }

    }
}