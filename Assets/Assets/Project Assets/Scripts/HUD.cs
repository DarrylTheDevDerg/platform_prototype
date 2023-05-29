using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI puntos;
    public GameObject[] vidas;
    private int Vidas = 4;

    void Update()
    {
        if(puntos != null)
        {
            puntos.text = GameManager.Instance.PuntosTotales.ToString();
        }
        
    }

    public void ActualizarPuntos(int puntosTotales)
    {
        puntos.text = puntosTotales.ToString();
    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }

    public void PerderVida()
    {
        Vidas -= 1;
        DesactivarVida(Vidas);

        if (Vidas <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Aquí puedes agregar cualquier acción que desees realizar al perder todas las vidas.
        // Por ejemplo, desactivar el personaje o mostrar un mensaje de game over.
        player.SetActive(false);
    }
}
