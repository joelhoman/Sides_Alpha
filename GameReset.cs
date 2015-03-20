using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour{
	
	private GameObject rightSide;
	private GameObject leftSide;
	private GameObject wallRight;
	private GameObject wallLeft;

	public void Start() {

		rightSide = GameObject.Find ("rightSide");
		leftSide = GameObject.Find ("leftSide");
		wallRight = GameObject.Find ("wallRight");
		wallLeft = GameObject.Find ("wallLeft");

	}
	public void FixedUpdate() {
		if (leftSide.collider2D.bounds.Intersects (wallRight.collider2D.bounds)) {
			Application.LoadLevel ("leftWins");
		
		}

		if (rightSide.collider2D.bounds.Intersects (wallLeft.collider2D.bounds)) {
			Application.LoadLevel ("rightWins");
		
		}

	}
}



