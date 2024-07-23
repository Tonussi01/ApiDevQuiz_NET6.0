using Newtonsoft.Json;
using ApiDevQuiz.Models;

namespace ApiDevQuiz.Services
{
    public class QuestionService
    {
        private readonly List<QuestionModel> _questions;

        public QuestionService()
        {
            try
            {
                var json = File.ReadAllText("Data/questions.json");
                _questions = JsonConvert.DeserializeObject<List<QuestionModel>>(json);
            }
            catch (Exception ex)
            {
                // Log the exception (configure logging as needed)
                _questions = new List<QuestionModel>();
            }
        }

        public QuestionModel GetRandomQuestion()
        {
            if (_questions == null || !_questions.Any())
            {
                return null;
            }

            var random = new Random();
            return _questions[random.Next(_questions.Count)];
        }
    }
}
