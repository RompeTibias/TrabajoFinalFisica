using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("D"))
        {
            PlayerMove player = FindFirstObjectByType<PlayerMove>();

            if (player != null)
            {
                player.CollectItem(0);
            }

            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
