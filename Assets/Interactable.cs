using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string namee;

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
        switch(name)
        {
            case "Door":
                Debug.Log("You opened the door");
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
