using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Consumables")]
    [SerializeField] private GameObject[] consumables;
    [Header("Snake Movement Script")]
    [SerializeField] private SnakeMovement snakeMovement;
    private Vector3 randomSpawnCoord;
    private GameObject consumableToSpawn;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
    }

    private void SpawnConsumables()
    {
        randomSpawnCoord.x = Random.Range(-5, 5);
        randomSpawnCoord.y = Random.Range(-5, 5);
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
