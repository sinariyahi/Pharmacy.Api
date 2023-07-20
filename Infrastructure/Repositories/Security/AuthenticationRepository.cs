using Common.DBHelper;
using Contracts.Entities.Security;
using Contracts.Interface.Security;
using Contracts.Interface.Shared;
using Dapper;
using Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Security
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IConnectionUtility connectionUtility;
        private readonly IRedisService<User> redisService;

        public AuthenticationRepository(IConnectionUtility connectionUtility, IRedisService<User> redisService)
        {
            this.connectionUtility = connectionUtility;
            this.redisService = redisService;
        }
        public async Task<List<object>> GetUser(string userName)
        {
            var res = new List<object>();

            using (var dapper = connectionUtility.NewConnection())
            {

                var results = await dapper.QueryMultipleAsync(SPNames.Pharmacy_Security_User_Login, new { userName = userName }, commandType: System.Data.CommandType.StoredProcedure);
               // res.Add(results.ReadAsync<dynamic>().Result);
                for (int i = 0; i < 2; i++)
                {
                    var g = results.ReadAsync<dynamic>().Result;
                    res.Add(g);
                }
            }

            return res;
        }
        public async Task<bool> setUserToRedis(User user, Guid userId)
        {
            await redisService.setToRedis(user, userId.ToString());
            return true;

        }
        public async Task<bool> setRefreshToken(string refreshToken, Guid userId)
        {
            using (var dapper = connectionUtility.NewConnection())
            {
                var result = await dapper.ExecuteScalarAsync(SPNames.Pharmacy_SetRefreshToken, new { userId, refreshToken }, commandType: System.Data.CommandType.StoredProcedure);
                return Convert.ToBoolean(result);
            }
        }
        public async Task<User> getUserFromRedis(Guid userId)
        {
            return await redisService.getObjectFromRedis(userId.ToString());
        }
        public async Task<IEnumerable<MenuPermission>> GetPermissionsByMenuId(int menuId, string userName)
        {
            using (var dapper = connectionUtility.NewConnection())
            {
                return await dapper.QueryAsync<MenuPermission>(SPNames.Pharmacy_User_GetMenuPermission, new { menuId = menuId, userName = userName }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
