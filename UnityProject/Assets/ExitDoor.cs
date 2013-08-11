using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    [SerializeField]
    private string nextSceneName;

    //private TransitionBlinds blinds;

	// Use this for initialization
	void Awake () {
        //this.blinds = this.GetComponentInChildren<TransitionBlinds>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider collider)
    {
        ExitingPlayer exitPlayer = collider.GetComponent<ExitingPlayer>();
        
        if (exitPlayer == null) { return; }

        exitPlayer.setNextScene(this.nextSceneName);
        exitPlayer.OnTriggerEnter(collider);
    }

    //private void changeScene()
    //{
    //    Application.LoadLevel(nextSceneName);
    //}
}
