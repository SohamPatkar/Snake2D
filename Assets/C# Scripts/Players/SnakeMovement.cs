using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    PlayerOne,
    PlayerTwo
}

public class SnakeMovement : MonoBehaviour
{
    [Header("Speed of Snake")]
    [SerializeField] private int speed;
    [Header("Players")]
    [SerializeField] protected PlayerOne playerOne;
    [SerializeField] protected PlayerTwo playerTwo;
    [SerializeField] private GameObject playerOneObject, playerTwoObject;
    protected Vector3 leftRotation, rightRotation, upRotation, downRotation;
    private bool isPlayerOne;
    private static SnakeMovement instance;
    public static SnakeMovement Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        leftRotation = new Vector3(0, 0, 180);
        rightRotation = new Vector3(0, 0, 0);
        upRotation = new Vector3(0, 0, 90);
        downRotation = new Vector3(0, 0, 270);
        speed = 1;
    }

    public void Movement(Transform player, List<Transform> bodyparts)
    {
        Vector3 previousPosition = player.position;

        foreach (Transform bodyPart in bodyparts)
        {
            if (bodyPart != gameObject.transform)
            {
                Vector3 tempPosition = bodyPart.position;
                bodyPart.position = previousPosition;
                previousPosition = tempPosition;
            }
        }

        player.Translate(Vector3.right * speed);
    }

    public virtual void TakeTurns() { }

    public void WrapScript(GameObject player)
    {
        //Vertical Wrapping
        if (player.transform.position.y > 5)
        {
            player.transform.position = new Vector3(player.transform.position.x, -5f, 0);
        }
        else if (player.transform.position.y < -5)
        {
            player.transform.position = new Vector3(player.transform.position.x, 5f, 0);
        }

        //Horizontal Wrapping
        if (player.transform.position.x > 9)
        {
            player.transform.position = new Vector3(-9f, player.transform.position.y, 0);
        }
        else if (player.transform.position.x < -9)
        {
            player.transform.position = new Vector3(9f, player.transform.position.y, 0);
        }
    }

    public void AddBodyPart(List<Transform> snakeBodyParts, GameObject playerOneBody, Transform playerOne)
    {
        Vector3 newPartPosition = snakeBodyParts[snakeBodyParts.Count - 1].transform.position;
        Transform partToadd = Instantiate(playerOneBody, newPartPosition, playerOne.transform.rotation).transform;
        StartCoroutine(DelayForCollisions(partToadd));
        snakeBodyParts.Add(partToadd);
    }

    public void RemoveBodyPart(List<Transform> snakeBodyParts)
    {
        GameObject tailDestroy = snakeBodyParts[snakeBodyParts.Count - 1].gameObject;
        snakeBodyParts.Remove(snakeBodyParts[snakeBodyParts.Count - 1]);
        Destroy(tailDestroy);
    }

    public int ReturnSnakeLength(List<Transform> bodyparts)
    {
        return bodyparts.Count;
    }

    public virtual void AddScore(GameObject player)
    {
        if (player.GetComponent<PlayerOne>() != null)
        {
            playerOne.score += (int)playerOne.scoreToadd;
            ScoreManager.Instance.ScoreDisplay(playerOne.score);
        }
        else if (player.GetComponent<PlayerTwo>() != null)
        {
            playerTwo.score += (int)playerOne.scoreToadd;
            ScoreManager.Instance.PlayerTwoScoreDisplay(playerTwo.score);
        }
    }

    public void SpeedMultiplierEffect(GameObject player)
    {
        if (player.GetComponent<PlayerOne>() != null)
        {
            playerOne.movementSpeed = 0.1f;
            isPlayerOne = true;
        }
        else if (player.GetComponent<PlayerTwo>() != null)
        {
            playerTwo.movementSpeed = 0.1f;
            isPlayerOne = false;
        }
        Invoke(nameof(SpeedCooldown), 5f);
    }

    void SpeedCooldown()
    {
        if (isPlayerOne)
        {
            playerOne.movementSpeed = 0.5f;
        }
        else
        {
            playerTwo.movementSpeed = 0.5f;
        }
    }

    public void ScoreMultiplierEffect(GameObject player)
    {
        if (player.GetComponent<PlayerOne>() != null)
        {
            playerOne.scoreToadd *= 2;
            isPlayerOne = true;
            StartCoroutine(MultiplierCooldown(isPlayerOne));
        }
        else if (player.GetComponent<PlayerTwo>() != null)
        {
            playerTwo.scoreToadd *= 2;
            isPlayerOne = false;
            StartCoroutine(MultiplierCooldown(isPlayerOne));
        }
    }

    IEnumerator MultiplierCooldown(bool isPlayerOne)
    {
        yield return new WaitForSeconds(5f);
        if (isPlayerOne)
        {
            playerOne.scoreToadd = 10;
        }
        else
        {
            playerTwo.scoreToadd = 10;
        }
    }

    public void EmptyList(List<Transform> bodyparts)
    {
        foreach (var part in bodyparts)
        {
            Destroy(part.gameObject);
        }
    }

    public void Death(GameObject player)
    {
        SoundManager.Instance.PlaySfx(SoundType.Death);
        ScoreManager.Instance.GameOver();
        Destroy(player, 0.2f);
    }

    public void Kill(GameObject other)
    {
        if (other.layer == 9)
        {
            ScoreManager.Instance.PlayerWon(PlayerType.PlayerTwo);
        }
        else if (other.layer == 10)
        {
            ScoreManager.Instance.PlayerWon(PlayerType.PlayerOne);
        }
        Destroy(other);
    }

    public void Shield(GameObject player)
    {
        if (player.gameObject.GetComponent<PlayerOne>() != null)
        {
            Physics2D.IgnoreLayerCollision(playerOneObject.layer, playerOne.playerBodyPart.layer, true);
        }
        else if (player.GetComponent<PlayerTwo>() != null)
        {
            Physics2D.IgnoreLayerCollision(playerTwoObject.layer, playerTwo.playerBodyPart.layer, true);
        }
        StartCoroutine(ShieldCoolDown(player));
    }

    IEnumerator ShieldCoolDown(GameObject player)
    {
        yield return new WaitForSeconds(5f);
        if (player.gameObject == playerOne.gameObject)
        {
            Physics2D.IgnoreLayerCollision(playerOneObject.layer, playerOne.playerBodyPart.layer, false);
        }
        else if (player.gameObject == playerTwo.gameObject)
        {
            Physics2D.IgnoreLayerCollision(playerTwoObject.layer, playerTwo.playerBodyPart.layer, false);
        }
    }

    IEnumerator DelayForCollisions(Transform part)
    {
        yield return new WaitForSeconds(1.2f);
        if (part != null)
        {
            part.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            Debug.Log("null");
        }
    }
}
