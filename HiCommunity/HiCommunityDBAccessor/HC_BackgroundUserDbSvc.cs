using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
    public class HC_BackgroundUserDbSvc : BaseDbSvc
    {
        public HC_BackgroundUserDbSvc() { }

        public HC_BackgroundUserDbSvc(MySql.Data.MySqlClient.MySqlConnection connection)
            : base(connection){}

        /// <summary>
        /// [同步]根据Id获取HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HC_BackgroundUserBaseInfo GetById(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_BackgroundUserBaseInfo>(@"SELECT * FROM HC_BackgroundUserBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
            }
        }

        /// <summary>
        /// [异步]根据Id获取HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HC_BackgroundUserBaseInfo> GetByIdAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_BackgroundUserBaseInfo>(@"SELECT * FROM HC_BackgroundUserBaseInfo WHERE Id = @Id",  new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
            }
        }

        /// <summary>
        /// [同步]获取全部HC_BackgroundUserBaseInfo 
        /// </summary>
        /// <returns></returns>
        public List<HC_BackgroundUserBaseInfo> List()
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_BackgroundUserBaseInfo>(@"SELECT * FROM HC_BackgroundUserBaseInfo")).ToList();
            }
        }

        /// <summary>
        /// [异步]获取全部HC_BackgroundUserBaseInfo 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HC_BackgroundUserBaseInfo>> ListAsync()
        { 
            using(EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_BackgroundUserBaseInfo>(@"SELECT * FROM HC_BackgroundUserBaseInfo") .ConfigureAwait(false)).ToList();
            }
        }

        /// <summary>
        /// [同步]插入数据HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="backgroundUserInfo"></param>
        /// <returns></returns>
        public int Insert(HC_BackgroundUserBaseInfo backgroundUserInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_BackgroundUserBaseInfo", ColumnName = GeneralTableIdField });
                backgroundUserInfo.Id = currentID.ToString();
                DbConnection.ExecuteAsync(@"Insert HC_BackgroundUserBaseInfo(Id, UserID, PurviewStr)
                                            values (@Id, @UserID, @PurviewStr)",
                                            backgroundUserInfo);
                return currentID;
            }
        }

        /// <summary>
        /// [异步]插入数据HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="backgroundUserInfo"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(HC_BackgroundUserBaseInfo backgroundUserInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_BackgroundUserBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
                backgroundUserInfo.Id = currentID.ToString();
                await DbConnection.ExecuteAsync(@"Insert HC_BackgroundUserBaseInfo(Id, UserID, PurviewStr)
                                            values (@Id, @UserID, @PurviewStr)",
                                            backgroundUserInfo).ConfigureAwait(false);
                return currentID;
            }
        }

        /// <summary>
        ///[同步]修改数据HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="backgroundUserInfo"></param>
        /// <returns></returns>
        public int Update(HC_BackgroundUserBaseInfo backgroundUserInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                return DbConnection.Execute(@"Update HC_BackgroundUserBaseInfo Set 
                                            UserID = @UserID, 
                                            PurviewStr = @PurviewStr
                                            Where Id = @Id",
                                            new
                                            {
                                                Id = backgroundUserInfo.Id,
                                                UserID = backgroundUserInfo.UserID,
                                                PurviewStr = backgroundUserInfo.PurviewStr
                                            });
            }
        }

        /// <summary>
        ///[异步]修改数据HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="backgroundUserInfo"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(HC_BackgroundUserBaseInfo backgroundUserInfo)
        {
            using (EnsureHiCommunityConnection())
            {
               return await DbConnection.ExecuteAsync(@"Update HC_BackgroundUserBaseInfo Set 
                                            UserID = @UserID, 
                                            PurviewStr = @PurviewStr
                                            Where Id = @Id",
                                            new
                                            {
                                                Id = backgroundUserInfo.Id,
                                                UserID = backgroundUserInfo.UserID,
                                                PurviewStr = backgroundUserInfo.PurviewStr
                                            }).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// [同步]删除数据HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            using (EnsureHiCommunityConnection())
            {
              return  DbConnection.Execute(@"Delete From HC_BackgroundUserBaseInfo Where Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// [异步]删除数据HC_BackgroundUserBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
               return await DbConnection.ExecuteAsync(@"Delete From HC_BackgroundUserBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
            }
        }

    }
}
