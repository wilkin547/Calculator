using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    List<CC> Pasos = new List<CC>();
    public void Awake()
    {
        var pas = new CC();

        pas = CC.ins;
        Pasos.Add(pas);
    }
    public void Borrar()
    {
        CC.ins = Pasos[0];
        
    }
}
