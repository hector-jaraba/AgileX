using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestInstances {


    [Test]
    public void PlayerTest() {

        PlayerController player = GameObject.FindObjectOfType<PlayerController>();

        Assert.NotNull(player);

        Assert.LessOrEqual(player.maxSpeed, 5f);

        Assert.IsFalse(player.screenUI);

        Assert.That(player.tag == "Player");
        

    }

    [Test]
    public void CameraTest() {
        Camera camera = GameObject.FindObjectOfType<Camera>();

        Assert.NotNull(camera);
        Assert.Greater(camera.orthographicSize, 3f);  

    }

    [Test]
    public void CoinTest() {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");

        Assert.Greater(coins.Length, 5);
    }

    [Test]
    public void GemTest()
    {
        GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");

        Assert.AreEqual(gems.Length, 3);
    }

    [Test]
    public void EnemyTest() {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Object");
        Assert.Greater(enemys.Length, 2);
    }

    [Test]
    public void GameOverTest() {
        GameObject gameOver = GameObject.FindWithTag("GameOver");
        Assert.IsNotNull(gameOver);
        
    }
}
