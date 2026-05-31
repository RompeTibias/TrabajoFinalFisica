using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    float speed = 5f;
    float sensitivity = 1f;
    float jumpForce = 5f;
    bool isGrounded;

    InputAction move;
    InputAction look;
    InputAction jump;
    InputAction pause;
    InputAction interact;
    InputAction reset;

    Rigidbody rb;

    public int[] collected = new int[3];

    public GameObject playerCamera;
    public GameObject pasueCanvas;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = new InputAction("Move", binding: "<Keyboard>/w");
        move.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        move.Enable();

        look = new InputAction("Look", binding: "<Mouse>/delta");
        look.Enable();

        jump = new InputAction("Jump", binding: "<Keyboard>/space");
        jump.Enable();

        pause = new InputAction("PauseMenu", binding: "<Keyboard>/escape");
        pause.Enable();

        reset = new InputAction("Reset", binding: "<Keyboard>/r");
        reset.Enable();

        for (int i = 0; i < collected.Length; i++)
        {
            collected[i] = 0;
        }

        interact = new InputAction("Interact", binding: "<Keyboard>/e");
        interact.Enable();
    }

    void Update()
    {
        var moveInput = move.ReadValue<Vector2>();
        var lookInput = look.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        transform.Translate(moveDirection * speed * Time.deltaTime);

        transform.Rotate(0, lookInput.x * sensitivity, 0);
        playerCamera.transform.Rotate(-lookInput.y * sensitivity, 0, 0);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (jump.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (pause.WasPressedThisFrame())
        {
            look.Disable();
            pasueCanvas.SetActive(true);
            Time.timeScale = 0f;
        }

        if(interact.WasPressedThisFrame())
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 2f))
            {
                if (hit.collider.CompareTag("I"))
                {
                    hit.collider.GetComponent<Interactable>().Interact();
                }
            }
        }

        if (reset.WasPressedThisFrame())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void CollectItem(int index)
    {
        collected[index]++;
        Debug.Log("Collected item of type " + index + ". Total: " + collected[index]);
    }

    public void EnableLook()
    {
        look.Enable();
    }
}
