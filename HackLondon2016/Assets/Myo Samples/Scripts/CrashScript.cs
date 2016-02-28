using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CrashScript : MonoBehaviour {

	public GameObject player;
	public Text gameOver;

	void Start (){
		gameOver.text = "";
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Bottom" || col.gameObject.name == "Top"){
			// Freeze player position
			var rb = player.GetComponent<Rigidbody> ();
			rb.constraints = RigidbodyConstraints.FreezeAll;
			// Get the final score
			float playerX = player.transform.position.x;
			gameOver.text = ((int)(100 * playerX)).ToString ();
			// Show score for a while
			for (int i = 0; i < 10000; i++){
				// WAITING
			}
			// Reset game
			// SceneManager.LoadScene ("Box On A Stick");
		}
	}
}