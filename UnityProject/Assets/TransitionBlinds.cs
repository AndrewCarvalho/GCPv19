using UnityEngine;
using System.Collections;

public class TransitionBlinds : MonoBehaviour {

    private enum SlideState { SLIDSTATE_OFF, SLIDESTATE_OPEN, SLIDESTATE_CLOSE };

    [SerializeField]
    private float transitionSpeed = 1;

    private Transform blindsLeft;
    private Transform blindsRight;

    private SlideState slideState = SlideState.SLIDESTATE_OPEN;

    private float timer = 0f;

    public delegate void OnTransitionComplete();

    private OnTransitionComplete onTransitionCompelte;

	// Use this for initialization
	void Awake () 
    {
        this.blindsLeft = this.transform.FindChild("transitionBlinds1");
        this.blindsRight = this.transform.FindChild("transitionBlinds2");

        this.transform.parent.parent.GetComponent<FPSInputController>().enabled = false;
        this.transform.parent.parent.GetComponent<MouseLook>().enabled = false;
        this.transform.parent.GetComponent<MouseLook>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 moveDistLeft;

        switch (this.slideState)
        {
            case SlideState.SLIDESTATE_OPEN:
                this.timer += Time.deltaTime;

                moveDistLeft = Vector3.Lerp(new Vector3(), new Vector3(-6, 0, 0), transitionSpeed * timer / 100);

                this.blindsLeft.Translate(moveDistLeft, Space.Self);
                this.blindsRight.Translate(-moveDistLeft, Space.Self);

                if (this.timer > 2f)
                {
                    this.transform.parent.parent.GetComponent<FPSInputController>().enabled = true;
                    this.transform.parent.parent.GetComponent<MouseLook>().enabled = true;
                    this.transform.parent.GetComponent<MouseLook>().enabled = true;
                    this.slideState = SlideState.SLIDSTATE_OFF;
                    this.gameObject.SetActive(false);
                }

                break;
            case SlideState.SLIDESTATE_CLOSE:
                this.timer += Time.deltaTime;

                moveDistLeft = Vector3.Lerp(new Vector3(), new Vector3(6, 0, 0), transitionSpeed * timer / 100);

                this.blindsLeft.Translate(moveDistLeft, Space.Self);
                this.blindsRight.Translate(-moveDistLeft, Space.Self);

                if (this.timer > 2f)
                {
                    this.transform.parent.parent.GetComponent<FPSInputController>().enabled = true;
                    this.transform.parent.parent.GetComponent<MouseLook>().enabled = true;
                    this.transform.parent.GetComponent<MouseLook>().enabled = true;
                    this.slideState = SlideState.SLIDSTATE_OFF;
                    this.onTransitionCompelte();
                }

                break;
            case SlideState.SLIDSTATE_OFF:
                break;
        }
	}

    public void SetStateOpen()
    {
        this.timer = 0f;
        this.slideState = SlideState.SLIDESTATE_OPEN;
    }

    public void SetStateClose(OnTransitionComplete function)
    {
        this.transform.parent.parent.GetComponent<FPSInputController>().enabled = false;
        this.transform.parent.parent.GetComponent<MouseLook>().enabled = false;
        this.transform.parent.GetComponent<MouseLook>().enabled = false;

        this.timer = 0f;
        this.gameObject.SetActive(true);
        this.onTransitionCompelte = function;
        this.slideState = SlideState.SLIDESTATE_CLOSE;
    }
}
