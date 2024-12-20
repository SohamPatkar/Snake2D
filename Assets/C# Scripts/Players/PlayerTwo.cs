using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerTwo : SnakeMovement
{
    [Header("Player Type")]
    [SerializeField] public PlayerType playerType;
    [Header("Player")]
    [SerializeField] public GameObject playerGameobject;
    [Header("Body Part")]
    [SerializeField] public GameObject playerBodyPart;
    [Header("Scores")]
    [SerializeField] public int score;
    public List<Transform> snakeBodyParts = new List<Transform>();
    public float scoreToadd;
    public float movementSpeed;
    private float timer;
    private bool canMove;
    private void Awake()
    {
        InitializePlayer();
    }

    void Update()
    {
        Debug.Log(score);
        timer += Time.deltaTime;
        if (timer >= movementSpeed)
        {
            canMove = true;
            Movement(transform, snakeBodyParts);
            timer = 0;
        }
        TakeTurns();
    }

    private void FixedUpdate()
    {
        WrapScript(gameObject);
    }

    void InitializePlayer()
    {
        scoreToadd = 10;
        movementSpeed = 0.5f;
        score = 0;
        timer = 0;
        playerType = PlayerType.PlayerTwo;
        transform.eulerAngles = new Vector3(0, 0, 0);
        snakeBodyParts.Add(transform);
    }

    public override void TakeTurns()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (transform.eulerAngles.z != 0)
                {
                    transform.eulerAngles = leftRotation;
                    canMove = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (transform.eulerAngles.z != 270)
                {
                    transform.eulerAngles = upRotation;
                    canMove = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (transform.eulerAngles.z != 90)
                {
                    transform.eulerAngles = downRotation;
                    canMove = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (transform.eulerAngles.z != 180)
                {
                    transform.eulerAngles = rightRotation;
                    canMove = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerBodyPart.gameObject.layer)
        {
            Death(gameObject);
        }
        else if (other.gameObject.layer == 9)
        {
            Kill(other.gameObject);
        }
    }
}
