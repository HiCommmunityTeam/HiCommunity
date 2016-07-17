using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
   public class HC_NotifyMsgDbSvc : BaseDbSvc
    {
       public HC_NotifyMsgDbSvc() { }

       public HC_NotifyMsgDbSvc(MySql.Data.MySqlClient.MySqlConnection connection)
           : base(connection) { }
       
       /// <summary>
       /// [同步]根据Id获取HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public HC_NotifyMsgBaseInfo GetById(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return (DbConnection.Query<HC_NotifyMsgBaseInfo>(@"SELECT * FROM HC_NotifyMsgBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
           }
       }

       /// <summary>
       /// [异步]根据Id获取HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public async Task<HC_NotifyMsgBaseInfo> GetByIdAsync(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return (await DbConnection.QueryAsync<HC_NotifyMsgBaseInfo>(@"SELECT * FROM HC_NotifyMsgBaseInfo WHERE Id = @Id", new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
           }
       }

       /// <summary>
       /// [同步]获取全部HC_NotifyMsgBaseInfo 
       /// </summary>
       /// <returns></returns>
       public List<HC_NotifyMsgBaseInfo> List()
       {
           using (EnsureHiCommunityConnection())
           {
               return (DbConnection.Query<HC_NotifyMsgBaseInfo>(@"SELECT * FROM HC_NotifyMsgBaseInfo")).ToList();
           }
       }

       /// <summary>
       /// [异步]获取全部HC_NotifyMsgBaseInfo 
       /// </summary>
       /// <returns></returns>
       public async Task<List<HC_NotifyMsgBaseInfo>> ListAsync()
       {
           using (EnsureHiCommunityConnection())
           {
               return (await DbConnection.QueryAsync<HC_NotifyMsgBaseInfo>(@"SELECT * FROM HC_NotifyMsgBaseInfo").ConfigureAwait(false)).ToList();
           }
       }

       /// <summary>
       /// [同步]插入数据HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="notifyMsgInfo"></param>
       /// <returns></returns>
       public int Insert(HC_NotifyMsgBaseInfo notifyMsgInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_NotifyMsgBaseInfo", ColumnName = GeneralTableIdField });
               notifyMsgInfo.Id = currentID.ToString();
               DbConnection.ExecuteAsync(@"Insert HC_NotifyMsgBaseInfo(Id, UserID, MsgType, MsgConect, MsgStatus, TimeMark)
                                            values (@Id, @UserID, @MsgType, @MsgConect, @MsgStatus, @TimeMark)",
                                           notifyMsgInfo);
               return currentID;
           }
       }

       /// <summary>
       /// [异步]插入数据HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="notifyMsgInfo"></param>
       /// <returns></returns>
       public async Task<int> InsertAsync(HC_NotifyMsgBaseInfo notifyMsgInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_NotifyMsgBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
               notifyMsgInfo.Id = currentID.ToString();
               await DbConnection.ExecuteAsync(@"Insert HC_NotifyMsgBaseInfo(Id, UserID, MsgType, MsgConect, MsgStatus, TimeMark)
                                            values (@Id, @UserID, @MsgType, @MsgConect, @MsgStatus, @TimeMark)",
                                           notifyMsgInfo).ConfigureAwait(false);
               return currentID;
           }
       }

       /// <summary>
       ///[同步]修改数据HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="notifyMsgInfo"></param>
       /// <returns></returns>
       public int Update(HC_NotifyMsgBaseInfo notifyMsgInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               return DbConnection.Execute(@"Update HC_NotifyMsgBaseInfo Set 
                                            UserID = @UserID, 
                                            MsgType = @MsgType,
                                            MsgConect = @MsgConect,
                                            MsgStatus = @MsgStatus,
                                            TimeMark = @TimeMark
                                            Where Id = @Id",
                                            new
                                            {
                                                Id = notifyMsgInfo.Id,
                                                UserID = notifyMsgInfo.UserID,
                                                MsgType = notifyMsgInfo.MsgType,
                                                MsgConect = notifyMsgInfo.MsgConect,
                                                MsgStatus = notifyMsgInfo.MsgStatus,
                                                TimeMark = notifyMsgInfo.TimeMark
                                            });
           }
       }

       /// <summary>
       ///[异步]修改数据HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="notifyMsgInfo"></param>
       /// <returns></returns>
       public async Task<int> UpdateAsync(HC_NotifyMsgBaseInfo notifyMsgInfo)
       {
           using (EnsureHiCommunityConnection())
           {
               return await DbConnection.ExecuteAsync(@"Update HC_NotifyMsgBaseInfo Set 
                                                        UserID = @UserID, 
                                                        MsgType = @MsgType,
                                                        MsgConect = @MsgConect,
                                                        MsgStatus = @MsgStatus,
                                                        TimeMark = @TimeMark
                                                        Where Id = @Id",
                                                       new
                                                       {
                                                           Id = notifyMsgInfo.Id,
                                                           UserID = notifyMsgInfo.UserID,
                                                           MsgType = notifyMsgInfo.MsgType,
                                                           MsgConect = notifyMsgInfo.MsgConect,
                                                           MsgStatus = notifyMsgInfo.MsgStatus,
                                                           TimeMark = notifyMsgInfo.TimeMark
                                                        }).ConfigureAwait(false);
           }
       }

       /// <summary>
       /// [同步]删除数据HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public int Delete(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return DbConnection.Execute(@"Delete From HC_NotifyMsgBaseInfo Where Id = @Id", new { Id = id });
           }
       }

       /// <summary>
       /// [异步]删除数据HC_NotifyMsgBaseInfo
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public async Task<int> DeleteAsync(string id)
       {
           using (EnsureHiCommunityConnection())
           {
               return await DbConnection.ExecuteAsync(@"Delete From HC_NotifyMsgBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
           }
       }

    }
}
