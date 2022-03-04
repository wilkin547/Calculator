using UnityEngine;

//clase to use the same buttun to create more matriz
public class ComprobarMatrizes : MonoBehaviour
{
    public virtual void operar()
    {
        if (CC.ins.matriz_Secundaria == null)
        {
            CC.ins.matriz_Secundaria = CC.ins.agregar_matriz();
            Mensajeria.mensaje("se agrego la matriz secundaria");
            return;
        }
        if (CC.ins.result == null)
        {
            CC.ins.result = CC.ins.agregar_matriz();
            Mensajeria.mensaje("se agrego el resultado");

        }
    }

}
