CREATE TABLE [dbo].[tblMcAttachments]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [McAttachmentId] INT NOT NULL, 
    [MessageId] INT NOT NULL, 
    [FileHash] NVARCHAR(50) NOT NULL, 
    [FileName] NVARCHAR(255) NOT NULL, 
    [ContentType] NVARCHAR(100) NOT NULL
)
