using UnityEngine;

public class Shield : PowerUps
{
    private void Start()
    {
        typeOfPowerup = PowerUpType.Shield;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ShieldPicked(other.gameObject);
    }
}
