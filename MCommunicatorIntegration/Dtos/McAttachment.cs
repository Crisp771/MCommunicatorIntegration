using MCommunicatorIntegration.Interfaces.Dtos;

namespace MCommunicatorIntegration.Dtos
{
    public class McAttachment : IMcAttachment
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string FileHash { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    }
}