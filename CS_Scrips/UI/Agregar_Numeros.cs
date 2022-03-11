using UnityEngine;
using UnityEngine.UI;


public class Agregar_Numeros : MonoBehaviour
{
    private string numero;

    private void Start()
    {
        numero = name;
        GetComponent<Button>().onClick.AddListener(Agregar);
    }

    private void Agregar()
    {
        CC.ins.CurrentElemento.Numero.text += numero;
        CC.ins.CurrentElementoInversa.Numero.text += numero;
        CC.ins.CurrentElemento.Valor = int.Parse(CC.ins.CurrentElemento.Numero.text);
        CC.ins.CurrentElementoInversa.Valor = int.Parse(CC.ins.CurrentElementoInversa.Numero.text);
    }




}
