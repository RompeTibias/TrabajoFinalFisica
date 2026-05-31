using EasyTransition;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] string sceneName;

    public TransitionSettings fadeTransition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TransitionManager.Instance().Transition(sceneName, fadeTransition, 0);
        }
    }
}
