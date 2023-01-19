using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IndexerTests;

[TestClass]
public class IndexerTests
{
    [TestMethod]
    public void T01_Empty_List()
    {
        StringList list = new();
        Assert.ThrowsException<IndexOutOfRangeException>(() => list[0]);
    }

    [TestMethod]
    public void T02_Some_Insertions()
    {
        StringList list = new();
        list.Add("abc");
        list.Add("Hello World");

        Assert.AreEqual("abc", list[0]);
        Assert.AreEqual("Hello World", list[1]);
        Assert.ThrowsException<IndexOutOfRangeException>(() => list[2]);
    }
}