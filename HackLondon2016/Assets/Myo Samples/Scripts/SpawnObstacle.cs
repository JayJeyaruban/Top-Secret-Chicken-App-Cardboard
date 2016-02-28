using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnObstacle : MonoBehaviour {
	
	public float gateGap;
	public float gateStart;
	public GameObject obstacle;
	public GameObject player;
	public GameObject ground;

	void Start () {

		for (int i = 0; i < 10; i++) {
			float y = Random.Range (1.4f, 6f);
			Instantiate (obstacle, new Vector3 (gateStart + i * gateGap, y, 0), Quaternion.identity);
		}

		for (int i = 0; i < 100; i++) {
			Instantiate (ground, new Vector3 (i * 10, -4, 0), Quaternion.identity);
		}
	}
		

	void Update () {
		GameObject[] obstacles = GameObject.FindGameObjectsWithTag ("Gates");

		float playerX = player.transform.position.x;

		for (int i = 0; i < obstacles.Length; i++) {
			if (obstacles [i].transform.position.x < playerX) {
				Destroy (obstacles [i]);
				float y = Random.Range (1.4f, 6f);
				Instantiate (obstacle, new Vector3 (10 * gateGap + playerX, y, 0), Quaternion.identity);
			}
		}
	}
}