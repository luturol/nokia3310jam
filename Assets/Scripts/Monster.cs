﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip hitAudio;

    private bool isPlayerInRange = false;
    private int posIndex = 0;
    private Vector2 initialPos;
    private AudioSource audioSource;
    private bool canMove = true;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        initialPos = new Vector2(transform.position.x, transform.position.y);
        audioSource = GetComponent<AudioSource>();
    }

    private bool validationPosNextPosIndex = false;
    void Update()
    {
        if (canMove)
        {
            if (!isPlayerInRange && positions.Length > 0)
            {
                Transform nextPosition = positions[posIndex];
                bool isPositionEquals = transform.position.x == nextPosition.position.x && transform.position.y == nextPosition.position.y;
                if (isPositionEquals)
                {
                    validationPosNextPosIndex = positions.Length > posIndex + 1;
                    if (validationPosNextPosIndex)
                        posIndex++;
                    else
                        posIndex = 0;
                    nextPosition = positions[posIndex];
                }
                transform.position = Vector2.MoveTowards(transform.position, nextPosition.position, speed * Time.fixedDeltaTime);
            }
            else if (isPlayerInRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
            }
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            isPlayerInRange = true;
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.PlayOneShot(hitAudio);
            isPlayerInRange = false;            
        }
    }

    public void EnableMovement(bool enable) => canMove = enable;
    public void SetToInitialPosition() => transform.position = initialPos;
}
