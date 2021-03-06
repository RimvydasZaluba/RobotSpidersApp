﻿using RobotSpiders.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotSpiders.Versions
{
    public class MultiInput
    {

        public RobotSpider InputVals()
        {
            long[] field = new long[2];
            RobotSpiderState rs = new RobotSpiderState();

            Console.WriteLine("Type in size of the field in 'X Y' format");
            string x = Console.ReadLine();

            var tmpX = x.Split(' ');

            if (tmpX.Length == 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (long.TryParse(tmpX[i], out long lngOu) && lngOu > 0)
                    {
                        field[i] = lngOu;
                    }
                    else
                    {
                        //input error
                    }
                }
            }
            else
            {
                //input error
            }

            Console.WriteLine("Type in size of the field in 'X Y Direction' format (where Direction is 'Up' 'Right' 'Down' 'Left')");
            x = Console.ReadLine();

            var tmpY = x.Split(' ');

            if (tmpY.Length == 3)
            {

                if (long.TryParse(tmpY[0], out long lngOu1) && lngOu1 > 0)
                {
                    rs.StartingX = lngOu1;
                }
                else
                {
                    //input error
                }

                if (long.TryParse(tmpY[1], out long lngOu2) && lngOu2 > 0)
                {
                    rs.StartingY = lngOu2;
                }
                else
                {
                    //input error
                }

            }

            if (Enum.TryParse(tmpY[2].Trim(), out Direction dir))
            {
                rs.StartingDirection = dir;
            }
            else
            {
                //input error
            }

            Console.WriteLine();
            Console.WriteLine($"size: {field[0]} {field[1]}");
            Console.WriteLine();
            Console.WriteLine($"spider: {rs.StartingX} {rs.StartingY} {rs.StartingDirection}");
            Console.ReadLine();

            return new RobotSpider
            {
                FieldX = field[0],
                FieldY = field[1],
                RobotSpiderState = rs
            };

        }
    }
}
