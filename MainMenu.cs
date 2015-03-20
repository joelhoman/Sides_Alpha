using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour{
	
	private GameObject pieceRight;
	private GameObject pieceLeft;
	private GameObject Play;
	
	public void Start() {
		
		pieceRight = GameObject.Find ("pieceRight");
		pieceLeft = GameObject.Find ("pieceLeft");
		Play = GameObject.Find ("Play");
		
	}
	
	public void FixedUpdate (){
		
		if (pieceLeft.collider2D.bounds.Intersects (Play.collider2D.bounds) && pieceRight.collider2D.bounds.Intersects (Play.collider2D.bounds)) {
			Application.LoadLevel ("captureFlag");
			
		}
	}
}
