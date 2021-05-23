using Nokiu.Entities.Models;
using System;

namespace Services
{
    public interface IPersonService
    {
        Person GetByUsername(String Username);
    }
}
