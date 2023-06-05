using UnityEngine;

public class DelayedScriptExecution : MonoBehaviour
{
    public MonoBehaviour scriptToExecute; // El script que deseas ejecutar
    public float delayInSeconds = 3f; // El tiempo de retraso en segundos

    private float timer = 0f;
    private bool executionStarted = false;

    private void Update()
    {
        // Comienza a contar el tiempo cuando se activa el script
        if (!executionStarted)
        {
            timer += Time.deltaTime;
            if (timer >= delayInSeconds)
            {
                ExecuteScript();
            }
        }
    }

    private void ExecuteScript()
    {
        // Ejecuta el script deseado
        if (scriptToExecute != null)
        {
            scriptToExecute.enabled = true;
        }
        else
        {
            Debug.LogWarning("El script para ejecutar no está asignado.");
        }

        // Desactiva este script para detener el contador de tiempo
        enabled = false;
    }
}
