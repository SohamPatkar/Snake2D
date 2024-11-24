using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Consumables")]
    [SerializeField] private GameObject[] consumables, powerups;
    [Header("Spawn Variables")]
    [SerializeField] private int spawnRate, spawnRatepowerups;
    private SnakeMovement snakeMovement;
    private Vector3 randomSpawnCoord;
    private GameObject consumableToSpawn, powerupsToSpawn;
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
        InvokeRepeating("SpawnConsumables", 3, spawnRate);
        InvokeRepeating("SpawnPowerUps", 3, spawnRatepowerups);
        snakeMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<SnakeMovement>();
    }

    private void SpawnConsumables()
    {
        randomSpawnCoord.x = Random.Range(-7, 7);
        randomSpawnCoord.y = Random.Range(-4, 4);
        randomSpawnCoord.z = 0;

        int i = Random.Range(0, consumables.Length);
        consumableToSpawn = consumables[i];

        if (snakeMovement.ReturnSnakeLength() <= 1)
        {
            foreach (var consumable in consumables)
            {
                if (consumable.name == "MassGainer")
                {
                    consumableToSpawn = consumable;
                }
            }
        }

        Instantiate(consumableToSpawn, randomSpawnCoord, Quaternion.identity);
    }

    private void SpawnPowerUps()
    {
        randomSpawnCoord.x = Random.Range(-7, 7);
        randomSpawnCoord.y = Random.Range(-4, 4);
        randomSpawnCoord.z = 0;

        int i = Random.Range(0, powerups.Length);
        powerupsToSpawn = powerups[i];
        Instantiate(powerupsToSpawn, randomSpawnCoord, Quaternion.identity);
    }
}
