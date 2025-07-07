using UnityEngine;

public class StatController : MonoBehaviour
{

    public float maxHealth = 100;
    public float currentHealth; 
    public float maxStamina = 100;
    public float currentStamina;
    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {

    }   
}