namespace BlazorAssessment.Data
{
    /// <summary>
    /// Represents a user with a username, email, and last login date.
    /// </summary>
    public class User
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}
