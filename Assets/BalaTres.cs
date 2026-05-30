using UnityEngine;

public class BalaTres : MonoBehaviour
{ 
    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("F"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
