using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Capstone.Classes.Tests
{
    [TestClass()]
    public class AdjustBalanceFoodOverLoadTest
    {
        [TestMethod]
        public void AdjustBalanceFoodOverLoadTest_HappyPath()
        {
            //arrange
            LogSheet logSheet = new LogSheet();
            Food item = new Food("here", "craig's crunchy cakes", 0.99M);
            logSheet.AdjustBalance(5M);

            //act
           bool result = logSheet.AdjustBalance(item);

            //assert
            Assert.IsTrue(result);
        }

    }
}
