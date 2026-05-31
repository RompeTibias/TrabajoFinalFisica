using EasyTransition;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] string sceneName;

    public TransitionSettings fadeTransition;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");

        Debug.Log(TransitionManager.Instance());

        TransitionManager.Instance().Transition(sceneName, fadeTransition, 0);
    }
}
