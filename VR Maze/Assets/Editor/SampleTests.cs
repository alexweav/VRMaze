using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class SampleTests {

    /// <summary>
    /// A sample test that should always pass.
    /// This is used to verify that external build scripts are running tests properly.
    /// </summary>
	[Test]
	public void SampleTest() {
        int x = 5;
        int y = 5;
		Assert.AreEqual(x, y);
	}
}
