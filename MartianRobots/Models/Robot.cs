using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaSRV.Models
{
    public class Robot 
    {        
        public Robot(int x, int y, char orientation)
        {
            CurrentCoordinates = new Point(x,y);            
            _orientation = orientation;
        }
        public  Point CurrentCoordinates { get;  set; }
        public char _orientation;
        public bool IsLost { get; set; } = false;
        public void Move(char instruction)
        {
            switch (instruction)
            {
                case GoTo.Foward:
                    GoFoward();
                    break;

                case GoTo.Right:
                    GoRight();
                    break;

                case GoTo.Left:
                    GoLeft();
                    break;
            }
        }   
        private void GoFoward()
        {
            switch (_orientation)
            {
                case Orientation.North: CurrentCoordinates = new Point(CurrentCoordinates.X, CurrentCoordinates.Y + 1);break;
                case Orientation.South: CurrentCoordinates = new Point(CurrentCoordinates.X, CurrentCoordinates.Y - 1); break;
                case Orientation.West: CurrentCoordinates = new Point(CurrentCoordinates.X - 1, CurrentCoordinates.Y); break;
                case Orientation.East: CurrentCoordinates = new Point(CurrentCoordinates.X + 1, CurrentCoordinates.Y); break;
                    default:break;
            }
        }
        private void GoRight()
        {
            switch (_orientation)
            {
                case Orientation.North: _orientation = Orientation.East; break;
                case Orientation.South: _orientation = Orientation.West; break;
                case Orientation.West: _orientation = Orientation.North; break;
                case Orientation.East: _orientation = Orientation.South; break;
                default: break;
            } 
        }
        private void GoLeft()
        {
            switch (_orientation)
            {
                case Orientation.North: _orientation = Orientation.West;break;
                case Orientation.West: _orientation = Orientation.South; break;
                case Orientation.South: _orientation = Orientation.East; break;
                case Orientation.East: _orientation = Orientation.North; break;
                default: break;
            }
        }        
    }
    public class Orientation
    {
        public const char West = 'W';
        public const char East = 'E';
        public const char North = 'N';
        public const char South = 'S';
    }
    public class GoTo
    {
        public const char Foward = 'F';
        public const char Left = 'L';
        public const char Right = 'R';
    }
}
