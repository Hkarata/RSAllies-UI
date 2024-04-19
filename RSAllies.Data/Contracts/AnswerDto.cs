namespace RSAllies.Data.Contracts;

public record AnswerDto
{
    public Guid QuestionId { get; set; }    
    public Guid ChoiceId { get; set; }
}