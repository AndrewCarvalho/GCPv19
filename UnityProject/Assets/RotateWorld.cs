using UnityEngine;
using System.Collections;

public class RotateWorld : MonoBehaviour {
	
	public Transform centerOfWorld;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			//Vector3 v = new Vector3();
			transform.Rotate(Vector3.forward * 90, Space.Self);
		}
	}
}
