using UnityEngine;
using System.Collections;

public class MeshesColourizer : MonoBehaviour {

    [SerializeField]
    private Color32 colour;

    [SerializeField]
    private string shaderPath = "Custom/VertexColoured";

	// Use this for initialization
	void Awake () 
    {
        Debug.Log("colour is " + this.colour.ToString());

        MeshFilter[] meshFilters = this.GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter meshFilter in meshFilters)
        {
            Mesh mesh = meshFilter.mesh;

            Color32[] meshColours = new Color32[mesh.vertexCount];
            for (int i = 0; i < mesh.vertexCount; i++)
            {
                meshColours[i] = this.colour;
            }

            mesh.colors32 = meshColours;

            meshFilter.renderer.material.shader = Shader.Find(this.shaderPath);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
