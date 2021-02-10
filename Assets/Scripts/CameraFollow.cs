using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 position = transform.position;
            position.x = player.transform.position.x;
            position.y = player.transform.position.y;

            transform.position = position;
        }
    }
}
