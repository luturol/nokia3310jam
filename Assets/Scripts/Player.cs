using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bustedImage;

    private PlayerInput playerInput;
    private Rigidbody2D rigid;
    private Vector2 initialPos;
    private bool canMove = true;
    private GameStatus gameStatus;
    void Awake()
    {
        playerInput = new PlayerInput();
        initialPos = new Vector2(transform.position.x, transform.position.y);
        gameStatus = FindObjectOfType<GameStatus>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (!canMove)
        {
            transform.position = initialPos;
        }
    }
    
    void Movement(Vector2 moveInput)
    {
        if (moveInput.x != 0 || moveInput.y != 0)
        {

            if (moveInput.x < 0)
                spriteRenderer.flipX = true;
            else
                spriteRenderer.flipX = false;

            animator.SetInteger("Walking", 1);
        }
        else
        {
            animator.SetInteger("Walking", 0);
        }

        rigid.MovePosition(rigid.position + moveInput * speed * Time.fixedDeltaTime);
        rigid.velocity = moveInput * speed;
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }

    void FixedUpdate()
    {
        if (canMove)
            Movement(playerInput.Movement.Move.ReadValue<Vector2>());
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Monster")
        {
            canMove = false;
            transform.position = initialPos;
            gameStatus.RestartGame();
        }
    }

    public void CanMove() => canMove = true;
}
