namespace TIMAO.Domain
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string NickName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}