using UnityEngine;
using System.Collections;

public class MovePiece : MonoBehaviour{
		
	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	private static float speed = 0.18f;
	private static float hypotenuseSpeed = Mathf.Sqrt(speed * speed / 2);
	private float zero = 0.0f;
	
	public void FixedUpdate (){
	
		//arrow key movement
		if (Input.GetKey (left) && Input.GetKey (up)) {
			transform.Translate (new Vector2 (-hypotenuseSpeed, hypotenuseSpeed));
		
		} else if (Input.GetKey (left) && Input.GetKey (down)) {
			transform.Translate (new Vector2 (-hypotenuseSpeed, -hypotenuseSpeed));

		} else if (Input.GetKey (right) && Input.GetKey (up)) {
			transform.Translate (new Vector2 (hypotenuseSpeed, hypotenuseSpeed));
		
		} else if (Input.GetKey (right) && Input.GetKey (down)) {
			transform.Translate (new Vector2 (hypotenuseSpeed, -hypotenuseSpeed));

		} else if (Input.GetKey (up)) {
			transform.Translate (new Vector2 (zero, speed));
				
		} else if (Input.GetKey (down)) {
			transform.Translate (new Vector2 (zero, -speed));
				
		} else if (Input.GetKey (left)) {
			transform.Translate (new Vector2 (-speed, zero));
				
		} else if (Input.GetKey (right)) {
			transform.Translate (new Vector2 (speed, zero));
				
		}
	}
}


	

