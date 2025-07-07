using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    PlayerController playerController;
    Button attackButton;

    GameObject healthBar;
    GameObject manaBar;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        healthBar = transform.Find("HealthBar").gameObject;
        manaBar = transform.Find("ManaBar").gameObject;

        attackButton = transform.Find("AttackButton").GetComponent<Button>();
        attackButton.onClick.AddListener(OnAttackButtonClicked);
    }

    void Update()
    {
        UpdateStatus();
    }

    private void OnAttackButtonClicked()
    {
        playerController.Attack();

    }
    
    private void UpdateStatus()
    {
        // Update health bar
        float healthPercentage = playerController.statController.currentHealth / playerController.statController.maxHealth;
        healthBar.transform.Find("Line").localScale = new Vector3(healthPercentage, 1, 1);

        // Update mana bar
        float manaPercentage = playerController.statController.currentStamina / playerController.statController.maxStamina;
        manaBar.transform.Find("Line").localScale = new Vector3(manaPercentage, 1, 1);
    }
}