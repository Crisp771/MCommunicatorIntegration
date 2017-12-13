namespace MCommunicatorIntegration.Interfaces.Dtos
{
    public interface IMcAttachment
    {
        int Id { get; set; }
        int MessageId { get; set; }
        string FileHash { get; set; }
        string FileName { get; set; }
        string ContentType { get; set; }
    }
}