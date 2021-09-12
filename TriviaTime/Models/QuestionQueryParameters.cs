using System;
using System.ComponentModel.DataAnnotations;

namespace TriviaTime.Models
{
    public class QuestionQueryParameters
    {
        [Required]
        [Range(1,10)]
        public int Amount { get; set; }

    }
}
