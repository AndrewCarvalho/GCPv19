using UnityEngine;
using System.Collections;

public class RotatingQuad : MonoBehaviour {

    private Rigidbody body;
    private float rotation;

	// Use this for initialization
	void Start () {

        this.body = this.GetComponent<Rigidbody>();

        //this.body.angularVelocity = new Vector3(0, 0, 10);
	}
	
	// Update is called once per frame
	void Update () {
        this.rotation += 50 * Time.deltaTime;
        body.MoveRotation(Quaternion.Euler(new Vector3(0, rotation, 0)));
	}
}
