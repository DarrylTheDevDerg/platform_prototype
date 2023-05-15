using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float PuntosTotales;

    public HUD hud;

    public void Start()
    {
        Instance = this;
    }

    public void SumarPuntos(int puntosSumar)
    {
        PuntosTotales += puntosSumar;
        hud.ActualizarPuntos((int)PuntosTotales);
    }

}
