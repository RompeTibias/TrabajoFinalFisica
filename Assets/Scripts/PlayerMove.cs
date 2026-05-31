using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 5f;

    [Header("Look")]
    [SerializeField] float lookSensitivityX = 0.15f;
    [SerializeField] float lookSensitivityY = 0.15f;
    [SerializeField] float minPitch = -80f;
    [SerializeField] float maxPitch = 80f;

    bool isGrounded;
    float pitch;

    InputAction move;
    InputAction look;
    InputAction jump;
    InputAction pause;
    InputAction interact;
    InputAction reset;
    InputAction mute;

    Rigidbody rb;

    public int[] collected = new int[3];

    public GameObject playerCamera;
    public GameObject pasueCanvas;
    public GameObject audios;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = new InputAction("Move");
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

        interact = new InputAction("Interact", binding: "<Keyboard>/e");
        interact.Enable();

        mute = new InputAction("Mute", binding: "<Keyboard>/m");
        mute.Enable();

        for (int i = 0; i < collected.Length; i++)
            collected[i] = 0;

        LockMouse();
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
        HandleJump();
        HandlePause();
        HandleInteract();
        HandleReset();
        HandleMute();
    }

    void HandleMovement()
    {
        Vector2 moveInput = move.ReadValue<Vector2>();

        Vector3 moveDirection =
            transform.forward * moveInput.y +
            transform.right * moveInput.x;

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void HandleLook()
    {
        Vector2 lookInput = look.ReadValue<Vector2>();

        float mouseX = lookInput.x * lookSensitivityX;
        float mouseY = lookInput.y * lookSensitivityY;

        transform.Rotate(Vector3.up * mouseX);

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void HandleJump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (jump.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandlePause()
    {
        if (pause.WasPressedThisFrame())
        {
            ShowMouse();
            look.Disable();
            pasueCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void HandleInteract()
    {
        if (interact.WasPressedThisFrame())
        {
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 2f))
            {
                if (hit.collider.CompareTag("I"))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                        interactable.Interact();
                }
            }
        }
    }

    void HandleReset()
    {
        if (reset.WasPressedThisFrame())
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void HandleMute()
    {
        if (mute.WasPressedThisFrame())
        {
            AudioSource source = audios.GetComponent<AudioSource>();
            if (source != null)
                source.mute = !source.mute;
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
        LockMouse();
    }

    void ShowMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}