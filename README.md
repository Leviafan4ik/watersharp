# Инструкция к использованию

#### 1. Скачайте актуальную версию библиотеки по ссылке ниже
[https://github.com/Leviafan4ik/watersharp/releases](https://github.com/Leviafan4ik/watersharp/releases "https://github.com/Leviafan4ik/watersharp/releases")
#### 1.  Создайте прокт на языке C# (.NET Framework 4.5 +)
#### 2.  Переместите библиотеку в ту папку, куда компилируется ваша программа
#### 3. Добавьте ссылку на библиотеку в ваш проект
###### *Ссылки (ПКМ) -> Добавить ссылку -> (внизу) Обзор -> Выбираете файл .dll -> Добавить*
#### 1. Perfect! Можете использовать библиотеку!


------------
*пример использования*

```csharp
using System;
using Watersharp;

namespace Exampler
{
    class Program
    {
        static void Main(string[] args)
        {

            FileSystem.WriteLine(@"D:\MyFile.txt", "Hello World!");             //пример записи в файл

            FileSystem.Append(@"D:\MyFile.txt", "Again hello world!");          //дополнение текста в файле без перезаписи

            FileSystem.Read(@"D:\MyFile.txt");                                  //пример чтения из файла    

            /*--------------------------------------------*/

            Console.WriteLine(Core.DEVELOPER);

            Console.WriteLine(Hardware.CPU_Load());
        }
    }
}
```


З.Ы - Документация будет составлна позже
На данный момент в Visual Studio есть полный набор подсказок к классам, методам и параметрам функций
