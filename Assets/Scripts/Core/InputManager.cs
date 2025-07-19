using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    [SerializeField] private Joystick joystick;
    public Vector2 MoveInput { get; private set; }
    public bool IsAttackPressed { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        // Gather input
        MoveInput = joystick.Direction;
    }

    public void RegisterAttackInput()
    {
        IsAttackPressed = true;
    }

    private void LateUpdate()
    {
        // Reset attack input after processing
        IsAttackPressed = false;
    }

    public void ResetMoveInput()
    {
        joystick.OnPointerUp(null);
    }
}