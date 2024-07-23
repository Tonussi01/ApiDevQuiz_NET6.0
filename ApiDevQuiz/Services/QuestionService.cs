using Newtonsoft.Json;
using ApiDevQuiz.Models;
using Microsoft.Extensions.Logging;
using System.IO;

namespace ApiDevQuiz.Services
{
    public class QuestionService
    {
        private readonly List<QuestionModel> _questions;
        private readonly ILogger<QuestionService> _logger;

        public QuestionService(ILogger<QuestionService> logger)
        {
            _logger = logger;
            _questions = LoadQuestions();
        }

        private List<QuestionModel> LoadQuestions()
        {
            try
            {
                // Obter o diretório base da aplicação
                var baseDirectory = AppContext.BaseDirectory;
                _logger.LogInformation($"Base directory: {baseDirectory}");

                var filePath = Path.Combine(baseDirectory, "Data/questions.json");
                _logger.LogInformation($"Attempting to read questions from: {filePath}");

                if (!File.Exists(filePath))
                {
                    _logger.LogError($"File not found: {filePath}");
                    return new List<QuestionModel>();
                }

                var json = File.ReadAllText(filePath);
                var questions = JsonConvert.DeserializeObject<List<QuestionModel>>(json);

                if (questions == null || !questions.Any())
                {
                    _logger.LogWarning("No questions were deserialized from the file.");
                }

                return questions;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading or deserializing the questions file.");
                return new List<QuestionModel>();
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
