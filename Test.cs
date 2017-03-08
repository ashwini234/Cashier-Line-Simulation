using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashierLineSimulation;

namespace Grocery.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test_Grocery()
        {
            //Arrange

            string[] path = new string[] { "input1.txt", "input2.txt", "input3.txt", "input4.txt", "input5.txt" };
            int[] actualTime = new int[] { 7, 13, 6, 9, 11 };

            //Act

            for (int i = 0; i < path.Length; i++)
            {
                string[] input = new string[] { path[i] };
                GroceryMain groceryMain = GroceryHelper.initiaize(input);
                RegisterCollection registerCollection = groceryMain.RegisterCollection;
                int expectedTime = GroceryMain.calculateTime(registerCollection, groceryMain);

            //Assert
                Assert.AreEqual(expectedTime, actualTime[i]);
            }
        }
    }
}
