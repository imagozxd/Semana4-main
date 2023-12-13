using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator camShake;
    public void CamShake()
    {
        camShake.Play("shake");
    }
}
