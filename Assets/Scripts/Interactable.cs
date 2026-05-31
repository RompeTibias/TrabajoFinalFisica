using System.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string namee;
    [SerializeField] private GameObject target;

    [SerializeField] private Transform target2;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float velocidad = 2f;

    private Vector3 posicionInicial;
    private Vector3 posicionFinal;
    private bool movida = false;
    private bool moviendo = false;

    void Start()
    {
        posicionInicial = target2.position;
        posicionFinal = posicionInicial + offset;
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        Interaxtion(namee);
        MoverPlataforma();
    }

    void Interaxtion(string name)
    {
        switch (name)
        {
            case "Boton":
                HingeJoint hinge = target.GetComponent<HingeJoint>();
                target.GetComponent<Rigidbody>().isKinematic = false;

                if (hinge == null)
                {
                    Debug.LogWarning("El target no tiene HingeJoint");
                    return;
                }

                JointMotor motor = hinge.motor;
                motor.force = 2900f;
                motor.targetVelocity = 100f;
                motor.freeSpin = false;

                hinge.motor = motor;
                hinge.useMotor = true;

                break;

            case "Chest":
                Debug.Log("You opened the chest");
                break;

            default:
                Debug.Log("Nothing to interact with");
                break;
        }
    }

    public void MoverPlataforma()
    {
        if (moviendo) return;

        Vector3 destino = movida ? posicionInicial : posicionFinal;
        StartCoroutine(Mover(destino));

        movida = !movida;
    }

    private IEnumerator Mover(Vector3 destino)
    {
        moviendo = true;

        while (Vector3.Distance(target2.position, destino) > 0.01f)
        {
            target2.position = Vector3.MoveTowards(
                target2.position,
                destino,
                velocidad * Time.deltaTime
            );

            yield return null;
        }

        target2.position = destino;
        moviendo = false;
    }
}
