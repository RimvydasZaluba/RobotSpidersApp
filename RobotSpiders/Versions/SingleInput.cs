﻿using RobotSpiders.Models;
using System;

namespace RobotSpiders.Versions
{
    public static class SingleInput
    {
        public static RobotSpider InputVals()
        {
            long sizeX, sizeY;
            RobotSpiderState rs = new RobotSpiderState();

            Console.WriteLine("Type in the X size of the field");
            sizeX = InputLong();
            Console.WriteLine("Type in the Y size of the field");
            sizeY = InputLong();

            Console.WriteLine($"size: {sizeX} {sizeY}");
            Console.WriteLine();

            Console.WriteLine("Type in the X position value of the spider");
            rs.StartingX = InputLong(sizeX);
            Console.WriteLine("Type in the Y position value of the spider");
            rs.StartingY = InputLong(sizeY);

            Console.WriteLine("Type in the direction spider is facing (Up, Right, Down, Left)");
            rs.StartingDirection = InputDirection();

            Console.WriteLine($"spider: {rs.StartingX} {rs.StartingY} {rs.StartingDirection}");
            //Console.ReadLine();

            return new RobotSpider
            {
                FieldX = sizeX,
                FieldY = sizeY,
                RobotSpiderState = rs
            };

        }

        private static long InputLong(long? limit = null)
        {
            string x = Console.ReadLine();

            if (long.TryParse(x, out long inX) && inX >= 0)
            {
                if (limit.HasValue)
                {
                    if (limit.Value >= inX)
                    {
                        return inX;
                    }
                    else
                    {
                        Console.WriteLine("Bad input: the position value cannot be higher than the size");
                        return InputLong(limit);
                    }
                }
                return inX;
            }
            else
            {
                Console.WriteLine("Bad input: please type in a positive integer");
                return InputLong(limit);
            }
        }

        private static Direction InputDirection()
        {
            string dirIn = Console.ReadLine();
            if (Enum.TryParse(dirIn.Trim(), out Direction dir))
            {
                return dir;
            }
            else
            {
                Console.WriteLine("Bad input: valid values 'Up' 'Right' 'Down' 'Left'");
                return InputDirection();
            }
        }
    }
}
