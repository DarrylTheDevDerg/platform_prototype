using UnityEngine;

public class ExecuteScriptAtAnimationEnd : MonoBehaviour
{
    public Animator animator; // El Animator del objeto que contiene la animación
    public MonoBehaviour scriptToExecute; // El script que deseas ejecutar al final de la animación

    private void Update()
    {
        // Verifica si la animación ha terminado
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
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

            // Desactiva este script para detener la verificación
            enabled = false;
        }
    }
}
