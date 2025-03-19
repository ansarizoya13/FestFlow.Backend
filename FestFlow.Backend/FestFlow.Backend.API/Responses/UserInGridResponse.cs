namespace FestFlow.Backend.API.Responses
{
    public class UserInGridResponse
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string StudenEnrollmentNumber { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAdmin { get; set; }
        public string Branch { get; set; }
    }
}
