using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class LinqTests {

    [Test]
    public void TestSelect()
    {
        var list = new List<int>{0,1,2};
        Assert.AreEqual(0,list[0]);
        Assert.AreEqual(1,list[1]);
        Assert.AreEqual(2,list[2]);
        
        var enumerable = list.Select(x => x + 5);
        var array = enumerable.ToArray();
        
        Assert.AreEqual(5,array[0]);
        Assert.AreEqual(6,array[1]);
        Assert.AreEqual(7,array[2]);
    } 
}
