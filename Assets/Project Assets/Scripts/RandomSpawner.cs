using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefab; // El objeto que se va a instanciar
    public float minY; // Valor m�nimo del rango del eje Y
    public float maxY; // Valor m�ximo del rango del eje Y
    public float respawnXMin; // Valor m�nimo del rango del eje X
    public float respawnXMax; // Valor m�ximo del rango del eje X
    public int maxRespawns = 5; // Cantidad m�xima de respawns
    private int respawnCount = 0; // Contador de respawns realizados

    void Start()
    {
        Respawn();
    }

    void Respawn()
    {
        if (respawnCount >= maxRespawns)
        {
            // Se alcanz� la cantidad m�xima de respawns, no se hace nada
            return;
        }

        float randomX = Random.Range(respawnXMin, respawnXMax); // Genera un valor aleatorio dentro del rango especificado del eje X
        float randomY = Random.Range(minY, maxY); // Genera un valor aleatorio dentro del rango especificado del eje Y
        Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z); // Crea un nuevo vector de posici�n con el valor aleatorio en el eje Y y el punto de respawn aleatorio en el eje X
        Instantiate(prefab, spawnPosition, Quaternion.identity); // Instancia el objeto en la nueva posici�n

        respawnCount++; // Incrementa el contador de respawns
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject); // Destruye el objeto colisionado

            // Realiza el respawn despu�s de un tiempo determinado
            Invoke("Respawn", 1f);
        }
    }
}
