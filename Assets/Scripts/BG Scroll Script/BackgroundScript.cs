using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
    Debug.Log(scrollSpeed);
    scrollSpeed += 0.0005f * Time.deltaTime;
    }

    void Scroll() {
         xScroll = Time.time * scrollSpeed;
         Vector2 offset = new Vector2(xScroll, 5f);
         meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void scrollSpeedScaling()
    {
        
    }
        
    
}
