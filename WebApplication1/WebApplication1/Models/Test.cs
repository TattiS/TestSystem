using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Test
    {
        
        public List<Question> Questions { get; set; }

        public void SeedQuestions(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                var json = reader.ReadToEnd();
                var questions = JsonConvert.DeserializeObject<List<Question>>(json);
                if (Questions != null)
                {
                    foreach (var question in questions)
                    {
                        Questions.Add(question);
                    }
                }
               else
                {
                    Questions = new List<Question>();
                    foreach (var question in questions)
                    {
                        Questions.Add(question);
                    }
                }
            }
        }
    }
}
