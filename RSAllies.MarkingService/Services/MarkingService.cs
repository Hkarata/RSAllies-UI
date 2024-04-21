using Newtonsoft.Json;
using RSAllies.Data.Contracts;

namespace RSAllies.MarkingService.Services;

public static class MarkingService
{
    private static List<AnswerDto>? _answers;

    private static List<AnswerDto> ReadAndDeserialize()
    {
        var json = File.ReadAllText(@"D:\source\RSAllies\RSAllies.PDFService\Answers.json");
        return JsonConvert.DeserializeObject<List<AnswerDto>>(json)!;
    }
    public static int Mark(List<ResponseDto> responses)
    {
        _answers = ReadAndDeserialize();
        var score = 0;

        foreach (var response in responses)
        {
            var correctAnswer = _answers.FirstOrDefault(a => a.QuestionId == response.QuestionId);

            if (correctAnswer != null && correctAnswer.ChoiceId == response.SelectedChoiceId)
            {
                score++;
            }
        }

        return score;
    }

}