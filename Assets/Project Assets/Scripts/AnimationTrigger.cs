using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator animator; // Referencia al componente Animator
    private bool hasCollided = false; // Indica si ya ha ocurrido una colisi�n

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided && collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("ActivateAnimation"); // Activa la animaci�n

            hasCollided = true; // Marca la colisi�n como ocurrida
        }
    }
}
