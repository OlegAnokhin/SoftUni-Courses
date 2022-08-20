namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void RodotConstructorShouldWorkCorrect()
        {
            Robot robot = new Robot("Robo", 100);
            Assert.AreEqual("Robo", robot.Name);
            Assert.AreEqual(100, robot.MaximumBattery);
            Assert.AreEqual(100, robot.Battery);
        }
        [Test]
        public void RodotManegerConstructorShouldWorkCorrect()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("Robo1", 100);
            Robot robot2 = new Robot("Robo2", 100);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            Assert.AreEqual(2, robotManager.Count);
        }
        [Test]
        public void ConstructorShouldThrowsExceptionIfCapacityIsNеgative()
        {
            Assert.Throws<ArgumentException>(() =>
                {
                    new RobotManager(-1);
                });
        }
        [Test]
        public void RodotManegerCapacityShouldWorkCorrect()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.AreEqual(10, robotManager.Capacity);
        }
        [TestCase(-1)]
        [TestCase(-9999999)]
        public void CapacytyShouldThrowExceptionWhenIncorectValue(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            }, "Invalid capacity!");
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenIncorectValue()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot1 = new Robot("Robo1", 100);
            Robot robot2 = new Robot("Robo2", 100);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot2);
            }, "Not enough capacity!");
        }
        [Test]
        public void AddMethodShouldThrowExceptionWhenExistValue()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot1 = new Robot("Robo1", 100);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot1);
            }, "There is already a robot with name Robo1!");
        }
        [Test]
        public void RemoveMethodShouldRemovePhysicaly()
        {
            RobotManager robotManager = new RobotManager(10);
            Robot robot1 = new Robot("Robo1", 100);
            Robot robot2 = new Robot("Robo2", 100);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Remove("Robo1");
            Assert.AreEqual(1, robotManager.Count);
        }
        [Test]
        public void RemoveMethodShoultThrowExceptionWhenNameNonExist()
        {
            RobotManager robotManager = new RobotManager(10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove("Robo1");
            }, "Robot with the name Robo1 doesn't exist!");
        }
        [Test]
        public void WorkMethodShoulDecrieseBattery()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot1 = new Robot("Robo1", 100);
            robotManager.Add(robot1);
            robotManager.Work("Robo1", "Diging", 30);
            Assert.AreEqual(70, robot1.Battery);
        }
        [Test]
        public void WorkMethodShoulThrowExceptionWithNonExistRobot()
        {
            RobotManager robotManager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robo1", "Diging", 30);
            }, "Robot with the name Robo1 doesn't exist!");
        }
        [Test]
        public void WorkMethodShoulThrowExceptionWithLowBattery()
        {
            RobotManager robotManager = new RobotManager(1);
            Robot robot1 = new Robot("Robo1", 10);
            robotManager.Add(robot1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("Robo1", "Diging", 30);
            }, "Robo1 doesn't have enough battery!");
        }
        [Test]
        public void ChargeMethodShoulIncrieseBattery()
        {
            RobotManager robotManager = new RobotManager(5);
            Robot robot1 = new Robot("Robo1", 100);
            Robot robot2 = new Robot("Robo2", 50);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
            robotManager.Work("Robo1", "Diging", 30);
            robotManager.Charge("Robo1");
            robotManager.Charge("Robo2");
            Assert.AreEqual(100, robot1.Battery);
            Assert.AreEqual(50, robot2.Battery);
        }
        [Test]
        public void ChargeMethodShouldReturnMaximumBattery()
        {
            RobotManager robotManager = new RobotManager(2);
            Robot robot1 = new Robot("Robo1", 100);
            robotManager.Add(robot1);
            robotManager.Work("Robo1", "Diging", 75);
            robotManager.Charge("Robo1");
            Assert.AreEqual(100, robot1.MaximumBattery);
        }
        [Test]
        public void ChargeMethodShoulThrowExceptionWithNonExistRobot()
        {
            RobotManager robotManager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("Robo1");
            }, "Robot with the name Robo1 doesn't exist!");
        }
    }
}