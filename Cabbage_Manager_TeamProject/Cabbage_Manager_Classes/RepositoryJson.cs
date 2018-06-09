using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabbage_Manager_Classes
{
    public class RepositoryJson
    {
        public List<Category> categories { get; set; }
        private const string FileName = "..//..//..//categories.json";

        public RepositoryJson()
        {
            //Save();
            Restore();
        }
        private List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }
        /*
        private void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;

                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, list);
                }
            }
        }
        public void Save()
        {
            /*
            categories = new List<Category>();
            categories.Add(new Category { Id = 1, Name = "Food", ColourCode = "#FF7F50" });
            categories.Add(new Category { Id = 2, Name = "Eating out", ColourCode = "#DC143C" });
            categories.Add(new Category { Id = 3, Name = "Entertainment", ColourCode = "#DB7093" });
            categories.Add(new Category { Id = 4, Name = "Transport", ColourCode = "##8FBC8F" });
            categories.Add(new Category { Id = 5, Name = "Health and beauty", ColourCode = "#6B8E23" });
            categories.Add(new Category { Id = 6, Name = "Clothes", ColourCode = "#A52A2A" });
            categories.Add(new Category { Id = 7, Name = "Purchases", ColourCode = "#D2B48C" });
            SaveList(FileName, categories);
        }
        */

        private void Restore()
        {
            categories = RestoreList<Category>(FileName);
        }

    }
}
