using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float velocidadMovimiento;
    private int siguentePlataforma = 1;
    private bool ordenPlataformas = true;

    private void Update()
    { 
        if(ordenPlataformas && siguentePlataforma + 1 >= puntosMovimiento.Length)
        { 
            ordenPlataformas = false; 
        }
        if (!ordenPlataformas && siguentePlataforma <= 0)
        {
            ordenPlataformas = true;
        }

        if (Vector2.Distance(transform.position, puntosMovimiento[siguentePlataforma].position) < 0.1)
        { 
             if(ordenPlataformas)
             {
                 siguentePlataforma +=1;
             }
             else
             { 
                 siguentePlataforma -=1; 
             }
        }
    
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguentePlataforma].position, velocidadMovimiento * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {

        if (other.gameObject.CompareTag("Player"))
        { 
            other.transform.SetParent(this.transform);
        }
    } 
    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player")) 
        {
            other.transform.SetParent(null);
        }
    }


    
}
