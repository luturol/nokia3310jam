﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    [SerializeField] private AudioClip winSFX;

    private SceneLoader sceneLoader;
    private AudioSource audioSource;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();    
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(winSFX);
            LoadNextScene();
        }            
    }

    private void LoadNextScene()
    {
        sceneLoader.LoadNextScene();
    }

}
