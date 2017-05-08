using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	//public LevelManager levelManager;
	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D trigger){
		levelManager.LoadLevel("Lose");
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		print ("Collision");
	}
	
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
}
