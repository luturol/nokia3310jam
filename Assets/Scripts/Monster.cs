using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject player;

    private bool isPlayerInRange = false;
    private int posIndex = 0;   

    private bool validationPosNextPosIndex = false;
    void Update()
    {
        if(!isPlayerInRange && positions.Length > 0)    
        {
            Transform nextPosition = positions[posIndex];
            bool isPositionEquals = transform.position.x == nextPosition.position.x && transform.position.y == nextPosition.position.y;                  
            if(isPositionEquals)
            {
                validationPosNextPosIndex = positions.Length > posIndex + 1;
                if(validationPosNextPosIndex)
                    posIndex++;
                else
                    posIndex = 0;                    
                nextPosition = positions[posIndex];
            }
            transform.position = Vector2.MoveTowards(transform.position, nextPosition.position, speed * Time.fixedDeltaTime);
        }
        else if(isPlayerInRange){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
            isPlayerInRange = true;        
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
            isPlayerInRange = false;
    }
}
