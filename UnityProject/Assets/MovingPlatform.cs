using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	
	public Transform end;
	private Vector3 start;
	private Vector3 movingTo;
	private float virtualZero = 0.1f;
	public float stopTime;
	private float stopCount = 0f;
	
	void Awake ()
	{
		start = transform.position;
		movingTo = end.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (stopCount <= 0)
		{
			transform.position = Vector3.Lerp(transform.position, movingTo, Time.deltaTime); 
			
			float mag = (transform.position - movingTo).sqrMagnitude;
			if (mag <= virtualZero)
			{
				stopCount = stopTime;
				if (movingTo == end.position)
				{
					movingTo = start;
				}
				else if (movingTo == start)
				{
					movingTo = end.position;
				}
			}
		}
		else
		{
			stopCount -= Time.deltaTime;
		}
	}
}
