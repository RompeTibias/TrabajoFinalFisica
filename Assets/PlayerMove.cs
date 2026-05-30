using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMove : MonoBehaviour
{
    float speed = 5f;
    float sensitivity = 1f;

    InputAction move;
    InputAction look;

    public GameObject playerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = new InputAction("Move", binding: "<Keyboard>/w");
        move.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        move.Enable();

        look = new InputAction("Look", binding: "<Mouse>/delta");
        look.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        var moveInput = move.ReadValue<Vector2>();
        var lookInput = look.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        transform.Rotate(0, lookInput.x * sensitivity, 0);
        playerCamera.transform.Rotate(-lookInput.y * sensitivity, 0, 0);
    }
}
