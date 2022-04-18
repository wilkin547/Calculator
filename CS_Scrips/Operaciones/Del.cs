using UnityEngine;

public class Del : MonoBehaviour
{

    public void Borrar()
    {

        CC.ins.ResetMatriz();

        if (CC.ins.matriz_Secundaria != null)
        {

            Destroy(CC.ins.matriz_Secundaria.gameObject);
        }
        
        CC.ins.result = null;

        var Result = GameObject.FindGameObjectWithTag("Result");
        Destroy(Result);
    }

}
