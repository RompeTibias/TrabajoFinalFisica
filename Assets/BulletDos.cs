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
            PlayerMove player = FindFirstObjectByType<PlayerMove>();

            if (player != null)
            {
                player.CollectItem(1);
            }

            collision.gameObject.GetComponent<Interactable>().Interact();
        }
        Destroy(gameObject);
    }
}

