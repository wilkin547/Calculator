using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    List<CC> Pasos = new List<CC>();

    private void Awake()
    {
        guardarDatos();
    }


    public void Borrar()
    {
       
        CC.ins.matriz_principal.reset();
        CC.ins.matriz_Secundaria.reset();
        CC.ins.matriz_principal.Elementos.First.Value.reset();
        CC.ins.matriz_Secundaria.Elementos.First.Value.reset();

        if (CC.ins.result != null)
        {

        Destroy(CC.ins.result.gameObject);
        }
        Destroy(CC.ins.matriz_Secundaria.gameObject);
        Destroy(CC.ins.result.gameObject);
    }
    public void guardarDatos()
    {
        Pasos.Add( (CC)CC.ins.Clone() );
    }
}
