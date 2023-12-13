using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    public HUD hud;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private int vidas = 4;
    // Start is called before the first frame update
    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
    public void PerderVida()
    {
        vidas -= 1;
        hud.DesactivarVida(vidas);
        
            Debug.Log("entro a la animacion shake");
        if (animator != null)
        {
            animator.Play("shake");
        }
    }
    public void GanarVida()
    {
        hud.ActivarVida(vidas);
        vidas += 1;

    }
}
