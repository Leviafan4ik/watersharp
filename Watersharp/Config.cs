using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Watersharp
{
    /// <summary>
    /// Класс для работы с файлами конфигураций (.INI)
    /// </summary>
    public class Config
    {

        private static string Path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public Config(string IniPath)
        {
            Path = new FileInfo(IniPath).FullName.ToString();
        }

        /// <summary>
        /// Изменение пути к рабочему ini файлу
        /// </summary>
        /// <param name="NewPath">Путь к файлу</param>
        public static void SetIniPath(string NewPath)
        {
            Path = NewPath;
        }

        /// <summary>
        /// Чтение значения параметра по имени
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - default)</param>
        public string Get(string key, string section = "default")
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        /// <summary>
        /// Запись значения параметра по имени
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="value">Значение</param>
        /// <param name="section">Секция параметра (по умолчанию - default)</param>
        public void Set(string key, string value, string section = "default")
        {
            WritePrivateProfileString(section, key, value, Path);
        }

        /// <summary>
        /// Полное удаление параметра по имени
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - default)</param>
        public void DeleteKey(string key, string section = "default")
        {
            Set(section, key, null);
        }

        /// <summary>
        /// Полное удаление секции и входящих в неё параметров
        /// </summary>
        /// <param name="section">Имя секции (по умолчанию - default)</param>
        public void DeleteSection(string section = "default")
        {
            Set(section, null, null);
        }

        /// <summary>
        /// Проверка существования параметра с указанным именем
        /// </summary>
        /// <param name="key">Имя параметра</param>
        /// <param name="section">Секция параметра (по умолчанию - default)</param>
        public bool KeyExists(string key, string section = "default")
        {
            return Get(section, key).Length > 0;
        }

    }
}
