using Nokiu.Entities.Models;
using System;

namespace Repositories
{
    public interface IPersonRepository
    {
        Person GetByUsername(String Username);
    }
}