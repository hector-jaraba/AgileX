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

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TestInstancesWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
