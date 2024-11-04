using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Module_10
{
  public class TV
    {
        public void On() => Console.WriteLine("Телевизор включен");
        public void Off() => Console.WriteLine("Телевизор отключен");

        public void SetChannel(int channel) => Console.WriteLine($"Канал установлен на {channel}");

    }

    public class AudiSystem
    {
        public void On() => Console.WriteLine("Аудиосистема включен");
        public void Off() => Console.WriteLine("Аудиосистема отключен");

        public void SetVolume(int level) => Console.WriteLine($"Громкость установлена на уровень {level}.");
    }

    public class DVDPlayer
    {
        public void Play() => Console.WriteLine("DVD Проигрывается");
        public void Pause() => Console.WriteLine("DVD на паузе");
        public void Stop() => Console.WriteLine("DVD остановлен");
    }

    public class GameConsole
    {
        public void On() => Console.WriteLine("Игровая консоль включена.");
        public void StartGame() => Console.WriteLine("Игра запущена ");
    }

    public class HomeTheaterFacade
    {
        
            private readonly TV tv;
            private readonly AudiSystem audio;
            private readonly DVDPlayer dvd;
            private readonly GameConsole console;

            public HomeTheaterFacade(TV tv, AudiSystem audio, DVDPlayer dvd, GameConsole console)
            {
                this.tv = tv;
                this.audio = audio;
                this.dvd = dvd;
                this.console = console;
            }

            public void WatchMove()
            {
                Console.WriteLine("Подготовка к фильму");
                tv.On();
                audio.On();
                audio.SetVolume(30);
                dvd.Play();
            }
            
            public void EndMove()
            {
                Console.WriteLine("Отключение системы");

                dvd.Stop();
                audio.Off();
                tv.Off();
            }

            public void StartGaning()
            {
                Console.WriteLine("Подготовка к игре ");
                tv.On();
                console.On();
                console.StartGame();
            }
        
        public class Program
        {
            public static void Main()
            {
                TV tv = new TV();
                AudiSystem audio = new AudiSystem();
                DVDPlayer dvd = new DVDPlayer();
                GameConsole console = new GameConsole();

                HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audio, dvd, console);

                // Запуск сценария "Просмотр фильма"
                homeTheater.WatchMove();
                Console.WriteLine();

                // Завершение просмотра фильма
                homeTheater.EndMove();
                Console.WriteLine();

                // Запуск сценария "Игровая консоль"
                homeTheater.StartGaning();

                Console.ReadKey();
            }
        }

    }
}
