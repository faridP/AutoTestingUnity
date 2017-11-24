using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System;

public class NewPlayModeTest {

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator StopsBouncing() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        SetupScene();
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            if (GameObject.Find("Ball(Clone)").GetComponent<Rigidbody>().velocity.sqrMagnitude < 0.0001)
            {
                yield break;
            }
        }
        Assert.Fail();
	}

    private void SetupScene()
    {
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Scenery"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Ball"));
    }
}
