using UnityEngine;

public class DesactivarObjetoDespuesDeTiempo : MonoBehaviour
{
    public float tiempoDesactivar = 2.0f;

    void Start()
    {
        // Llama a la funci�n DesactivarObjeto() despu�s del tiempo especificado
        Invoke("DesactivarObjeto", tiempoDesactivar);
    }

    void DesactivarObjeto()
    {
        // Desactiva este objeto
        gameObject.SetActive(false);
    }
}
