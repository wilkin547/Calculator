
using System.Linq;
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
        CC.ins.result.name = "Matriz Principal";
        CC.ins.result.inversa.name = "InversaPrincipal";

 
        Destroy(CC.ins.matriz_Secundaria.gameObject);
        Destroy(CC.ins.matriz_Secundaria.inversa.gameObject);
        Destroy(CC.ins.matriz_principal.inversa.gameObject);
        Destroy(CC.ins.matriz_principal.gameObject);

        CC.ins.matriz_principal = (Matriz_UI)CC.ins.result.Clone();

        CC.ins.CurrentMatriz = CC.ins.matriz_principal;
        CC.ins.CurrentMatrizInversa = CC.ins.matriz_principal.inversa;

        CC.ins.matrizs.Clear();
        CC.ins.matrizs.AddFirst(CC.ins.result);
        CC.ins.result = null;  
        if (CC.ins.CurrentElemento == null)
        {
            CC.ins.CurrentElemento = CC.ins.matriz_principal.Elementos.First.Value;
            CC.ins.CurrentElemento.UpdateCurrentMatriz();
        }


    }
}
