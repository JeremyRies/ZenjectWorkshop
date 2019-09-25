using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class LinqTests
{
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
    
    
    [Test]
    public void TestFirst()
    {
        var list = new List<int>{0,1,2,2};
        var numberOne = list.First(x => x == 2);
        
        Assert.AreEqual(2,numberOne);
    }
    
    [Test]
    public void TestFirstOrDefault()
    {
        var list = new List<int>{0,1,2};
        var intDefault = list.FirstOrDefault(x => x == 3);
        
        Assert.AreEqual(0, intDefault);
    }
    
    [Test]
    public void TestWhere_TakeOne()
    {
        var list = new List<int>{0,1,2,3};

        var numbersBiggerZero = list.Where(x => x > 0).ToArray();
        Assert.AreEqual(3, numbersBiggerZero.Length);
        
        var firstTwoNumbers = numbersBiggerZero.Take(2).ToArray();
        Assert.AreEqual(2, firstTwoNumbers.Length);
    }

    [Test]
    public void TestSingle()
    {
        var list = new List<int>{0,1,2,2};
        
        try
        {
            var numberOne = list.Single(x => x == 2);
            Assert.Fail();
        }
        catch (Exception e)
        {
            // ignored
        }
    }


    [Test]
    public void TestSum()
    {
        var list = new List<int> {0, 1, 2, 2};
        var sum = list.Where(x => x > 1).Sum();
        
        Assert.AreEqual(5,sum);
    }
    
    
    [Test]
    public void TestAny()
    {
        var list = new List<int> {0, 1, 2, 2};
        var hasAny = list.Any(x => x == 1);
        
        Assert.AreEqual(true, hasAny);
    }

    [Test]
    public void TestOrder()
    {
        var list = new List<int> {0, 1, 2, 2};
        var hasAny = list.OrderByDescending(x => x);
        
        Assert.AreEqual(true, hasAny);
    }
    
    
    [Test]
    public void TestUnion()
    {
        var list = new List<int> {0, 1, 2, 2};
        var list2 = new List<int> {5, 6, 7};

        var union = list.Union(list2).ToArray();
        
     
        Assert.AreEqual(7, union.Length);
    }

    [Serializable]
    private class MineName
    {
        public MineResource MineResource;
        public string GermanName;
    }
    
    private enum MineResource
    {
        Coal,
        Emerald
    }
    
    [Test]
    public void TestMineNames()
    {
        var list = new List<MineName>
        {
            new MineName
            {
                MineResource = MineResource.Coal,
                GermanName = "Kohle"
            },
            new MineName
            {
                MineResource = MineResource.Emerald,
                GermanName = "Smaragd"
            }
        };

        var mineName = list.First(x => x.MineResource == MineResource.Emerald).GermanName;
        
        Assert.AreEqual("Smaragd", mineName);
    }
}
