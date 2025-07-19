using UnityEngine;

public class PlayerStatController : MonoBehaviour
{
    //Singleton instance
    public static PlayerStatController Instance { get; private set; }

    public StatBar healthBar;
    public StatBar manaBar;
    float attackDamage;
    float defense;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        healthBar = transform.Find("PlayerUI/HealthBar").GetComponent<StatBar>();
        manaBar = transform.Find("PlayerUI/ManaBar").GetComponent<StatBar>();

        healthBar.SetValue(100);
        manaBar.SetValue(100);
    }

    void Update()
    {

    }   
}