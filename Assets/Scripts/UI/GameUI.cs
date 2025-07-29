using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject cooldownMaskPrefab;
    Button attackButton;


    void Start()
    {
        attackButton = transform.Find("AttackButton").GetComponent<Button>();
        
        attackButton.onClick.AddListener(OnAttackButtonClicked);
    }

    void Update()
    {
    }

    private void OnAttackButtonClicked()
    {
        InputManager.Instance.RegisterAttackInput();
    }
    

}