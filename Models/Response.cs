public class Response
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public string Answer { get; set; }
    public int UserResponseId { get; set; }
    public UserResponse UserResponse { get; set; }
}
