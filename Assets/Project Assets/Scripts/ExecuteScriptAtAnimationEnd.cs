using UnityEngine;

public class ExecuteScriptAtAnimationEnd : MonoBehaviour
{
    public Animator animator; // El Animator del objeto que contiene la animaci�n
    public MonoBehaviour scriptToExecute; // El script que deseas ejecutar al final de la animaci�n

    private void Update()
    {
        // Verifica si la animaci�n ha terminado
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            // Ejecuta el script deseado
            if (scriptToExecute != null)
            {
                scriptToExecute.enabled = true;
            }
            else
            {
                Debug.LogWarning("El script para ejecutar no est� asignado.");
            }

            // Desactiva este script para detener la verificaci�n
            enabled = false;
        }
    }
}
