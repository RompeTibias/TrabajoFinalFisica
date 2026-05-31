using UnityEditor;
using UnityEngine;

public class ALTEFECUATRO : MonoBehaviour
{
    [SerializeField] GameObject nucleo;

    void Update()
    {
        if (nucleo == null)
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
