using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TriviaTime.Models
{
    public class TriviaQuestionResultsModel
    {

        public IEnumerable<TriviaQuestionModel> Results { get; set; }

        
    }
}
