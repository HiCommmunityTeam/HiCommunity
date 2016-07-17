using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
    public class HC_CategoryDbSvc : BaseDbSvc
    {
       
        public HC_CategoryDbSvc() { }

        public HC_CategoryDbSvc(MySql.Data.MySqlClient.MySqlConnection connection)
            : base(connection){}

        /// <summary>
        /// [同步]根据Id获取HC_CategoryBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HC_CategoryBaseInfo GetById(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_CategoryBaseInfo>(@"SELECT * FROM HC_CategoryBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
            }
        }

        /// <summary>
        /// [异步]根据Id获取HC_CategoryBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HC_CategoryBaseInfo> GetByIdAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_CategoryBaseInfo>(@"SELECT * FROM HC_CategoryBaseInfo WHERE Id = @Id",  new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
            }
        }

        /// <summary>
        /// [同步]获取全部HC_CategoryBaseInfo 
        /// </summary>
        /// <returns></returns>
        public List<HC_CategoryBaseInfo> List()
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_CategoryBaseInfo>(@"SELECT * FROM HC_CategoryBaseInfo")).ToList();
            }
        }

        /// <summary>
        /// [异步]获取全部HC_CategoryBaseInfo 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HC_CategoryBaseInfo>> ListAsync()
        { 
            using(EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_CategoryBaseInfo>(@"SELECT * FROM HC_CategoryBaseInfo") .ConfigureAwait(false)).ToList();
            }
        }

        /// <summary>
        /// [同步]插入数据HC_CategoryBaseInfo
        /// </summary>
        /// <param name="categoryInfo"></param>
        /// <returns></returns>
        public int Insert(HC_CategoryBaseInfo categoryInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_CategoryBaseInfo", ColumnName = GeneralTableIdField });
                categoryInfo.Id = currentID.ToString();
                DbConnection.ExecuteAsync(@"Insert HC_CategoryBaseInfo(Id,CategoryName)
                                            values (@Id, @CategoryName)",
                                            categoryInfo);
                return currentID;
            }
        }

        /// <summary>
        /// [异步]插入数据HC_CategoryBaseInfo
        /// </summary>
        /// <param name="categoryInfo"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(HC_CategoryBaseInfo categoryInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_CategoryBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
                categoryInfo.Id = currentID.ToString();
                await DbConnection.ExecuteAsync(@"Insert HC_CategoryBaseInfo(Id, CategoryName)
                                            values (@Id, @CategoryName)",
                                            categoryInfo).ConfigureAwait(false);
                return currentID;
            }
        }

        /// <summary>
        ///[同步]修改数据HC_CategoryBaseInfo
        /// </summary>
        /// <param name="categoryInfo"></param>
        /// <returns></returns>
        public int Update(HC_CategoryBaseInfo categoryInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                return DbConnection.Execute(@"Update HC_CategoryBaseInfo Set 
                                            CategoryName = @CategoryName
                                            Where Id = @Id",
                                            new
                                            {
                                                Id = categoryInfo.Id,
                                                CategoryName = categoryInfo.CategoryName
                                            });
            }
        }

        /// <summary>
        ///[异步]修改数据HC_CategoryBaseInfo
        /// </summary>
        /// <param name="categoryInfo"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(HC_CategoryBaseInfo categoryInfo)
        {
            using (EnsureHiCommunityConnection())
            {
               return await DbConnection.ExecuteAsync(@"Update HC_CategoryBaseInfo Set 
                                            CategoryName = @CategoryName
                                            Where Id = @Id",
                                            new
                                            {
                                                Id = categoryInfo.Id,
                                                CategoryName = categoryInfo.CategoryName
                                            }).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// [同步]删除数据HC_CategoryBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            using (EnsureHiCommunityConnection())
            {
              return  DbConnection.Execute(@"Delete From HC_CategoryBaseInfo Where Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// [异步]删除数据HC_CategoryBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
               return await DbConnection.ExecuteAsync(@"Delete From HC_CategoryBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
            }
        }

    }
}
