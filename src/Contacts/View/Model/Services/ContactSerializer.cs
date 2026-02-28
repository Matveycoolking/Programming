using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model.Services
{
    public class ContactSerializer
    {
        /// <summary>
        /// Имя файла для хранения контакта
        /// </summary>
        private const string FileName = "contacts.json";

        /// <summary>
        /// Путь к папке "Мои документы"
        /// </summary>
        private static readonly string DocumentsPath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Полный путь к файлу с контактом (свойство, как требует задание)
        /// </summary>
        public static string FilePath =>
            Path.Combine(DocumentsPath, "Contacts", FileName);

        /// <summary>
        /// Сохраняет контакт в JSON файл
        /// </summary>
        /// <param name="contact">Контакт для сохранения</param>
        /// <returns>true - если сохранение успешно, false - если ошибка</returns>
        public static bool SaveContact(Contact contact)
        {
            try
            {
                // Создаем директорию, если её нет
                string directory = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Сериализуем контакт в JSON
                string json = JsonConvert.SerializeObject(contact, Formatting.Indented);

                // Записываем в файл
                File.WriteAllText(FilePath, json);

                return true;
            }
            catch (Exception)
            {
                // В реальном приложении здесь должна быть обработка ошибок
                return false;
            }
        }

        /// <summary>
        /// Загружает контакт из JSON файла
        /// </summary>
        /// <returns>Загруженный контакт или новый контакт, если файл не найден</returns>
        public static Contact LoadContact()
        {
            try
            {
                // Проверяем, существует ли файл
                if (File.Exists(FilePath))
                {
                    // Читаем JSON из файла
                    string json = File.ReadAllText(FilePath);

                    // Десериализуем в объект Contact
                    return JsonConvert.DeserializeObject<Contact>(json);
                }
            }
            catch (Exception)
            {
                // В реальном приложении здесь должна быть обработка ошибок
            }

            // Если файла нет или произошла ошибка, возвращаем новый контакт
            return new Contact();
        }
    }
}
