using UnityEngine;

public class Neg_Pos : MonoBehaviour
{
    public void Producto_negativo()
    {
        CC.ins.CurrentElemento.Valor *= -1;
        CC.ins.CurrentElementoInversa.Valor *= -1;
        CC.ins.CurrentElemento.UpdateText();
        CC.ins.CurrentElementoInversa.UpdateText(); 
    }
}
