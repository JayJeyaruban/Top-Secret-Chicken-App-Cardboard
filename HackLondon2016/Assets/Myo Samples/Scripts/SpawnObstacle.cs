using UnityEngine;
using System.Collections;

public class SpawnObstacle : MonoBehaviour {

	public GameObject obstacle;
	public float gateGap;
	public float gateStart;
	float x = 0;

	void Update () {
		float y = Random.Range (1.4f, 6f);
		if (x < 100) {
			Instantiate (obstacle, new Vector3 (gateStart + x * gateGap, y, 0), Quaternion.identity);
			x++;
		}
		Debug.Log (x);
	}
}