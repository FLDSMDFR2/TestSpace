using UnityEngine;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody rb;

    public float BaseMoveForce;
    public float BoostMoveForce;

    [ReadOnlyInspector]
    public float CurrentMoveForce;

    public float RotationTime;
    protected float currentVelocity;

    protected PlayerInputs inputActions;
    protected float angleToLook;

    protected Player player;
    protected Ship ship;

    protected virtual void Awake()
    {
        player = GetComponentInChildren<Player>();
        
        rb = GetComponent<Rigidbody>();
        inputActions = new PlayerInputs();
        inputActions.Player.Enable();
        inputActions.Player.Blink.performed += Blink_performed;
        inputActions.Player.Boost.started += Boost_started;
        inputActions.Player.Boost.canceled += Boost_canceled;
        inputActions.Player.Interact.performed += Interact_performed;
        inputActions.Player.Pause.performed += Pause_performed;

        CurrentMoveForce = BaseMoveForce;
    }

    protected virtual void Start()
    {
        ship = player.GetShip();
        ship.Ship_PerformBlink += Ship_PerformBlink;
    }

    protected virtual void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!GameStateData.IsGameOver) GameEventSystem.Player_OnPaused(player);
    }

    protected virtual void Boost_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        CurrentMoveForce = BaseMoveForce;
    }

    protected virtual void Boost_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        CurrentMoveForce = BoostMoveForce;
    }

    protected virtual void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (GameStateData.IsGameOver || GameStateData.IsPaused) return;

        GameEventSystem.Player_OnActivateEncounter(player);
    }

    protected virtual void Ship_PerformBlink(Ship data)
    {
        if (GameStateData.IsGameOver || GameStateData.IsPaused) return;

        var input = inputActions.Player.Move.ReadValue<Vector2>().normalized;
        var newPos = transform.position + new Vector3(input.x, 0, input.y) * data.BlinkDistance;
        newPos.x = Mathf.Clamp(newPos.x, 0, MapLoader.MapBoundsX());
        newPos.z = Mathf.Clamp(newPos.z, 0, MapLoader.MapBoundsZ());
        transform.position = newPos;
    }

    protected virtual void Blink_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (GameStateData.IsGameOver || GameStateData.IsPaused) return;

        GameEventSystem.Player_OnBlinkTriggered(player);
    }

    protected virtual void Update()
    {
        GetPointToLook();
    }

    protected virtual void FixedUpdate()
    {
        if (GameStateData.IsGameOver || GameStateData.IsPaused)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        var angle = Mathf.SmoothDampAngle(rb.transform.eulerAngles.y, angleToLook, ref currentVelocity, RotationTime);
        rb.rotation = Quaternion.Euler(0, angle, 0);

        if (inputActions != null)
        {
            var input = inputActions.Player.Move.ReadValue<Vector2>().normalized;
            rb.AddForce(new Vector3(input.x, 0, input.y) * CurrentMoveForce, ForceMode.Acceleration);
            ship.MovementVelocity = rb.velocity;
        }
    }

    protected virtual void GetPointToLook()
    {
        var cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;
        if (groundplane.Raycast(cameraRay, out rayLength))
        {
            var directionToLook = cameraRay.GetPoint(rayLength) - rb.transform.position;
            angleToLook = Mathf.Atan2(directionToLook.x, directionToLook.z) * Mathf.Rad2Deg;
        }
    }
}
