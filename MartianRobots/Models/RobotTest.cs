using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaTecnicaSRV.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPruebaTecnicaSRV
{    
    [TestClass]
    public class RobotTest
    {
        
        [TestMethod]
        public void GoForward_ShouldMoveForwardRobot()
        {
            int x = 2;
            int y = 2;
            char orientation = Orientation.North;
            char instruccion = 'F';
            Point expected = new Point(2, 3);


            Robot robot = new Robot(x, y, orientation);
            robot.Move(instruccion);
            Point actual = new Point(robot.CurrentCoordinates.X, robot.CurrentCoordinates.Y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void GoRigth_ShouldTurnRigthRobot()
        {
            int x = 2;
            int y = 2;
            char orientation = Orientation.North;
            char instruccion = 'R';
            char expected = Orientation.East;

            Robot robot = new Robot(x, y, orientation);
            robot.Move(instruccion);
            char actual = robot._orientation;            

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void GoRigth_ShouldTurnLeftRobot()
        {
            int x = 2;
            int y = 2;
            char orientation = Orientation.North;
            char instruccion = 'L';
            char expected = Orientation.West;

            Robot robot = new Robot(x, y, orientation);
            robot.Move(instruccion);
            char actual = robot._orientation;

            Assert.AreEqual(expected, actual);
        }


    }
}
