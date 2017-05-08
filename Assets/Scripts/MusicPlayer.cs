using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
		
	//No defined Instance of MusicPLayer
	static MusicPlayer instance = null;
	
	void Awake() {
		//Debug.Log("Music Player Awake " + GetInstanceID());
		if (instance != null){
			Destroy (gameObject);
			print ("Duplicate Music PLayer Self-Destructed!");
		}	else {
			instance = this; //This first Instance is now the global instance of this Music Player
			GameObject.DontDestroyOnLoad(gameObject);	
		}
	}
	
	
	// Use this for initialization
	void Start () {
		//Debug.Log("Music Player STARTED " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
