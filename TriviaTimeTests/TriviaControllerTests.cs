using System;
using Xunit;
using Moq;
using TriviaTime.Controllers;
using TriviaTime.Services;
using TriviaTime.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TriviaTimeTests
{
    public class TriviaControllerTests
    {

        [Fact]
        public async Task GetQuestions_Returns_The_Correct_Amount_Of_Questions()
        {
            // Arrange
            int count = 1;
            var queryParameters = new QuestionQueryParameters() { Amount = count };
            var mockQuestionService = new Mock<ITriviaService>();
            mockQuestionService.Setup(service => service.GetQuestions(queryParameters))
                .ReturnsAsync(GetTestQuestions(count));
            var controller = new TriviaController(mockQuestionService.Object);

            // Act
            var actionResult = await controller.Get(queryParameters);

            // Assert
            var result = actionResult as OkObjectResult;
            var data = result.Value as TriviaQuestionResultsModel;
            Assert.Equal(count, data.Results.Count());
                    
        }


        // TODO: Move this question to integration tests for proper model state validation
        //[Theory]
        //[InlineData(11)]
        //[InlineData(0)]
        //public async Task GetMultipleQuestions_Returns_400_For_Invalid_Question_Amount(int count)
        //{
        //    // Arrange
        //    var mockQuestionService = new Mock<ITriviaService>();
        //    mockQuestionService.Setup(service => service.GetQuestions(count))
        //        .ReturnsAsync(GetTestQuestions(count));
        //    var controller = new TriviaController(mockQuestionService.Object);

        //    // Act
        //    controller.ModelState.AddModelError("Amount", "The field Amount must be between 1 and 10.");
        //    var actionResult = await controller.Get(new QuestionQueryParameters() { Amount = count });
            
        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(actionResult);
            

        //}

        private TriviaQuestionResultsModel GetTestQuestions(int count)
        {
            var questions = new List<TriviaQuestionModel>();
            for(int i = 0; i < count; i++)
            {
                questions.Add(new TriviaQuestionModel());
            }
            var resultsModel = new TriviaQuestionResultsModel() { Results = questions };
            return resultsModel;
        }
    }
}
