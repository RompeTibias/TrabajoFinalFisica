using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] public int bulletIndex = 0;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int force = 10;
    [SerializeField] private GameObject[] weapons;

    private InputAction shoot;
    private InputAction changeBullet;

    PlayerMove playerMove;

    void Awake()
    {
        shoot = new InputAction("Shoot", binding: "<Mouse>/leftButton");
        shoot.Enable();

        changeBullet = new InputAction("ChangeBullet", InputActionType.Value, binding: "<Mouse>/scroll");
        changeBullet.Enable();

        playerMove = GetComponent<PlayerMove>();

        HideMouse();
    }

    void Update()
    {
        Vector2 scroll = changeBullet.ReadValue<Vector2>();

        if (scroll.y > 0f)
        {
            bulletIndex = (bulletIndex + 1) % bulletPrefabs.Length;
            ChangeWeapon(bulletIndex);
        }
        else if (scroll.y < 0f)
        {
            bulletIndex--;
            if (bulletIndex < 0) bulletIndex = bulletPrefabs.Length - 1;
            ChangeWeapon(bulletIndex);
        }

        if (shoot.WasPressedThisFrame())
        {
            if(playerMove.collected[bulletIndex] <= 0)
            {
                Debug.Log("No tienes balas de este tipo");
                return;
            }
            GameObject bullet = Instantiate(bulletPrefabs[bulletIndex], firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * force, ForceMode.Impulse);
            playerMove.collected[bulletIndex]--;
        }
    }

    void ChangeWeapon(int index)
    {
        weapons[index].SetActive(true);
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i != index)
            {
                weapons[i].SetActive(false);
            }
        }
    }

    void HideMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}