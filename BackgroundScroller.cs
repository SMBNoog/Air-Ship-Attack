using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

    public float scrollSpeed;       // Speed to scroll the mesh

    Renderer rend;                  // Renderer of the quad mesh

	// Use this for initialization
	void Start () {
        // Assign the renderer
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        // Create an offset to move at a speed * Time
        float offset = Time.time * scrollSpeed;
        // Set the texture's offset so that it moves along the y axis at the offset speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0.0f, offset));
    }
}
