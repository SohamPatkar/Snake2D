using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Consumables")]
    [SerializeField] private GameObject[] consumables, powerups;
    [Header("Spawn Variables")]
    [SerializeField] private int spawnRate, spawnRatepowerups;
    [Header("Scripts")]
    [SerializeField] private PlayerOne playerOne;
    [SerializeField] private PlayerTwo playerTwo;
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
    }

    private Vector3 ReturnRange()
    {
        randomSpawnCoord.x = Random.Range(-7, 7);
        randomSpawnCoord.y = Random.Range(-4, 4);
        randomSpawnCoord.z = 0;

        return randomSpawnCoord;
    }

    private void SpawnConsumables()
    {
        int i = Random.Range(0, consumables.Length);
        consumableToSpawn = consumables[i];

        if (SnakeMovement.Instance.ReturnSnakeLength(playerOne.snakeBodyParts) <= 1)
        {
            foreach (var consumable in consumables)
            {
                if (consumable.name == "MassGainer")
                {
                    consumableToSpawn = consumable;
                }
            }
        }
        else
        {
            consumableToSpawn = consumables[i];
        }

        Instantiate(consumableToSpawn, ReturnRange(), Quaternion.identity);
    }

    private void SpawnPowerUps()
    {
        int i = Random.Range(0, powerups.Length);
        powerupsToSpawn = powerups[i];
        Instantiate(powerupsToSpawn, ReturnRange(), Quaternion.identity);
    }
}
