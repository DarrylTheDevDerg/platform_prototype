using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int maxLives = 4;
    private int currentLives;

    private void Start()
    {
        currentLives = maxLives;
    }

    private void Update()
    {
        if (currentLives <= 0)
        {
            Die();
        }
    }

    public void LoseLife()
    {
        currentLives--;
    }

    private void Die()
    {
        // Aquí puedes agregar cualquier acción que desees realizar al perder todas las vidas.
        // Por ejemplo, desactivar el personaje o mostrar un mensaje de game over.
        gameObject.SetActive(false);
    }
}
