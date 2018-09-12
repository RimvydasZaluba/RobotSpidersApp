using RobotSpiders.Versions;
using System;
using System.Text;

namespace RobotSpiders
{
    class Program
    {

        static void Main(string[] args)
        {

            var robotSpider = SingleInput.InputVals();

            StringBuilder cmdRecord = new StringBuilder(string.Empty);

            while (true)
            {
                Console.WriteLine("Type in command or a list of commands using L R F (X to exit)");
                string cmds = Console.ReadLine();

                if (cmds.Contains("X", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                foreach (var cmd in cmds)
                {
                    cmdRecord.Append(cmd);

                    if (cmd == 'F' || cmd == 'f')
                    {
                        var res = robotSpider.RobotSpiderState.Move(robotSpider.FieldX,robotSpider.FieldY);

                        Console.WriteLine($"Current position: {robotSpider.RobotSpiderState.CurrentX},{robotSpider.RobotSpiderState.CurrentY} {robotSpider.RobotSpiderState.CurrentDirection.ToString()}");

                        if (!res)
                        {
                            Console.WriteLine($"BEEP BOOP: hit the wall at command {cmdRecord.ToString()}. Spider reset. Try another set of commands.");
                            robotSpider.RobotSpiderState.Reset();
                            cmdRecord = new StringBuilder(string.Empty);
                            Console.WriteLine($"Current position: {robotSpider.RobotSpiderState.CurrentX},{robotSpider.RobotSpiderState.CurrentY} {robotSpider.RobotSpiderState.CurrentDirection.ToString()}");
                            break;
                        }
                    }
                    else
                    {
                        robotSpider.RobotSpiderState.ChangeDirection(cmd);
                    }
                }

            }

            Console.WriteLine("Terminating...");
            Console.ReadLine();
        }


    }
}
