using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 2f;

    private Transform target;
    private bool moverHaciaA = true;

    private void Start()
    {
        target = puntoA; // Inicia el movimiento hacia el punto A
    }

    private void Update()
    {
        // Mueve al enemigo hacia el objetivo actual (punto A o punto B)
        transform.position = Vector2.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);

        // Si el enemigo llega al punto A, cambia el objetivo al punto B
        if (Vector2.Distance(transform.position, puntoA.position) < 0.1f)
        {
            target = puntoB;
        }
        // Si el enemigo llega al punto B, cambia el objetivo al punto A
        else if (Vector2.Distance(transform.position, puntoB.position) < 0.1f)
        {
            target = puntoA;
        }
    }
}
