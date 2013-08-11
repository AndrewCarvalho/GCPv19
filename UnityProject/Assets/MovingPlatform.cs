using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	
	public float maxY;
	public float minY;
	private float movingTo;
	private float smooth = 1f;
	private float errorMargin = 0.1f;
	
	void Awake ()
	{
		minY += 0.5f;
		movingTo = minY;
		// move a little further down so that you can pick up the player on the way up.
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 position = transform.position;
		position.y = Mathf.Lerp(position.y, movingTo, Time.deltaTime * smooth);
		
		if (position.y + errorMargin >= maxY)
		{
			position.y = maxY;
			movingTo = minY;
			Debug.Log("Moving down");
		}
		
		if (position.y - errorMargin <= minY)
		{
			position.y = minY;
			movingTo = maxY;
			Debug.Log("Moving up");
		}
		
		transform.position = position;
	}
}
