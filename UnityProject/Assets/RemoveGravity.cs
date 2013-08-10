using UnityEngine;
using System.Collections;

public class SwitchGravity : MonoBehaviour {
	
	public string gravityButton;
	public const float NO_GRAVITY = 0f;
	public const float NORMAL_GRAVITY = 10f;
	private CharacterMotor charMove;
	private bool isGravityOn;
	
	
	// Use this for initialization
	void Awake () {
		charMove = gameObject.GetComponent<CharacterMotor>();
		isGravityOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(gravityButton))
		{
			if (isGravityOn)
			{
				charMove.movement.gravity = NO_GRAVITY;
			}
			else
			{
				charMove.movement.gravity = NORMAL_GRAVITY;
			}
		}
	}
}
