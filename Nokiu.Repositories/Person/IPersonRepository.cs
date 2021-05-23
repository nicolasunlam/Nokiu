using Nokiu.Entities.Models;
using System;
using System.Collections.Generic;

namespace Repositories
{
    public interface IPersonRepository
    {
        Person GetByUsername(String Username);
    }
}