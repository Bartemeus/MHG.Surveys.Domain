﻿public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public List<AnswerOption> Options { get; set; }
    public int SurveyId { get; set; }
    public Survey Survey { get; set; }
}
