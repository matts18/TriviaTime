using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TriviaTime.Models
{
    public class QuestionQueryParameters
    {
        [Required]
        [Range(1, 10)]
        public int? Amount { get; set; }
        public int? Category { get; set; }
        public QuestionType? Type { get; set; }
        public QuestionDifficulty? Difficulty { get; set; }

    }
}
