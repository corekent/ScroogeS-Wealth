using Core;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ScroogeS_Wealth.Storage
{
    public class GenericStorage<T> where T: BaseModel
    {
        private string _filePath;
        public GenericStorage()
        {
            _filePath = GetFilePath();
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
            }
        }
        public List<T> Get()
        {
            string textFromFile = File.ReadAllText(_filePath);
            List<T> elements;
            try
            {
                elements = JsonSerializer.Deserialize<List<T>>(textFromFile);
            }
            catch
            {
                elements = new List<T>();
            }
            return elements;
        }
        public T Add(T element)
        {
            var elements = Get();
            elements.Add(element);
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonToWrite = JsonSerializer.Serialize(elements, options);
            File.WriteAllText(_filePath, jsonToWrite);
            return element;
        }

        public T Update(T element, int elementId)
        {
            var elements = Get();

            var elementToUpdate = elements.FirstOrDefault(x => x.Id == elementId);

            elements.Remove(elementToUpdate);
            element.Id = elementId;
            elements.Add(element);

            var newElements = elements.OrderBy(x => x.Id).ToList();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var jsonToWrite = JsonSerializer.Serialize(newElements, options);

            File.WriteAllText(_filePath, jsonToWrite);

            return element;
        }
        private string GetFilePath()
        {
            var type = typeof(T).Name;
            return $"C:\\Users\\darrk\\source\\repos\\ScroogeS-Wealth\\ScroogeS-Wealth\\ScroogeS-Wealth.Storage\\App_Data\\{type}.json";

        }
    }
}
