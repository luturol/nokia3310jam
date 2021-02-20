﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private float delayTimeToRestartGame = 5f;        
    [SerializeField] private GameObject bustedImage;

    private bool restart = false;    
    private float currentTime = 0f;
    private Player player;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<Player>();    
    }

    // Update is called once per frame
    void Update()
    {   
        if(restart)
        {
            bustedImage.SetActive(true);
            currentTime += Time.deltaTime;
            if(currentTime >= delayTimeToRestartGame)
            {
                bustedImage.SetActive(false);
                restart = false;
                player.CanMove();
                currentTime = 0f;                
            }
        }        
    }

    public void RestartGame() => restart = true;
}