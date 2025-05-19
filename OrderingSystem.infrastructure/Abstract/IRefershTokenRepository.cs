using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.infrastructure.InfastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.infrastructure.Abstract
{
    public interface IRefershTokenRepository:IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
