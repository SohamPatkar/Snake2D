using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    ScoreMutliplier,
    Shield,
    SpeedMultiplier
}

public class PowerUps : MonoBehaviour
{
    public PowerUpType typeOfPowerup;

    public void ShieldPicked(GameObject player)
    {
        SoundManager.Instance.PlaySfx(SoundType.Eaten);
        ConsumablesManager.Instance.DisplayTextPowerUps(PowerUpType.Shield);
        if (player.gameObject.GetComponent<PlayerOne>() != null)
        {
            SnakeMovement.Instance.Shield(player);
        }
        else if (player.gameObject.GetComponent<PlayerTwo>() != null)
        {
            SnakeMovement.Instance.Shield(player);
        }
        Destroy(gameObject);
    }

    public void ScoreMutliplierPicked(GameObject player)
    {
        ConsumablesManager.Instance.DisplayTextPowerUps(PowerUpType.ScoreMutliplier);
        SoundManager.Instance.PlaySfx(SoundType.Eaten);
        if (player.gameObject.GetComponent<PlayerOne>() != null)
        {
            SnakeMovement.Instance.ScoreMultiplierEffect(player);
        }
        else if (player.gameObject.GetComponent<PlayerTwo>() != null)
        {
            SnakeMovement.Instance.ScoreMultiplierEffect(player);
        }
        Destroy(gameObject);
    }

    public void SpeedMultiplierPicked(GameObject player)
    {
        ConsumablesManager.Instance.DisplayTextPowerUps(PowerUpType.SpeedMultiplier);
        SoundManager.Instance.PlaySfx(SoundType.Eaten);
        if (player.gameObject.GetComponent<PlayerOne>() != null)
        {
            SnakeMovement.Instance.SpeedMultiplierEffect(player);
        }
        else if (player.gameObject.GetComponent<PlayerTwo>() != null)
        {
            SnakeMovement.Instance.SpeedMultiplierEffect(player);
        }
        Destroy(gameObject);
    }
}
