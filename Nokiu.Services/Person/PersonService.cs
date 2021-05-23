using System;
using System.Collections.Generic;
using Nokiu.Entities.Models;
using Repositories;

namespace Services
{
    public class PersonService : BaseService<PersonRepository, Person>, IPersonService
    {
        public PersonService(NokiuContext contexto) : base(contexto)
        {

        }

        public Person GetByUsername(String Username)
        {
            return repo.GetByUsername(Username);
        }
    }
}
