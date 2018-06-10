using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class AttackTest  {
    [Test]
    public void PlayerDamageTest() {
        BarManager barManager = GameObject.FindObjectOfType<BarManager>();
        Assert.That(barManager.getDamage() == 100f);
        barManager.doDamage(10);
        Assert.That(barManager.getDamage() >= 100f);
    }
    
}
