using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public float distanciaPatrullada = 5f; // Distancia total a patrullar
    public float speed = 2f; // Velocidad de movimiento
    private Vector3 posInicial; // Posición inicial del enemigo
    private Vector3 posFinal; // Posición objetivo de patrullaje
    private bool mov = true; // Variable para controlar la dirección del movimiento
    public GameManager gameManager;

    void Start()
    {
        posInicial = transform.position;
        posFinal = posInicial + Vector3.right * distanciaPatrullada;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //shake.CamShake();
            gameManager.PerderVida();
            Debug.Log("contra enemi");
        }
    }

    void Update()
    {
        // Mueve al enemigo hacia el objetivo de patrullaje
        Vector3 currentPosition = transform.position;
        float step = speed * Time.deltaTime;

        if (mov)
            transform.position = Vector3.MoveTowards(currentPosition, posFinal, step);
        else
            transform.position = Vector3.MoveTowards(currentPosition, posInicial, step);

        // Si el enemigo llega al objetivo, cambia la dirección
        if (Vector3.Distance(currentPosition, posFinal) < 0.01f)
        {
            if (mov)
            {
                posFinal = posInicial;
                mov = false;
            }
            else
            {
                posFinal = posInicial + Vector3.right * distanciaPatrullada;
                mov = true;
            }
        }
    }

}
