using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TriviaTime.Models
{
    public class TriviaQuestionModel
    {
        public string Category { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionType Type { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public QuestionDifficulty Difficulty { get; set; }

        public string Question { get; set; }

        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }

        
        
    }


}
