using UnityEngine;
using System.Collections;

public class VertexColourizer : MonoBehaviour {

    [SerializeField]
    private Color32 colour;

    private bool set = false;

	// Use this for initialization
	void Awake () 
    {
        Debug.Log("colour is " + this.colour.ToString());

        Mesh mesh = this.GetComponent<MeshFilter>().mesh;

        Color32[] meshColours = new Color32[mesh.vertexCount];
        for (int i = 0; i < mesh.vertexCount; i++)
        {
            meshColours[i] = this.colour;
        }

        mesh.colors32 = meshColours;
	}

    // Update is called once per frame
    void Update() 
    {
        //if (!this.set)
        //{
        //    Debug.Log("colour is " + this.colour.ToString());

        //    Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        //    for (int i = 0; i < mesh.vertexCount; i++)
        //    {
        //        mesh.colors32[i] = this.colour;
        //    }

        //    this.set = true;
        //}
	}
}
