using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Module_10_2_Chapter_
{
    using System;

    // Подсистема: Телевизор
    public class TV
    {
        public void On() => Console.WriteLine("Телевизор включен.");
        public void Off() => Console.WriteLine("Телевизор выключен.");
        public void SetChannel(int channel) => Console.WriteLine($"Канал установлен на {channel}.");
        public void SetAudioInput() => Console.WriteLine("Аудиовход для телевизора установлен.");
    }

    // Подсистема: Аудиосистема
    public class AudioSystem
    {
        private int _volume = 10;
        public void On() => Console.WriteLine("Аудиосистема включена.");
        public void Off() => Console.WriteLine("Аудиосистема выключена.");
        public void SetVolume(int level)
        {
            _volume = level;
            Console.WriteLine($"Громкость установлена на уровень {level}.");
        }
        public int GetVolume() => _volume;
    }

    // Подсистема: DVD-проигрыватель
    public class DVDPlayer
    {
        public void Play() => Console.WriteLine("DVD проигрывается.");
        public void Pause() => Console.WriteLine("DVD на паузе.");
        public void Stop() => Console.WriteLine("DVD остановлен.");
    }

    // Подсистема: Игровая консоль
    public class GameConsole
    {
        public void On() => Console.WriteLine("Игровая консоль включена.");
        public void StartGame() => Console.WriteLine("Игра запущена.");
    }

    // Класс фасада: HomeTheaterFacade
    public class HomeTheaterFacade
    {
        private readonly TV _tv;
        private readonly AudioSystem _audio;
        private readonly DVDPlayer _dvd;
        private readonly GameConsole _console;

        public HomeTheaterFacade(TV tv, AudioSystem audio, DVDPlayer dvd, GameConsole console)
        {
            _tv = tv;
            _audio = audio;
            _dvd = dvd;
            _console = console;
        }

        // Метод для включения системы для просмотра фильма
        public void WatchMovie()
        {
            Console.WriteLine("Подготовка к просмотру фильма...");
            _tv.On();
            _audio.On();
            _audio.SetVolume(20);
            _dvd.Play();
        }

        // Метод для выключения системы
        public void EndMovie()
        {
            Console.WriteLine("Выключение системы...");
            _dvd.Stop();
            _audio.Off();
            _tv.Off();
        }

        // Метод для запуска игровой консоли
        public void StartGaming()
        {
            Console.WriteLine("Подготовка к игре...");
            _tv.On();
            _console.On();
            _console.StartGame();
        }

        // Метод для включения системы для прослушивания музыки
        public void ListenToMusic()
        {
            Console.WriteLine("Подготовка к прослушиванию музыки...");
            _tv.On();
            _tv.SetAudioInput();
            _audio.On();
            _audio.SetVolume(15);
        }

        // Метод для регулировки громкости
        public void SetVolume(int level)
        {
            _audio.SetVolume(level);
        }
    }

    // Тестирование системы
    public class Program
    {
        public static void Main()
        {
            TV tv = new TV();
            AudioSystem audio = new AudioSystem();
            DVDPlayer dvd = new DVDPlayer();
            GameConsole console = new GameConsole();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, dvd, console);

            // Запуск сценария "Просмотр фильма"
            homeTheater.WatchMovie();
            Console.WriteLine();

            // Завершение просмотра фильма
            homeTheater.EndMovie();
            Console.WriteLine();

            // Запуск сценария "Игровая консоль"
            homeTheater.StartGaming();
            Console.WriteLine();

            // Запуск сценария "Прослушивание музыки"
            homeTheater.ListenToMusic();
            Console.WriteLine();

            // Регулировка громкости
            homeTheater.SetVolume(25);

            Console.ReadKey ();
        }
    }

}
