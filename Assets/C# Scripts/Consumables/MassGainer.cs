using UnityEngine;

public class MassGainer : Food
{
    private void Awake()
    {
        typeOfFood = FoodType.MassGainer;
    }
    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MassGainerEaten(other.gameObject);
        ConsumablesManager.Instance.DisplayTextFood(typeOfFood);
        Destroy(gameObject);
    }
}
