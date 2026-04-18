using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Model.Services
{
    /// <summary>
    /// Класс для сериализации и десериализации контактов
    /// </summary>
    public static class ContactSerializer
    {
        /// <summary>
        /// Имя файла для сохранения данных
        /// </summary>
        private const string FileName = "contacts.json";

        /// <summary>
        /// Путь к файлу в папке приложения
        /// </summary>
        private static string FilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ContactManager",
            FileName);

        /// <summary>
        /// Сохранение коллекции контактов в файл
        /// </summary>
        /// <param name="contacts">Коллекция контактов для сохранения</param>
        public static void Save(IEnumerable<Contact> contacts)
        {
            try
            {
                // Создаем директорию, если её нет
                string? directory = Path.GetDirectoryName(FilePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Настройки сериализации для красивого форматирования
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                // Сериализуем в JSON
                string json = JsonSerializer.Serialize(contacts, options);

                // Сохраняем в файл
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                // В реальном приложении здесь должно быть логирование
                System.Diagnostics.Debug.WriteLine($"Ошибка при сохранении: {ex.Message}");
            }
        }

        /// <summary>
        /// Загрузка коллекции контактов из файла
        /// </summary>
        /// <returns>Коллекция контактов или пустая коллекция, если файл не найден</returns>
        public static ObservableCollection<Contact> Load()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    // Читаем JSON из файла
                    string json = File.ReadAllText(FilePath);

                    // Десериализуем сразу в ObservableCollection
                    return JsonSerializer.Deserialize<ObservableCollection<Contact>>(json)
                        ?? new ObservableCollection<Contact>();
                }
            }
            catch (Exception ex)
            {
                // В реальном приложении здесь должно быть логирование
                System.Diagnostics.Debug.WriteLine($"Ошибка при загрузке: {ex.Message}");
            }

            // Если файла нет или ошибка, возвращаем пустую коллекцию
            return new ObservableCollection<Contact>();
        }

        /// <summary>
        /// Проверка существования файла с данными
        /// </summary>
        public static bool HasSavedData => File.Exists(FilePath);
    }
}
