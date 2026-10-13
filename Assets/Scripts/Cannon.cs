using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private Transform spawn;

    private AudioSource audio;
    private InputAction moveAction;
    private InputAction attackAction;
    private Vector2 move;
    private Vector2 rotation = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        moveAction = InputSystem.actions.FindAction("Move");
        attackAction = InputSystem.actions.FindAction("Attack");

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        attackAction.performed += OnAttack;
    }

    void OnDestroy()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        attackAction.performed -= OnAttack;
    }

    // Update is called once per frame
    void Update()
    {
        var scaledMove = settings.cannonSpeed * Time.deltaTime * move;

        rotation.x = Mathf.Clamp(rotation.x + scaledMove.x, -90, 90);
        rotation.y = Mathf.Clamp(rotation.y + scaledMove.y, 0, 90);

        transform.rotation = Quaternion.Euler(new Vector3(rotation.y, 0, -rotation.x));
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.Ball) return;

        var ball = Instantiate(settings.ball);

        ball.transform.position = spawn.position;
        ball.GetComponent<Rigidbody>().AddForce(spawn.up * settings.cannonForce);

        audio.Play();
    }
}
