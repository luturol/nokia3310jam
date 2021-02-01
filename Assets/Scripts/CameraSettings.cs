using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public float maxPixelHeight = 84f;
    public float ScreenSizeOrthograpfic = 0f;
    // Start is called before the first frame update
    void Start()
    {
        float scale = Mathf.Ceil(Screen.height / maxPixelHeight);
        ScreenSizeOrthograpfic = Screen.height / 2f / scale;
        Camera.main.orthographicSize = Screen.height / 2f / scale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
