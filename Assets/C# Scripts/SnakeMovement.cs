using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float timer;
    private Vector3 leftRotation, rightRotation, upRotation, downRotation;
    private List<Transform> snakeBodyParts = new List<Transform>();
    [Header("Speed of Snake")]
    [SerializeField] private int speed;
    [Header("Body Part")]
    [SerializeField] private GameObject bodyPart;
    private void Start()
    {
        InitializeGame();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Movement();
    }

    private void FixedUpdate()
    {
        WrapScript();
    }

    void InitializeGame()
    {
        transform.eulerAngles = Vector3.zero;
        leftRotation = new Vector3(0, 0, 180);
        rightRotation = new Vector3(0, 0, 0);
        upRotation = new Vector3(0, 0, 90);
        downRotation = new Vector3(0, 0, 270);
        speed = 1;
        snakeBodyParts.Add(transform);
    }

    void Movement()
    {
        if (Mathf.Round(timer) == 1)
        {
            Vector3 previousPosition = transform.position;

            transform.Translate(Vector3.right * speed);

            foreach (Transform bodyPart in snakeBodyParts)
            {
                if (bodyPart != transform)
                {
                    Vector3 tempPosition = bodyPart.position;
                    bodyPart.position = previousPosition;
                    previousPosition = tempPosition;
                }
            }
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (transform.eulerAngles.z != 0)
            {
                transform.eulerAngles = leftRotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (transform.eulerAngles.z != 270)
            {
                transform.eulerAngles = upRotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (transform.eulerAngles.z != 90)
            {
                transform.eulerAngles = downRotation;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.eulerAngles.z != 180)
            {
                transform.eulerAngles = rightRotation;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            AddBodyPart();
        }
    }

    void WrapScript()
    {
        //Vertical Wrapping
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, -5f, 0);
        }
        else if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5f, 0);
        }

        //Horizontal Wrapping
        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9f, transform.position.y, 0);
        }
        else if (transform.position.x < -9)
        {
            transform.position = new Vector3(9f, transform.position.y, 0);
        }
    }

    public void AddBodyPart()
    {
        Vector3 newPartPosition = snakeBodyParts[snakeBodyParts.Count - 1].transform.position;
        Debug.Log("Space pressed");
        Transform partToadd = Instantiate(bodyPart, newPartPosition, transform.rotation).transform;
        StartCoroutine(DelayForCollisions(partToadd));
        snakeBodyParts.Add(partToadd);
    }

    public void RemoveBodyPart()
    {
        GameObject tailDestroy = snakeBodyParts[snakeBodyParts.Count - 1].gameObject;
        snakeBodyParts.Remove(snakeBodyParts[snakeBodyParts.Count - 1]);
        Destroy(tailDestroy);
    }

    public int ReturnSnakeLength()
    {
        return snakeBodyParts.Count;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == gameObject.layer)
        {
            Time.timeScale = 0;
        }
    }

    IEnumerator DelayForCollisions(Transform part)
    {
        yield return new WaitForSeconds(1.2f);
        part.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
