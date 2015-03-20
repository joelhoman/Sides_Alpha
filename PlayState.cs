using UnityEngine;
using System.Collections;

public class PlayState : MonoBehaviour{

	public bool leftOnSide;
	public bool rightOnSide;
	private GameObject pieceLeft;
	private GameObject rightSide;
	private GameObject leftSide;
	private GameObject pieceRight;
	private GameObject wallLeft;
	private GameObject wallRight;
	private GameObject wallDividing;
	private float leftOnOppSideReward = 0.0f;
	private float rightOnOppSideReward = 0.0f;
	private float restart = 11.0f;
	public float leftHitWallReward = 0.5f;
	public float rightHitWallReward = 0.5f;
	public float hitWallScaler = 0.5f;
	public float hitPieceReward = 12.5f;
	public int rightWinning = 0;
	private float neutralizer = 0.05f;
	//public GameObject resetGame;

	public void Start() {
		
		pieceLeft = GameObject.Find ("pieceLeft");
		rightSide = GameObject.Find ("rightSide");
		leftSide = GameObject.Find ("leftSide");
		pieceRight = GameObject.Find ("pieceRight");
		wallLeft = GameObject.Find ("wallLeft");
		wallRight = GameObject.Find ("wallRight");
		wallDividing = GameObject.Find ("wallDividing");
		//resetGame = GameObject.Find ("resetGame");
		
	}

	public void FixedUpdate (){

		//collision detection with left piece and right side
		if (leftSide.collider2D.bounds.Intersects (pieceLeft.collider2D.bounds)) {
			this.leftOnSide = true;
				
		}
			
		if (rightSide.collider2D.bounds.Intersects (pieceLeft.collider2D.bounds)) {
			this.leftOnSide = false;
				
		}
		
		//collision detection with right piece and left side
		if (rightSide.collider2D.bounds.Intersects (pieceRight.collider2D.bounds)) {
			this.rightOnSide = true;
				
		}
			
		if (leftSide.collider2D.bounds.Intersects (pieceRight.collider2D.bounds)) {
			this.rightOnSide = false;
				
		}

		Vector2 dividePosition = wallDividing.transform.position;

		if (dividePosition.x > -0.05f && dividePosition.x < 0.05f) {
			rightWinning = 0;
		
		} else if (dividePosition.x > 0.0f) {
			rightWinning = -1;
		
		} else if (dividePosition.x < 0.0f) {
			rightWinning = 1;
		
		}

		if (this.leftOnSide == true) {
			leftOnOppSideReward = 0.0f;
			
		}

		if (this.rightOnSide == true) {
			rightOnOppSideReward = 0.0f;
			
		}

		//moves leftSide
		if (this.leftOnSide == false && this.rightOnSide == false) {
			leftOnOppSideReward = 0.0f;
			rightOnOppSideReward = 0.0f;
			
		}

		if (this.rightOnSide == false && this.leftOnSide == false && rightWinning == 0) {
			rightSide.transform.Translate (new Vector2 (0.0f, 0.0f));
			leftSide.transform.Translate (new Vector2 (0.0f, 0.0f));
			wallDividing.transform.Translate (new Vector2 (0.0f, 0.0f));
			
		}
		
		else if (this.rightOnSide == false && this.leftOnSide == false && rightWinning == 1) {
			rightSide.transform.Translate (new Vector2 (neutralizer, 0.0f));
			leftSide.transform.Translate (new Vector2 (neutralizer, 0.0f));
			wallDividing.transform.Translate (new Vector2 (neutralizer, 0.0f));
			
		}
		
		else if (this.rightOnSide == false && this.leftOnSide == false && rightWinning == -1) {
			rightSide.transform.Translate (new Vector2 (-neutralizer, 0.0f));
			leftSide.transform.Translate (new Vector2 (-neutralizer, 0.0f));
			wallDividing.transform.Translate (new Vector2 (-neutralizer, 0.0f));
			
		}

		else if (this.leftOnSide == false && this.rightOnSide == true) {
			rightSide.transform.Translate( new Vector2 (leftOnOppSideReward, 0.0f));
			leftSide.transform.Translate( new Vector2 (leftOnOppSideReward, 0.0f));
			wallDividing.transform.Translate( new Vector2 (leftOnOppSideReward, 0.0f));
			leftOnOppSideReward += 0.00333334f;

		}

		//moves rightSide 
		else if (this.rightOnSide == false && this.leftOnSide == true) {
			rightSide.transform.Translate( new Vector2 (-rightOnOppSideReward, 0.0f));
			leftSide.transform.Translate( new Vector2 (-rightOnOppSideReward, 0.0f));
			wallDividing.transform.Translate( new Vector2 (-rightOnOppSideReward, 0.0f));
			rightOnOppSideReward += 0.00333334f;

		}

		//collision detection of left piece with right piece- moves left piece to beginning
		if (this.leftOnSide == false && pieceLeft.collider2D.bounds.Intersects (pieceRight.collider2D.bounds)) {					
			Application.LoadLevel ("rightWins");
				
		}

		//collision detection of right piece with left piece- moves right piece to beginning
		else if (this.rightOnSide == false && pieceRight.collider2D.bounds.Intersects (pieceLeft.collider2D.bounds)) {					 
			Application.LoadLevel( "leftWins");
				
		}

		//collision detection of left piece with right side
		if (pieceLeft.collider2D.bounds.Intersects (wallRight.collider2D.bounds)) {
			pieceLeft.transform.position = new Vector2 (-restart, 0f);
			rightSide.transform.Translate( new Vector2 (rightHitWallReward, 0.0f));
			leftSide.transform.Translate( new Vector2 (rightHitWallReward, 0.0f));
			wallDividing.transform.Translate( new Vector2 (rightHitWallReward, 0.0f));
			rightHitWallReward *= hitWallScaler;

		}

		//collision detection of right piece with left side
		if (pieceRight.collider2D.bounds.Intersects (wallLeft.collider2D.bounds)) {
			pieceRight.transform.position = new Vector2 (restart, 0f);
			rightSide.transform.Translate( new Vector2 (-leftHitWallReward, 0.0f));
			leftSide.transform.Translate( new Vector2 (-leftHitWallReward, 0.0f));
			wallDividing.transform.Translate( new Vector2 (-leftHitWallReward, 0.0f));
			leftHitWallReward *= hitWallScaler;
			
		}

		if (leftSide.collider2D.bounds.Intersects (wallRight.collider2D.bounds)) {
			Application.LoadLevel ("leftWins");
			//Instantiate( resetGame, new Vector2 (-6.0f, 0.0f), Quaternion.identity);
			
		}
		
		if (rightSide.collider2D.bounds.Intersects (wallLeft.collider2D.bounds)) {
			Application.LoadLevel ("rightWins");
			
		}
	}
}

