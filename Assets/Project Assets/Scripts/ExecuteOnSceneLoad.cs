using UnityEngine;
using UnityEngine.SceneManagement;

public class ExecuteOnSceneLoad : MonoBehaviour
{
    public GameObject elementToExecute; // El elemento que deseas ejecutar al cargar la escena

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Ejecuta el elemento deseado
        if (elementToExecute != null)
        {
            elementToExecute.SetActive(true);
        }
        else
        {
            Debug.LogWarning("El elemento para ejecutar no está asignado.");
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
