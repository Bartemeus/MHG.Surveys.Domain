public class UserResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
    public List<Response> Responses { get; set; }
    public DateTime SubmittedAt { get; set; }
}
