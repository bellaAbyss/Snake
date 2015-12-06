using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(90, 30);
            Console.SetWindowSize(90, 30);  

            //Отрисовка рамки
            Walls walls = new Walls(90, 30);
            walls.Draw();            

            //Отрисовка змейки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            //Еда
            FoodGenerator foodGenerator = new FoodGenerator(90, 30, '$');
            Point food = foodGenerator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                
                if (snake.Eat(food))
                {
                    food.Draw();
                    food = foodGenerator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);

                //Отлавливаем нажатие кнопки
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
