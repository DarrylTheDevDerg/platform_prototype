using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    public int maxLives = 4;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
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

    private void Die() => SceneManager.LoadScene(sceneName: "Game Over");
}
