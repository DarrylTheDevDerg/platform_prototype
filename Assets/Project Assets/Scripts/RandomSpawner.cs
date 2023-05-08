using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefab; // El objeto que se va a instanciar
    public float minY; // Valor mínimo del rango del eje Y
    public float maxY; // Valor máximo del rango del eje Y
    public float spawnRangeMin; // Valor mínimo del rango del eje X
    public float spawnRangeMax; // Valor máximo del rango del eje X

    void Start()
    {
        Spawn(); // Llama a la función de instanciación cuando el objeto se inicia
    }

    void Spawn()
    {
        float randomX = Random.Range(spawnRangeMin, spawnRangeMax); // Genera un valor aleatorio dentro del rango especificado del eje X
        float randomY = Random.Range(minY, maxY); // Genera un valor aleatorio dentro del rango especificado del eje Y
        Vector3 spawnPosition = new Vector3(randomX, randomY, transform.position.z); // Crea un nuevo vector de posición con el valor aleatorio en el eje Y y el punto de instanciación aleatorio en el eje X
        Instantiate(prefab, spawnPosition, Quaternion.identity); // Instancia el objeto en la nueva posición
    }
}
