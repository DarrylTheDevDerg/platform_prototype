using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Recordad poned esto para que funcione.

public class cambiodeescenaganar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Escena2"); // Poned aqu� el nombre de vuestra escena.
        }
    }

}