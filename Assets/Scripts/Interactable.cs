using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string namee;
    [SerializeField] private GameObject target;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact()
    {
        Interaxtion(namee);
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
}
