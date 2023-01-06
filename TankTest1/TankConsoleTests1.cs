using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using tanksconsole;

//make sure targeted framework is the same (4.8) and targeted runtime is the same (x64 or x86)

namespace TankTest1
{
    [TestClass]
    public class TankConsoleTests1
    {
        [TestMethod()]
        public void GameTest() //tests if game is initialized
        {
            Game game = new Game();
            Assert.IsNotNull(game);
        }

        [TestMethod()]
        public void ConsoleHandleTest()
        {
            if (!Console.IsOutputRedirected) Console.Clear(); //because for some reason if Game initialized you get System.IO.IOException: The handle is invalid. 
        }
        
        [TestMethod()]
        public void TestReadFile() //tests if file exists
        {
            Game game = new Game();
            Assert.IsNotNull(game.lines);
        }
        
        [TestMethod()]
        public void TestFileLength()
        {
            Game game = new Game();
            Assert.AreEqual(game.lines.Length, 26); //tests if file is 26 lines long
        }
    }
}