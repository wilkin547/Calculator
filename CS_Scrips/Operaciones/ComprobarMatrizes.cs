using UnityEngine;

//clase to use the same buttun to create more matriz
public class ComprobarMatrizes : MonoBehaviour
{
    public virtual void operar()
    {
        if (Calculate_Controller.instance.matriz_Secundaria == null)
        {
            Calculate_Controller.instance.matriz_Secundaria = Calculate_Controller.instance.agregar_matriz();
            Mensajeria.mensaje("se agrego la matriz secundaria");
            return;
        }
        if (Calculate_Controller.instance.result == null)
        {
            Calculate_Controller.instance.result = Calculate_Controller.instance.agregar_matriz();
            Mensajeria.mensaje("se agrego el resultado");

        }
    }
}
