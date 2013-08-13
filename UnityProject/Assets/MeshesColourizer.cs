using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshesColourizer : MonoBehaviour {

    [SerializeField]
    private Color32 colour;

    [SerializeField]
    private string shaderPath = "Custom/VertexColoured";

    public string[] exclusions;

	// Use this for initialization
	void Awake () 
    {
        //Debug.Log("colour is " + this.colour.ToString());
        List<string> exclusionsList = new List<string>(exclusions);
        MeshFilter[] meshFilters = this.GetComponentsInChildren<MeshFilter>();

        foreach (MeshFilter meshFilter in meshFilters)
        {
            if (!exclusionsList.Contains(meshFilter.name))
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
	}

	// Update is called once per frame
	void Update () {
	
	}
}
