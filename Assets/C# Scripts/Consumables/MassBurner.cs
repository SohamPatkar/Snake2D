using UnityEngine;

public class MassBurner : Food
{
    void Start()
    {
        typeOfFood = FoodType.MassBurner;
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MassBurnerEaten(other.gameObject);
        ConsumablesManager.Instance.DisplayTextFood(typeOfFood);
        Destroy(gameObject);
    }
}
