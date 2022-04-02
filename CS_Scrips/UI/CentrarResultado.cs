
using UnityEngine;
using UnityEngine.UI;



public class CentrarResultado : MonoBehaviour
{
    RectTransform result;


    public void Central()
    {
        if (CC.ins.result == null)
        {
            Mensajeria.mensaje_Error("no hay resultado");
            return;
        }

        result = CC.ins.result.GetComponent<RectTransform>();
        result.localPosition = new Vector2(0,0);

        Destroy(CC.ins.matriz_Secundaria.gameObject);
        Destroy(CC.ins.matriz_principal.gameObject);
        CC.ins.matriz_Secundaria = null;
        CC.ins.matriz_principal = null;


    }
}
