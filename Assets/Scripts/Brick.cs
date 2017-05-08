using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
		
	public static int breakableCount = 0;
	
	public AudioClip crack;
	//the Array for our Sprites
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	private int timesHit; 
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if (isBreakable){
			breakableCount++;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col){
		
		//Audio Played at the location of the brick even after the Brick is gone.
		AudioSource.PlayClipAtPoint (crack, transform.position);
		
		if(isBreakable){
				HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit += 1;
		//SimulateWin();
		int maxHits = hitSprites.Length + 1;
		
		if(timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke,transform.position, Quaternion.identity) as GameObject;
		
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		
		
		//change sprite if one exists
		if (hitSprites[spriteIndex] != null) {
			//grabs from the gameobject instance and changes the .sprite to the hitsprite spritesheet array
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick Sprite Missing");
		}
	}
	
	// TODO Remove this method when we can actually win
	
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
}
