using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public GameManager gameManager;

    public Shake shake;

    public float raycastDistance = 10f;
    [SerializeField] private Color rayDebugColor = Color.red;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shake.CamShake();
            gameManager.PerderVida();
            Debug.Log("contra enemi");
        }
    }

    private void Update()
    {
        // Lanzar un raycast hacia abajo desde la posición del objeto Enemigo1
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit,raycastDistance))
        {
            Debug.DrawLine(transform.position, hit.point, rayDebugColor);

            // Verificar si el objeto golpeado es el jugador
            if (hit.collider.CompareTag("Player"))
            {
                // Realizar acciones cuando el Player está cerca
                Debug.Log("Player está cerca");
                // Puedes agregar más acciones aquí según tus necesidades
            }
        }

    }
}
