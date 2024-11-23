using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Consumables")]
    [SerializeField] private GameObject[] consumables;
    private SnakeMovement snakeMovement;
    private Vector3 randomSpawnCoord;
    private GameObject consumableToSpawn;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("SpawnConsumables", 3, 2);
        snakeMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeMovement>();
    }

    private void SpawnConsumables()
    {
        randomSpawnCoord.x = Random.Range(-7, 7);
        randomSpawnCoord.y = Random.Range(-4, 4);
        randomSpawnCoord.z = 0;

        int i = Random.Range(0, consumables.Length);
        if (snakeMovement.ReturnSnakeLength() <= 1)
        {
            i = 1;
        }
        consumableToSpawn = consumables[i];
        Instantiate(consumableToSpawn, randomSpawnCoord, Quaternion.identity);
    }
}
