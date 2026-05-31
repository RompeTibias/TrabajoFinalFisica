using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefabs;
    [SerializeField] private int bulletIndex = 0;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int force = 10;

    private InputAction shoot;
    private InputAction changeBullet;

    void Awake()
    {
        shoot = new InputAction("Shoot", binding: "<Mouse>/leftButton");
        shoot.Enable();

        changeBullet = new InputAction("ChangeBullet", InputActionType.Value, binding: "<Mouse>/scroll");
        changeBullet.Enable();
    }

    void Update()
    {
        Vector2 scroll = changeBullet.ReadValue<Vector2>();

        if (scroll.y > 0f)
        {
            bulletIndex = (bulletIndex + 1) % bulletPrefabs.Length;
        }
        else if (scroll.y < 0f)
        {
            bulletIndex--;
            if (bulletIndex < 0) bulletIndex = bulletPrefabs.Length - 1;
        }

        if (shoot.WasPressedThisFrame())
        {
            GameObject bullet = Instantiate(bulletPrefabs[bulletIndex], firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * force, ForceMode.Impulse);
        }
    }
}