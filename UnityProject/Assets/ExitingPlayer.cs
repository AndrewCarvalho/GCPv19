using UnityEngine;
using System.Collections;

public class ExitingPlayer : MonoBehaviour {

    private string nextSceneName;

    private TransitionBlinds blinds;

    // Use this for initialization
    void Awake()
    {
        this.blinds = this.GetComponentInChildren<TransitionBlinds>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setNextScene(string sceneName)
    {
        this.nextSceneName = sceneName;
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger enter");
        blinds.SetStateClose(new TransitionBlinds.OnTransitionComplete(this.changeScene));
    }

    private void changeScene()
    {
        Application.LoadLevel(nextSceneName);
    }
}
