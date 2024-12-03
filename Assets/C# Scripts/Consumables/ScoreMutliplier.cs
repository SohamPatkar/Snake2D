using System.Collections;
using UnityEngine;

public class ScoreMutliplier : PowerUps
{
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreMutliplierPicked(other.gameObject);
    }
}
