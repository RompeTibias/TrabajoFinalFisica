using UnityEngine;

public class ContadorBalas : MonoBehaviour
{
    TMPro.TextMeshProUGUI contadorBalas;
    void Awake()
    {
        contadorBalas = GetComponent<TMPro.TextMeshProUGUI>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        PlayerShoot playerShoot = FindFirstObjectByType<PlayerShoot>();
        if (playerMove != null)
        {
            contadorBalas.text = playerMove.collected[playerShoot.bulletIndex].ToString();
        }
    }
}
