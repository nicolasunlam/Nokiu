using Nokiu.Entities.Models;
using Repositories;
using System;

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
