using Microsoft.EntityFrameworkCore;
using OrderingSystem.Data.Entities;
using OrderingSystem.Data.Entities.Identity;
using OrderingSystem.infrastructure.Abstract;
using OrderingSystem.infrastructure.Data;
using OrderingSystem.infrastructure.InfastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.infrastructure.Repositieries
{
    public class RefershTokenRepository:GenericRepositoryAsync<UserRefreshToken>,IRefershTokenRepository
    {
        #region fields
        private DbSet<UserRefreshToken> userRefreshTokens;
        #endregion

        #region Ctor

        public RefershTokenRepository(APPDBContext dbContext) : base(dbContext)
        {
            userRefreshTokens = dbContext.Set<UserRefreshToken>();
        }
        #endregion
        #region handelFunction

        #endregion
    }
}
