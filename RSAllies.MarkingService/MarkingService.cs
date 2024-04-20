using RSAllies.Data.Contracts;

namespace RSAllies.MarkingService;

public static class MarkingService
{
    public static int Mark(List<AnswerDto> answers, List<ResponseDto> responses)
    {
        var score = 0;

        foreach (var response in responses)
        {
            var correctAnswer = answers.FirstOrDefault(a => a.QuestionId == response.QuestionId);

            if (correctAnswer != null && correctAnswer.ChoiceId == response.SelectedChoiceId)
            {
                score++;
            }
        }

        return score;
    }
}