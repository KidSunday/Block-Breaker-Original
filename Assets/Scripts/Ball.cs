using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	
	private Vector3 paddleToBallVector;
	private bool hasStarted = false;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!hasStarted)
		{
			//Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for a mouse click to launch ball
			if(Input.GetMouseButtonDown(0))
			{
			print ("Mouse Button Clicked, Launch Ball");
			hasStarted = true;
			this.rigidbody2D.velocity = new Vector2(2f,10f);
			}
			
		}
	}
	void FixedUpdate(){

		}
	
	void OnCollisionEnter2D(Collision2D col){
		
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f),Random.Range(0f,0.2f));
		
		if(hasStarted)
		{
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
}
