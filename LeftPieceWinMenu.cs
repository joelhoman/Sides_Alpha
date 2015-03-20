using UnityEngine;
using System.Collections;

public class LeftPieceWinMenu : MonoBehaviour{

	private GameObject pieceLeft;
	private GameObject PlayAgain;
	private GameObject MainMenu;
	
	public void Start() {
		
		pieceLeft = GameObject.Find ("pieceLeft");
		PlayAgain = GameObject.Find ("PlayAgain");
		MainMenu = GameObject.Find ("MainMenu");

		
	}
	
	public void FixedUpdate (){

		if (pieceLeft.collider2D.bounds.Intersects (PlayAgain.collider2D.bounds)) {
			Application.LoadLevel("captureFlag");

		}

		if (pieceLeft.collider2D.bounds.Intersects (MainMenu.collider2D.bounds)){
			Application.LoadLevel ("menuMain");
			
		}
	}
}

