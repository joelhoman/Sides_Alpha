using UnityEngine;
using System.Collections;

public class RightPieceWinMenu : MonoBehaviour{
	
	private GameObject pieceRight;
	private GameObject PlayAgain;
	private GameObject MainMenu;

	public void Start() {
		
		pieceRight = GameObject.Find ("pieceRight");
		PlayAgain = GameObject.Find ("PlayAgain");
		MainMenu = GameObject.Find ("MainMenu");

	}

	public void FixedUpdate (){

		if (pieceRight.collider2D.bounds.Intersects (PlayAgain.collider2D.bounds)) {
			Application.LoadLevel("captureFlag");
				
		}

		if (pieceRight.collider2D.bounds.Intersects (MainMenu.collider2D.bounds)){
			Application.LoadLevel ("menuMain");
			
		}
	}
}
