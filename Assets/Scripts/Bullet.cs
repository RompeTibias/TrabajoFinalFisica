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
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMove player = FindFirstObjectByType<PlayerMove>();

            if (player != null)
            {
                player.CollectItem(0);
            }
        }
            Destroy(gameObject);
    }
}
