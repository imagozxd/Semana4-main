using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    public float rangoDeteccion = 10f; 
    public float velocidadPersecucion = 5f; 
    public Transform jugador; 
    private bool jugadorDetectado = false; 
    public GameManager gameManager;

    void Update()
    {
        // Dispara un rayo en la dirección del jugador
        Ray rayo = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        // Comprueba si el rayo colisiona con un objeto
        if (Physics.Raycast(rayo, out hitInfo, rangoDeteccion))
        {
            // Comprueba si el objeto colisionado tiene la etiqueta "Player"
            if (hitInfo.collider.CompareTag("Player"))
            {
                // Almacena la referencia al jugador
                jugador = hitInfo.collider.transform;
                jugadorDetectado = true;
            }
        }
        else
        {
            // Si el rayo no colisiona con nada, no se detecta al jugador
            jugadorDetectado = false;
        }

        // Si el jugador ha sido detectado, persigue al jugador
        if (jugadorDetectado)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;
            Debug.Log("lo vio");

            // Calcula la nueva posición del enemigo
            Vector3 nuevaPosicion = transform.position + direccionAlJugador * velocidadPersecucion * Time.deltaTime;
            Debug.Log("nueva pos");

            // Mueve al enemigo hacia la nueva posición
            transform.position = nuevaPosicion;
            Debug.Log("persiguiendo");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            gameManager.PerderVida();
            Debug.Log("contra enemi");
        }
    }
}
