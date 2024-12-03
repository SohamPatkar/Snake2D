using UnityEngine;

public class SpeedMultiplier : PowerUps
{
    private void Start()
    {
        typeOfPowerup = PowerUpType.SpeedMultiplier;
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpeedMultiplierPicked(other.gameObject);
    }
}
