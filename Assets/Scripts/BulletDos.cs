using UnityEngine;

public class BulletDos : MonoBehaviour
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
        if (collision.gameObject.CompareTag("I"))
        {

            collision.gameObject.GetComponent<Interactable>().Interact();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMove player = FindFirstObjectByType<PlayerMove>();

            if (player != null)
            {
                player.CollectItem(1);
            }
        }
        Destroy(gameObject);
    }
}

