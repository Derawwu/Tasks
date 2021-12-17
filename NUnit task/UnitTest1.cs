using NUnit.Framework;
using System.Collections.Generic;

namespace NUnit_task
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            var myString = "Some shit";
            var myString1 = "Some shit";
            Assert.AreEqual(myString, myString1);
        }
        [Test]
        public void Test2()
        {
            List<string> sarrayOne = new() { "Some shit", "Another one shit", "Same old shit" };
            List<string> sarrayTwo = new() { "Some shit", "Another one shit", "Same old shit" };
            Assert.AreEqual(sarrayOne, sarrayTwo);
        }
        [Test]
        public void Test3()
        {
            List<string> sarrayOne = new() { "Some shit", "Another one shit", "Same old shit" };
            string myString = "Another one shit";
            Assert.Contains(myString, sarrayOne);
        }
        [Test]
        public void Test4()
        {
            int a = 10;
            int b = 5;
            Assert.Greater(a, b);
        }
    }
}