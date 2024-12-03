using UnityEngine;
using TMPro;

public class ConsumablesManager : MonoBehaviour
{
    private static ConsumablesManager instance;
    public static ConsumablesManager Instance { get { return instance; } }
    public TextMeshProUGUI consumableName;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        consumableName.text = "Power up";
    }

    public void DisplayTextFood(FoodType foodType)
    {
        consumableName.text = foodType.ToString() + " Picked";
    }

    public void DisplayTextPowerUps(PowerUpType powerUp)
    {
        consumableName.text = powerUp.ToString() + " Picked";
        Invoke(nameof(PowerUpText), 2f);
    }

    public void PowerUpText()
    {
        consumableName.text = "Power up";
    }
}
