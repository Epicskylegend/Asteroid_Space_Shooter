using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

public float scrollSpeed = 0.1f;

private float xScroll;

private MeshRenderer meshRenderer;
void Awake() {
    meshRenderer = GetComponent<MeshRenderer>();
}
     

    // Update is called once per frame
    void Update() {
    Scroll();
}

    void Scroll() {
         xScroll = Time.time * scrollSpeed;
         Vector2 offset = new Vector2(xScroll, 0f);
         meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
        
    
}
