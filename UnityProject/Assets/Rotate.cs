using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    // Default value is 50
    public Vector3 rotationSpeed;
    public Rigidbody body;

    private Vector3 rotation;

	void Awake ()
    {
        rotation = body.transform.eulerAngles;
	}
	
	void OnTriggerStay ()
    {
        rotation += rotationSpeed * Time.deltaTime;
        body.MoveRotation(Quaternion.Euler(rotation));
	}
}
