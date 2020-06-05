using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Zvtika
{
    class Game
    {
        static Walls walls;
        static Snake snake;
        static FoodFactory foodFactory;
        static Timer time;
        static void Main(string[] args)
        {
            int x;
            int y;
            Console.WriteLine("Выберите уровень сложности: 1. Лёгкий 2. Средний 3. Сложный");
            string a = Convert.ToString(Console.ReadLine());
            if (a == "1")
            {
                x = 20;
                y = 10;
            }
            else
                if (a == "2")
            {
                x = 30;
                y = 15;
            }
            else if (a == "3")
            {
                x = 40;
                y = 20;
            }
            else
            {
                x = 80;
                y = 26;
            }
            Console.SetWindowSize(x + 1, y + 1);
            Console.SetBufferSize(x + 1, y + 1);
            Console.CursorVisible = false;
            walls = new Walls(x, y, '#');
            snake = new Snake(x / 2, y / 2, 3);
            foodFactory = new FoodFactory(x, y, '0');
            foodFactory.CreateFood();
            if(a=="1")
            {
                time = new Timer(Loop, null, 0, 500);
            }else
                if(a=="2")
            {
                time = new Timer(Loop, null, 0, 300);
            }else
                if(a=="3")
            {
                time = new Timer(Loop, null, 0, 100);
            }
            else
            {
                time = new Timer(Loop, null, 0, 200);
            }
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }
        static void Loop(object obj)
        {
            if (walls.IsHit(snake.GetHead()) || snake.IsHit(snake.GetHead()))
            {
                time.Change(0, Timeout.Infinite);
            }
            else if (snake.Eat(foodFactory.food))
            {
                foodFactory.CreateFood();
            }
            else
            {
                snake.Move();
            }
        }
    }
}
