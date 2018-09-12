using System;

namespace RobotSpiders.Models
{
    public class RobotSpiderState
    {

        public RobotSpiderState()
        {
            this.CurrentX = this.StartingX;
            this.CurrentY = this.StartingY;
            this.CurrentDirection = this.StartingDirection;
        }

        private long _startingX;
        public long StartingX {
            get {
                return _startingX;
            }
            set
            {
                _startingX = value;
                CurrentX = value;
            }

        }

        private long _startingY;
        public long StartingY
        {
            get
            {
                return _startingY;
            }
            set
            {
                _startingY = value;
                CurrentY = value;
            }

        }

        private Direction _startingDirection;
        public Direction StartingDirection
        {
            get
            {
                return _startingDirection;
            }
            set
            {
                _startingDirection = value;
                CurrentDirection = value;
            }

        }

        public long CurrentX { get; set; }
        public long CurrentY { get; set; }
        public Direction CurrentDirection { get; set; }

        public void ChangeDirection(char cmd)
        {
            int d = 0;

            if (cmd == 'L' || cmd == 'l')
            {
                d = -1;
            }
            else if (cmd == 'R' || cmd == 'r')
            {
                d = 1;
            }

            var dir = ((int)(this.CurrentDirection + (1 * d)) % 4);

            this.CurrentDirection = dir == -1 ? Direction.Left : (Direction)dir;

            Console.WriteLine($"Current Direction: {this.CurrentDirection.ToString()}");
        }

        public bool Move(long limitX, long limitY)
        {
            if(this.CurrentDirection == Direction.Up)
            {
                this.CurrentY++;
                return this.CurrentY < limitY;
            }

            if (this.CurrentDirection == Direction.Down)
            {
                this.CurrentY--;

                return this.CurrentY >= 0;
            }

            if (this.CurrentDirection == Direction.Right)
            {
                this.CurrentX++;

                return this.CurrentX < limitX;
            }

            if (this.CurrentDirection == Direction.Left)
            {
                this.CurrentX--;

                return this.CurrentX >- 0;
            }

            return false;
        }

        public void Reset()
        {
            this.CurrentX = this._startingX;
            this.CurrentY = this._startingY;
            this.CurrentDirection = this._startingDirection;
        }
    }
}
