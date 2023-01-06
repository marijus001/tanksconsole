using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.Metrics;
using tanksconsole;

namespace TankTest
{
    [TestClass]
    public class TankConsoleTests
    {
        [TestMethod()]
        public void GameTest()
        {
            Game game = new Game();
            Assert.IsNotNull(game);
        }

        [TestMethod()]
        public void PlayerTankInWall()
        {
            
        }

        [TestMethod()]
        public void TimerIntervalTest()
        {
            
        }
    }
}