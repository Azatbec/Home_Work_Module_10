using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Module_10_2
{
    using System;
    using System.Collections.Generic;

    // Абстрактный класс FileSystemComponent, общий интерфейс для файлов и папок
    public abstract class FileSystemComponent
    {
        public string Name { get; }  // Имя компонента

        protected FileSystemComponent(string name)
        {
            Name = name;
        }

        // Метод для отображения информации о компоненте
        public abstract void Display(string indent = "");

        // Метод для получения размера компонента
        public abstract int GetSize();
    }

    // Класс File, представляющий файл
    public class File : FileSystemComponent
    {
        private readonly int _size;

        public File(string name, int size) : base(name)
        {
            _size = size;
        }

        public override void Display(string indent = "")
        {
            Console.WriteLine($"{indent}Файл: {Name}, размер: {_size}KB");
        }

        public override int GetSize() => _size;
    }

    // Класс Directory, представляющий папку
    public class Directory : FileSystemComponent
    {
        private readonly List<FileSystemComponent> _components = new List<FileSystemComponent>();

        public Directory(string name) : base(name) { }

        public override void Display(string indent = "")
        {
            Console.WriteLine($"{indent}Папка: {Name}");
            foreach (var component in _components)
            {
                component.Display(indent + "  ");
            }
        }

        public override int GetSize()
        {
            int totalSize = 0;
            foreach (var component in _components)
            {
                totalSize += component.GetSize();
            }
            return totalSize;
        }

        public void AddComponent(FileSystemComponent component)
        {
            if (!_components.Contains(component))
            {
                _components.Add(component);
                Console.WriteLine($"Добавлен компонент: {component.GetType().Name} - {component.Name} в папку {Name}");
            }
            else
            {
                Console.WriteLine($"Компонент {component.Name} уже существует в папке {Name}");
            }
        }

        public void RemoveComponent(FileSystemComponent component)
        {
            if (_components.Contains(component))
            {
                _components.Remove(component);
                Console.WriteLine($"Удален компонент: {component.GetType().Name} - {component.Name} из папки {Name}");
            }
            else
            {
                Console.WriteLine($"Компонент {component.Name} отсутствует в папке {Name}");
            }
        }
    }

    // Тестирование системы
    public class Program
    {
        public static void Main()
        {
            // Создаем файлы
            var file1 = new File("Документ1.txt", 50);
            var file2 = new File("Изображение1.jpg", 200);
            var file3 = new File("Видео1.mp4", 1500);

            // Создаем папки
            var rootDirectory = new Directory("Корневая папка");
            var documentsDirectory = new Directory("Документы");
            var mediaDirectory = new Directory("Медиа");

            // Создаем иерархию
            rootDirectory.AddComponent(documentsDirectory);
            rootDirectory.AddComponent(mediaDirectory);

            documentsDirectory.AddComponent(file1);
            mediaDirectory.AddComponent(file2);
            mediaDirectory.AddComponent(file3);

            // Выводим иерархию и размеры
            Console.WriteLine("Содержимое файловой системы:");
            rootDirectory.Display();

            Console.WriteLine($"\nОбщий размер: {rootDirectory.GetSize()}KB");

            Console.ReadKey();  
        }
    }

}
