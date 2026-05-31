using UnityEngine;

public class BalaTres : MonoBehaviour
{ 
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("F"))
        {

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMove player = FindFirstObjectByType<PlayerMove>();

            if (player != null)
            {
                player.CollectItem(2);
            }
        }
            Destroy(gameObject);
    }
}
