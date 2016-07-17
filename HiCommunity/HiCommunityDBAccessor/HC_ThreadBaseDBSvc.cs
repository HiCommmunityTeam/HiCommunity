using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDataDefine;
using Dapper;

namespace HiCommunityDBAccessor
{
    public class HC_ThreadBaseDbSvc : BaseDbSvc
    {
        public HC_ThreadBaseDbSvc() { }

        public HC_ThreadBaseDbSvc(MySql.Data.MySqlClient.MySqlConnection commection)
            : base(commection) { }
        
        /// <summary>
        /// [同步]根据Id获取HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HC_ThreadReplyBaseInfo GetById(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_ThreadReplyBaseInfo>(@"SELECT * FROM HC_ThreadReplyBaseInfo WHERE Id = @Id", new { Id = id })).FirstOrDefault();
            }
        }

        /// <summary>
        /// [异步]根据Id获取HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HC_ThreadReplyBaseInfo> GetByIdAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_ThreadReplyBaseInfo>(@"SELECT * FROM HC_ThreadReplyBaseInfo WHERE Id = @Id", new { Id = id }).ConfigureAwait(false)).FirstOrDefault();
            }
        }

        /// <summary>
        /// [同步]获取全部HC_ThreadReplyBaseInfo 
        /// </summary>
        /// <returns></returns>
        public List<HC_ThreadReplyBaseInfo> List()
        {
            using (EnsureHiCommunityConnection())
            {
                return (DbConnection.Query<HC_ThreadReplyBaseInfo>(@"SELECT * FROM HC_ThreadReplyBaseInfo")).ToList();
            }
        }

        /// <summary>
        /// [异步]获取全部HC_ThreadReplyBaseInfo 
        /// </summary>
        /// <returns></returns>
        public async Task<List<HC_ThreadReplyBaseInfo>> ListAsync()
        {
            using (EnsureHiCommunityConnection())
            {
                return (await DbConnection.QueryAsync<HC_ThreadReplyBaseInfo>(@"SELECT * FROM HC_ThreadReplyBaseInfo").ConfigureAwait(false)).ToList();
            }
        }

        /// <summary>
        /// [同步]插入数据HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="threadReplyInfo"></param>
        /// <returns></returns>
        public int Insert(HC_ThreadReplyBaseInfo threadReplyInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = DbConnection.ExecuteScalar<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_ThreadReplyBaseInfo", ColumnName = GeneralTableIdField });
                threadReplyInfo.Id = currentID.ToString();
                DbConnection.ExecuteAsync(@"Insert HC_ThreadReplyBaseInfo(Id, ReplyUID, TimeMark, ReplyText, ReplyAudio, ReplyImage, ReplyToUID, ThreadID)
                                            values (@Id, @ReplyUID, @TimeMark, @ReplyText, @ReplyAudio, @ReplyImage, @ReplyToUID, @ThreadID)",
                                            threadReplyInfo);
                return currentID;
            }
        }

        /// <summary>
        /// [异步]插入数据HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="threadReplyInfo"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(HC_ThreadReplyBaseInfo threadReplyInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                int currentID = await DbConnection.ExecuteScalarAsync<int>(@"UPDATE HC_TableId SET CurrentID = LAST_INSERT_ID(CurrentID + 1) Where TableName = @TableName and ColumnName = @ColumnName; SELECT LAST_INSERT_ID();", new { TableName = "HC_ThreadReplyBaseInfo", ColumnName = GeneralTableIdField }).ConfigureAwait(false);
                threadReplyInfo.Id = currentID.ToString();
                await DbConnection.ExecuteAsync(@"Insert HC_ThreadReplyBaseInfo(Id, ReplyUID, TimeMark, ReplyText, ReplyAudio, ReplyImage, ReplyToUID, ThreadID)
                                            values (@Id, @ReplyUID, @TimeMark, @ReplyText, @ReplyAudio, @ReplyImage, @ReplyToUID, @ThreadID)",
                                            threadReplyInfo).ConfigureAwait(false);
                return currentID;
            }
        }

        /// <summary>
        ///[同步]修改数据HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="threadReplyInfo"></param>
        /// <returns></returns>
        public int Update(HC_ThreadReplyBaseInfo threadReplyInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                return DbConnection.Execute(@"Update HC_ThreadReplyBaseInfo Set 
                                            ReplyUID = @ReplyUID,
                                            TimeMark = @TimeMark,
                                            ReplyText = @ReplyText,
                                            ReplyAudio = @ReplyAudio,
                                            ReplyImage = @ReplyImage,
                                            ReplyToUID = @ReplyToUID,
                                            ThreadID = @ThreadID
                                            Where Id = @Id",
                                            new
                                            {
                                                Id = threadReplyInfo.Id,
                                                ReplyUID = threadReplyInfo.ReplyUID,
                                                ReplyText = threadReplyInfo.ReplyText,
                                                ReplyAudio = threadReplyInfo.ReplyAudio,
                                                ReplyImage = threadReplyInfo.ReplyImage,
                                                ReplyToUID = threadReplyInfo.ReplyToUID,
                                                ThreadID = threadReplyInfo.ThreadID
                                            });
            }
        }

        /// <summary>
        ///[异步]修改数据HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="threadReplyInfo"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(HC_ThreadReplyBaseInfo threadReplyInfo)
        {
            using (EnsureHiCommunityConnection())
            {
                return await DbConnection.ExecuteAsync(@"Update HC_ThreadReplyBaseInfo Set 
                                                        ReplyUID = @ReplyUID,
                                                        TimeMark = @TimeMark,
                                                        ReplyText = @ReplyText,
                                                        ReplyAudio = @ReplyAudio,
                                                        ReplyImage = @ReplyImage,
                                                        ReplyToUID = @ReplyToUID,
                                                        ThreadID = @ThreadID
                                                        Where Id = @Id",
                                                        new
                                                        {
                                                            Id = threadReplyInfo.Id,
                                                            ReplyUID = threadReplyInfo.ReplyUID,
                                                            ReplyText = threadReplyInfo.ReplyText,
                                                            ReplyAudio = threadReplyInfo.ReplyAudio,
                                                            ReplyImage = threadReplyInfo.ReplyImage,
                                                            ReplyToUID = threadReplyInfo.ReplyToUID,
                                                            ThreadID = threadReplyInfo.ThreadID
                                                        }).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// [同步]删除数据HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return DbConnection.Execute(@"Delete From HC_ThreadReplyBaseInfo Where Id = @Id", new { Id = id });
            }
        }

        /// <summary>
        /// [异步]删除数据HC_ThreadReplyBaseInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(string id)
        {
            using (EnsureHiCommunityConnection())
            {
                return await DbConnection.ExecuteAsync(@"Delete From HC_ThreadReplyBaseInfo Where Id = @Id", new { Id = id }).ConfigureAwait(false);
            }
        }

    }
}
