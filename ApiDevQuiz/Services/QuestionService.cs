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
            try
            {
                // Verifique o diretório atual
                var currentDirectory = Directory.GetCurrentDirectory();
                _logger.LogInformation($"Current directory: {currentDirectory}");

                var filePath = Path.Combine(currentDirectory, "Data/questions.json");
                _logger.LogInformation($"Attempting to read questions from: {filePath}");

                if (!File.Exists(filePath))
                {
                    _logger.LogError($"File not found: {filePath}");
                    _questions = new List<QuestionModel>();
                    return;
                }

                var json = File.ReadAllText(filePath);
                _questions = JsonConvert.DeserializeObject<List<QuestionModel>>(json);

                if (_questions == null || !_questions.Any())
                {
                    _logger.LogWarning("No questions were deserialized from the file.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reading or deserializing the questions file.");
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
