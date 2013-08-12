using UnityEngine;
using System.Collections;

public class PlayerPusher : MonoBehaviour {

    [SerializeField]
    private float pushPower = 1;

    private Rigidbody myBody;

	// Use this for initialization
	void Start () {
        this.myBody = this.GetComponent<Rigidbody>();
        Screen.showCursor = false; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null) 
            return;

        Vector3 pushDir;

        if (body.isKinematic)
        {
            if (body.GetComponent<RotatingQuad>() != null)
            {
                Debug.Log("heyheyhey");

                pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                this.myBody.velocity = pushDir * -pushPower;

                return;
            }
            else
            {
                return;
            }
        }

        if (hit.moveDirection.y < -0.3F)
            return;

        pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
    }
}
