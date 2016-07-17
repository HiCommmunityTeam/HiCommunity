using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
   public class HC_ThreadTagDbSvc : BaseDbSvc
    {
       public HC_ThreadTagDbSvc() { }

       public HC_ThreadTagDbSvc(MySql.Data.MySqlClient.MySqlConnection connection)
           : base(connection) { }

       /// <summary>
       /// [同步]根据Id获取HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public HC_ThreadTagBaseInfo GetById(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return (DbConnection.Query<HC_ThreadTagBaseInfo>(@"SELECT * FROM HC_ThreadTagBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
           }
       }

       /// <summary>
       /// [异步]根据Id获取HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public async Task<HC_ThreadTagBaseInfo> GetByIdAsync(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return (await DbConnection.QueryAsync<HC_ThreadTagBaseInfo>(@"SELECT * FROM HC_ThreadTagBaseInfo WHERE Id = @Id", new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
           }
       }

       /// <summary>
       /// [同步]获取全部HC_ThreadTagBaseInfo 
       /// </summary>
       /// <returns></returns>
       public List<HC_ThreadTagBaseInfo> List()
       {
           using (EnsureHiCommunityConnection())
           {
               return (DbConnection.Query<HC_ThreadTagBaseInfo>(@"SELECT * FROM HC_ThreadTagBaseInfo")).ToList();
           }
       }

       /// <summary>
       /// [异步]获取全部HC_ThreadTagBaseInfo 
       /// </summary>
       /// <returns></returns>
       public async Task<List<HC_ThreadTagBaseInfo>> ListAsync()
       {
           using (EnsureHiCommunityConnection())
           {
               return (await DbConnection.QueryAsync<HC_ThreadTagBaseInfo>(@"SELECT * FROM HC_ThreadTagBaseInfo").ConfigureAwait(false)).ToList();
           }
       }

       /// <summary>
       /// [同步]插入数据HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="threadTagInfo"></param>
       /// <returns></returns>
       public int Insert(HC_ThreadTagBaseInfo threadTagInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_ThreadTagBaseInfo", ColumnName = GeneralTableIdField });
               threadTagInfo.Id = currentID.ToString();
               DbConnection.ExecuteAsync(@"Insert HC_ThreadTagBaseInfo(Id, TypeName, TagName)
                                            values (@Id, @TypeName, @TagName)",
                                           threadTagInfo);
               return currentID;
           }
       }

       /// <summary>
       /// [异步]插入数据HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="threadTagInfo"></param>
       /// <returns></returns>
       public async Task<int> InsertAsync(HC_ThreadTagBaseInfo threadTagInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_ThreadTagBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
               threadTagInfo.Id = currentID.ToString();
               await DbConnection.ExecuteAsync(@"Insert HC_ThreadTagBaseInfo(Id, TypeName, TagName)
                                            values (@Id, @TypeName, @TagName)",
                                           threadTagInfo).ConfigureAwait(false);
               return currentID;
           }
       }

       /// <summary>
       ///[同步]修改数据HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="threadTagInfo"></param>
       /// <returns></returns>
       public int Update(HC_ThreadTagBaseInfo threadTagInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               return DbConnection.Execute(@"Update HC_ThreadTagBaseInfo Set 
                                             TypeName = @TypeName,
                                             TagName = @TagName
                                             Where Id = @Id",
                                            new
                                            {
                                                Id = threadTagInfo.Id,
                                                TypeName = threadTagInfo.TypeName,
                                                TagName = threadTagInfo.TagName
                                            });
           }
       }

       /// <summary>
       ///[异步]修改数据HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="threadTagInfo"></param>
       /// <returns></returns>
       public async Task<int> UpdateAsync(HC_ThreadTagBaseInfo threadTagInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               return await DbConnection.ExecuteAsync(@"Update HC_ThreadTagBaseInfo Set 
                                                        TypeName = @TypeName,
                                                        TagName = @TagName
                                                        Where Id = @Id",
                                                        new
                                                        {
                                                            Id = threadTagInfo.Id,
                                                            TypeName = threadTagInfo.TypeName,
                                                            TagName = threadTagInfo.TagName
                                                        }).ConfigureAwait(false);
           }
       }

       /// <summary>
       /// [同步]删除数据HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int Delete(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return DbConnection.Execute(@"Delete From HC_ThreadTagBaseInfo Where Id = @Id", new { Id = id });
           }
       }

       /// <summary>
       /// [异步]删除数据HC_ThreadTagBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public async Task<int> DeleteAsync(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return await DbConnection.ExecuteAsync(@"Delete From HC_ThreadTagBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
           }
       }

    }
}
