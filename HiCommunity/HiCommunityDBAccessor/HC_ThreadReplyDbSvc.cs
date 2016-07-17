using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
  public class HC_ThreadReplyDbSvc : BaseDbSvc
    {
      public HC_ThreadReplyDbSvc() { }

      public HC_ThreadReplyDbSvc(MySql.Data.MySqlClient.MySqlConnection connection)
          : base(connection) { }

      /// <summary>
      /// [同步]根据Id获取HC_ThreadBaseInfo
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public HC_ThreadBaseInfo GetById(string id)
      {
          using (EnsureHiCommunityConnection())
          {
              return (DbConnection.Query<HC_ThreadBaseInfo>(@"SELECT * FROM HC_ThreadBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
          }
      }

      /// <summary>
      /// [异步]根据Id获取HC_ThreadBaseInfo
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public async Task<HC_ThreadBaseInfo> GetByIdAsync(string id)
      {
          using (EnsureHiCommunityConnection())
          {
              return (await DbConnection.QueryAsync<HC_ThreadBaseInfo>(@"SELECT * FROM HC_ThreadBaseInfo WHERE Id = @Id", new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
          }
      }

      /// <summary>
      /// [同步]获取全部HC_ThreadBaseInfo 
      /// </summary>
      /// <returns></returns>
      public List<HC_ThreadBaseInfo> List()
      {
          using (EnsureHiCommunityConnection())
          {
              return (DbConnection.Query<HC_ThreadBaseInfo>(@"SELECT * FROM HC_ThreadBaseInfo")).ToList();
          }
      }

      /// <summary>
      /// [异步]获取全部HC_ThreadBaseInfo 
      /// </summary>
      /// <returns></returns>
      public async Task<List<HC_ThreadBaseInfo>> ListAsync()
      {
          using (EnsureHiCommunityConnection())
          {
              return (await DbConnection.QueryAsync<HC_ThreadBaseInfo>(@"SELECT * FROM HC_ThreadBaseInfo").ConfigureAwait(false)).ToList();
          }
      }

      /// <summary>
      /// [同步]插入数据HC_ThreadBaseInfo
      /// </summary>
      /// <param name="threadInfo"></param>
      /// <returns></returns>
      public int Insert(HC_ThreadBaseInfo threadInfo)
      {
          using (EnsureHiCommunityConnection())
          {
              int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_ThreadBaseInfo", ColumnName = GeneralTableIdField });
              threadInfo.Id = currentID.ToString();
              DbConnection.ExecuteAsync(@"Insert HC_ThreadBaseInfo(Id, ThreadTitle, ThreadContent, ThreadAudio, ThreadImage, TimeMark, TagID, CategoryID, UserID, PraiseUsers, PraiseCount, ReplyCount)
                                            values (@Id, @ThreadTitle, @ThreadContent, @ThreadAudio, @ThreadImage, @TimeMark, @TagID, @CategoryID, @UserID, @PraiseUsers, @PraiseCount, @ReplyCount)",
                                          threadInfo);
              return currentID;
          }
      }

      /// <summary>
      /// [异步]插入数据HC_ThreadBaseInfo
      /// </summary>
      /// <param name="threadInfo"></param>
      /// <returns></returns>
      public async Task<int> InsertAsync(HC_ThreadBaseInfo threadInfo)
      {
          using (EnsureHiCommunityConnection())
          {
              int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_ThreadBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
              threadInfo.Id = currentID.ToString();
              await DbConnection.ExecuteAsync(@"Insert HC_ThreadBaseInfo(Id, ThreadTitle, ThreadContent, ThreadAudio, ThreadImage, TimeMark, TagID, CategoryID, UserID, PraiseUsers, PraiseCount, ReplyCount)
                                            values (@Id, @ThreadTitle, @ThreadContent, @ThreadAudio, @ThreadImage, @TimeMark, @TagID, @CategoryID, @UserID, @PraiseUsers, @PraiseCount, @ReplyCount)",
                                          threadInfo).ConfigureAwait(false);
              return currentID;
          }
      }

      /// <summary>
      ///[同步]修改数据HC_ThreadBaseInfo
      /// </summary>
      /// <param name="threadInfo"></param>
      /// <returns></returns>
      public int Update(HC_ThreadBaseInfo threadInfo)
      {
          using (EnsureHiCommunityConnection())
          {
              return DbConnection.Execute(@"Update HC_ThreadBaseInfo Set 
                                            ThreadTitle = @ThreadTitle,
                                            ThreadContent = @ThreadContent,
                                            ThreadAudio = @ThreadAudio,
                                            ThreadImage = @ThreadImage,
                                            TimeMark = @TimeMark,
                                            TagID = @TagID,
                                            CategoryID = @CategoryID,
                                            UserID = @UserID,
                                            PraiseUsers = @PraiseUsers,
                                            PraiseCount = @PraiseCount,
                                            ReplyCount = @ReplyCount
                                            Where Id = @Id",
                                          new
                                          {
                                              Id = threadInfo.Id,
                                              ThreadTitle = threadInfo.ThreadTitle,
                                              ThreadContent = threadInfo.ThreadContent,
                                              ThreadAudio = threadInfo.ThreadAudio,
                                              ThreadImage = threadInfo.ThreadImage,
                                              TimeMark = threadInfo.TimeMark,
                                              TagID = threadInfo.TagID,
                                              CategoryID = threadInfo.CategoryID,
                                              UserID = threadInfo.UserID,
                                              PraiseUsers = threadInfo.PraiseUsers,
                                              PraiseCount = threadInfo.PraiseCount,
                                              ReplyCount = threadInfo.ReplyCount
                                          });
          }
      }

      /// <summary>
      ///[异步]修改数据HC_ThreadBaseInfo
      /// </summary>
      /// <param name="threadInfo"></param>
      /// <returns></returns>
      public async Task<int> UpdateAsync(HC_ThreadBaseInfo threadInfo)
      {
          using (EnsureHiCommunityConnection())
          {
              return await DbConnection.ExecuteAsync(@"Update HC_ThreadBaseInfo Set 
                                                        ThreadTitle = @ThreadTitle,
                                                        ThreadContent = @ThreadContent,
                                                        ThreadAudio = @ThreadAudio,
                                                        ThreadImage = @ThreadImage,
                                                        TimeMark = @TimeMark,
                                                        TagID = @TagID,
                                                        CategoryID = @CategoryID,
                                                        UserID = @UserID,
                                                        PraiseUsers = @PraiseUsers,
                                                        PraiseCount = @PraiseCount,
                                                        ReplyCount = @ReplyCount
                                                        Where Id = @Id",
                                                      new
                                                      {
                                                          Id = threadInfo.Id,
                                                          ThreadTitle = threadInfo.ThreadTitle,
                                                          ThreadContent = threadInfo.ThreadContent,
                                                          ThreadAudio = threadInfo.ThreadAudio,
                                                          ThreadImage = threadInfo.ThreadImage,
                                                          TimeMark = threadInfo.TimeMark,
                                                          TagID = threadInfo.TagID,
                                                          CategoryID = threadInfo.CategoryID,
                                                          UserID = threadInfo.UserID,
                                                          PraiseUsers = threadInfo.PraiseUsers,
                                                          PraiseCount = threadInfo.PraiseCount,
                                                          ReplyCount = threadInfo.ReplyCount
                                                      }).ConfigureAwait(false);
          }
      }

      /// <summary>
      /// [同步]删除数据HC_ThreadBaseInfo
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public int Delete(string id)
      {
          using (EnsureHiCommunityConnection())
          {
              return DbConnection.Execute(@"Delete From HC_ThreadBaseInfo Where Id = @Id", new { Id = id });
          }
      }

      /// <summary>
      /// [异步]删除数据HC_ThreadBaseInfo
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public async Task<int> DeleteAsync(string id)
      {
          using (EnsureHiCommunityConnection())
          {
              return await DbConnection.ExecuteAsync(@"Delete From HC_ThreadBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
          }
      }


    }
}
