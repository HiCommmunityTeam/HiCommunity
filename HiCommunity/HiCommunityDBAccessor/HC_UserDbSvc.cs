using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
    public class HC_UserDbSvc : BaseDbSvc
    {
        public HC_UserDbSvc() {}

        public HC_UserDbSvc(MySql.Data.MySqlClient.MySqlConnection connection)
            : base(connection) { }

        /// <summary>
        /// [同步]根据Id获取HC_UserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HC_UserBaseInfo GetById(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_UserBaseInfo>(@"SELECT * FROM HC_UserBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
            }
        }

        /// <summary>
        /// [异步]根据Id获取HC_UserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HC_UserBaseInfo> GetByIdAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_UserBaseInfo>(@"SELECT * FROM HC_UserBaseInfo WHERE Id = @Id", new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
            }
        }

        /// <summary>
        /// [同步]获取全部HC_UserBaseInfo 
        /// </summary>
        /// <returns></returns>
        public List<HC_UserBaseInfo> List()
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_UserBaseInfo>(@"SELECT * FROM HC_UserBaseInfo")).ToList();
            }
        }

        /// <summary>
        /// [异步]获取全部HC_UserBaseInfo 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HC_UserBaseInfo>> ListAsync()
        {
            using (EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_UserBaseInfo>(@"SELECT * FROM HC_UserBaseInfo").ConfigureAwait(false)).ToList();
            }
        }

        /// <summary>
        /// [同步]插入数据HC_UserBaseInfo
        /// </summary>
        /// <param name="threadTagInfo"></param>
        /// <returns></returns>
        public int Insert(HC_UserBaseInfo threadTagInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_UserBaseInfo", ColumnName = GeneralTableIdField });
                threadTagInfo.Id = currentID.ToString();
                DbConnection.ExecuteAsync(@"Insert HC_UserBaseInfo(Id, EMail, UserName, UserPassWord, Sex, CellPhone, RegisterDate, RegisterType, LastLoginDate, LoginType, LoginOpenID, WXUnionID, WxOpenID)
                                            values (@Id, @EMail, @UserName, @UserPassWord, @Sex, @CellPhone, @RegisterDate, @RegisterType, @LastLoginDate, @LoginType, @LoginOpenID, @WXUnionID, @WxOpenID)",
                                            threadTagInfo);
                return currentID;
            }
        }

        /// <summary>
        /// [异步]插入数据HC_UserBaseInfo
        /// </summary>
        /// <param name="threadTagInfo"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(HC_UserBaseInfo threadTagInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_UserBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
                threadTagInfo.Id = currentID.ToString();
                await DbConnection.ExecuteAsync(@"Insert HC_UserBaseInfo(Id, EMail, UserName, UserPassWord, Sex, CellPhone, RegisterDate, RegisterType, LastLoginDate, LoginType, LoginOpenID, WXUnionID, WxOpenID)
                                            values (@Id, @EMail, @UserName, @UserPassWord, @Sex, @CellPhone, @RegisterDate, @RegisterType, @LastLoginDate, @LoginType, @LoginOpenID, @WXUnionID, @WxOpenID)",
                                            threadTagInfo).ConfigureAwait(false);
                return currentID;
            }
        }

        /// <summary>
        ///[同步]修改数据HC_UserBaseInfo
        /// </summary>
        /// <param name="threadTagInfo"></param>
        /// <returns></returns>
        public int Update(HC_UserBaseInfo threadTagInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                return DbConnection.Execute(@"Update HC_UserBaseInfo Set 
                                             EMail = @EMail,
                                             UserName = @UserName,
                                             UserPassWord = @UserPassWord,
                                             Sex = @Sex,
                                             CellPhone = @CellPhone,
                                             RegisterDate = @RegisterDate,
                                             RegisterType = @RegisterType,
                                             LastLoginDate = @LastLoginDate,
                                             LoginType = @LoginType,
                                             LoginOpenID = @LoginOpenID,
                                             WXUnionID = @WXUnionID,
                                             WxOpenID = @WxOpenID
                                             Where Id = @Id",
                                             new
                                             {
                                                 Id = threadTagInfo.Id,
                                                 EMail = threadTagInfo.EMail,
                                                 UserName = threadTagInfo.UserName,
                                                 UserPassWord = threadTagInfo.UserPassWord,
                                                 Sex = threadTagInfo.Sex,
                                                 CellPhone = threadTagInfo.CellPhone,
                                                 RegisterDate = threadTagInfo.RegisterDate,
                                                 RegisterType = threadTagInfo.RegisterType,
                                                 LastLoginDate = threadTagInfo.LastLoginDate,
                                                 LoginType = threadTagInfo.LoginType,
                                                 LoginOpenID = threadTagInfo.LoginOpenID,
                                                 WXUnionID = threadTagInfo.WXUnionID,
                                                 WxOpenID = threadTagInfo.WxOpenID
                                             });
            }
        }

        /// <summary>
        ///[异步]修改数据HC_UserBaseInfo
        /// </summary>
        /// <param name="threadTagInfo"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(HC_UserBaseInfo threadTagInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                return await DbConnection.ExecuteAsync(@"Update HC_UserBaseInfo Set 
                                                         EMail = @EMail,
                                                         UserName = @UserName,
                                                         UserPassWord = @UserPassWord,
                                                         Sex = @Sex,
                                                         CellPhone = @CellPhone,
                                                         RegisterDate = @RegisterDate,
                                                         RegisterType = @RegisterType,
                                                         LastLoginDate = @LastLoginDate,
                                                         LoginType = @LoginType,
                                                         LoginOpenID = @LoginOpenID,
                                                         WXUnionID = @WXUnionID,
                                                         WxOpenID = @WxOpenID
                                                         Where Id = @Id",
                                                         new
                                                         {
                                                             Id = threadTagInfo.Id,
                                                             EMail = threadTagInfo.EMail,
                                                             UserName = threadTagInfo.UserName,
                                                             UserPassWord = threadTagInfo.UserPassWord,
                                                             Sex = threadTagInfo.Sex,
                                                             CellPhone = threadTagInfo.CellPhone,
                                                             RegisterDate = threadTagInfo.RegisterDate,
                                                             RegisterType = threadTagInfo.RegisterType,
                                                             LastLoginDate = threadTagInfo.LastLoginDate,
                                                             LoginType = threadTagInfo.LoginType,
                                                             LoginOpenID = threadTagInfo.LoginOpenID,
                                                             WXUnionID = threadTagInfo.WXUnionID,
                                                             WxOpenID = threadTagInfo.WxOpenID
                                                         }).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// [同步]删除数据HC_UserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return DbConnection.Execute(@"Delete From HC_UserBaseInfo Where Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// [异步]删除数据HC_UserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return await DbConnection.ExecuteAsync(@"Delete From HC_UserBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
            }
        }
    }
}
