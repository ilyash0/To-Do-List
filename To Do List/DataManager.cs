using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


/*
 * Автор: Илья Шмырёв
 * Версия: 1.0
 * Дата последнего изменения: 26.02.2025
 * Назначение: Класс для работы с сохранением и загрузкой данных в формате JSON.
 */
namespace ToDoListApp
{
    public static class DataManager
    {
        public static void SaveToJson(List<ToDo> tasks, string filePath)
        {
            JsonSerializerOptions options = new() { WriteIndented = true };
            using (FileStream stream = new(filePath, FileMode.Create))
            {
                JsonSerializer.Serialize(stream, tasks, options);
            }
        }

        public static List<ToDo> LoadFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return new List<ToDo>();
            }
            using (FileStream stream = new(filePath, FileMode.Open))
            {
                List<ToDo>? tasks = JsonSerializer.Deserialize<List<ToDo>>(stream);
                return tasks ?? new List<ToDo>();
            }
        }
    }
}
