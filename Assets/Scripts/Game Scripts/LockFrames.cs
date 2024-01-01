using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockFrames : MonoBehaviour   
{

    public int frameRate = 120;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
