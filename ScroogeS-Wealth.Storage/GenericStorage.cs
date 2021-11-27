using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ScroogeS_Wealth.Storage
{
    public class GenericStorage<T> where T: IBaseModel
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
            //if (!File.Exists(_filePath))
            //{
            //    using (File.Create(_filePath));
            //}
            string textFromFile = File.ReadAllText(_filePath);
            List<T> elements = new List<T>();
            try
            {
                elements = JsonSerializer.Deserialize<List<T>>(textFromFile);
            }
            catch(Exception ex)
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
        public void Remove(int id)
        {
            var elements = Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            elements.Remove(element);
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonToWrite = JsonSerializer.Serialize(elements, options);
            File.WriteAllText(_filePath, jsonToWrite);
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
        public T FindById(int id)
        {
            var elements = Get();
            var element = elements.FirstOrDefault(x => x.Id == id);
            if (element is null)
            {
                return default;
            }
            return element;
        }

        public int GetNextAvailableId(List<T> elements)
        {
            int lastId;
            if (elements.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = elements.Last().Id + 1;
            }
            return lastId;
        }

        private string GetFilePath()
        {
            var type = typeof(T).Name;            

            return $"C:\\Users\\user\\source\\repos\\ScroogeS-Wealth\\ScroogeS-Wealth.Storage\\App_Data\\{type}.json";
        }
    }
}
