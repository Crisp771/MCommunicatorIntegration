using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MCommunicatorIntegration.Interfaces.Dtos;
using MCommunicatorIntegration.Interfaces.Repositories;
using MCommunicatorIntegration.Interfaces.Wrappers;

namespace MCommunicatorIntegration.Repositories
{
    public class McAttachmentRepository : IMcAttachmentRepository
    {
        private readonly ISqlWrapper _sqlWrapper;

        public McAttachmentRepository(ISqlWrapper sqlWrapper)
        {
            _sqlWrapper = sqlWrapper;
        }

        public void Insert(IMcAttachment entity)
        {
            using (var connection = _sqlWrapper.Connection())
            {
                var command = _sqlWrapper.Command($"MERGE INTO tblMcAttachments AS Target \r\n" +
                                                  $"USING (VALUES (@Id,@McAttachmentId,@MessageId,@FileHash,@FileName,@ContentType)) \r\n" +
                                                  $"AS Source ([Id],[McAttachmentId],[MessageId],[FileHash],[FileName],[ContentType]) \r\n" +
                                                  $"ON Target.[Id] = Source.[Id] \r\n" +
                                                  $"WHEN MATCHED THEN \r\n" +
                                                  $"UPDATE SET [McAttachmentId] = Source.[McAttachmentId],[MessageId] = Source.[MessageId],[FileHash] = Source.[FileHash],\r\n" +
                                                  $"[FileName] = Source.[FileName],[ContentType] = Source.[ContentType]\r\n" +
                                                  $"WHEN NOT MATCHED BY TARGET THEN \r\n" +
                                                  $"INSERT ([McAttachmentId],[MessageId],[FileHash],[FileName],[ContentType]) \r\n" +
                                                  $"VALUES ([McAttachmentId],[MessageId],[FileHash],[FileName],[ContentType]);\r\n", connection);

                command.Parameters.Add(new SqlParameter("@Id", null));
                command.Parameters.Add(new SqlParameter("@McAttachmentId", entity.Id));
                command.Parameters.Add(new SqlParameter("@MessageId", entity.MessageId));
                command.Parameters.Add(new SqlParameter("@FileHash", entity.FileHash));
                command.Parameters.Add(new SqlParameter("@FileName", entity.FileName));
                command.Parameters.Add(new SqlParameter("@ContentType", entity.ContentType));


                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(IMcAttachment entity)
        {
            throw new NotSupportedException();
        }

        public IEnumerable<IMcAttachment> GetAll()
        {
            throw new NotSupportedException();
        }

        public IMcAttachment GetById(int id)
        {
            throw new NotSupportedException();
        }

        public IMcAttachment GetById(string id)
        {
            throw new NotSupportedException();
        }
    }
}