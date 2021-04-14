using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CowboyJump.Domain
{
    public enum GameStage
    {
        NotStarted,        
        Playing,
        Finished
    }

    class Game
    {
        GameStage Stage;
        //самая главная сущность, включающая все остальное
        //игрок
        // score board
        // timer

        public Player Player { get; set; }

    }

    class Field
    {
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public List<Point> Points { get; set; }
        public List<Model> Platforms { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        //public List<Point> Shots { get; set; }
        //выстрелы
        //платформы
        //размеры
    }

    //public struct Point
    //{

    //    //x , y
    //}

    class Player
    {
        //поле

    }

    class Enemy
    {

    }

    //отдельно выстрел нам не нужен, потомучто это на самом деле точка

    class Food
    {

    }

    public class Model
    {
        //x, y - необязательны т.к. есть платформы которые уже размещены
        //платформы, которые еще не размещены
        //размер
        public Point position;
        // public Size size;
        public Size size;
        public bool isTouchedByPlayer;

        public Model(Point position)
        {
            size = new Size(60, 12);
            isTouchedByPlayer = false;
        }

    }

    //манипуляция платформами: создание новых, удаление старых
    public class PlatformController
    {
        public List<Model> platforms = new List<Model>();
        public int startPlatformPosY = 400;
        private Random random = new Random();

        public void AddPlatform(Point position)
        {
            var platform = new Model(position);
            platforms.Add(platform);
        }

        public void GenerateStartPlatforms()
        {
            var platformsOnScreenCount = 10;

            for (int i = 0; i < platformsOnScreenCount; i++)
            {
                var x = random.Next(0, 270);
                var y = random.Next(30, 40);

                startPlatformPosY -= y;

                var position = new Point(x, startPlatformPosY);
                var platform = new Model(position);
                platforms.Add(platform);
            }

        }

        public void GenerateRandomPlatform() 
        {
            var x = random.Next(0, 270);
            var position = new Point(x, startPlatformPosY);
        }
    }
}
