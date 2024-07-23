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
                var path = Path.Combine(AppContext.BaseDirectory, "Data", "questions.json");
                Console.WriteLine($"Reading questions from: {path}");
                var json = File.ReadAllText(path);
                _questions = JsonConvert.DeserializeObject<List<QuestionModel>>(json);Console.WriteLine($"Loaded {_questions.Count} questions.");
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"Error reading questions: {ex.Message}");               
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
