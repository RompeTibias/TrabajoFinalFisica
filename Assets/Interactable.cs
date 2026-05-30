using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private string namee;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
