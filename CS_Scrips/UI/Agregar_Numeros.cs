using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
        CC.ins.CurrentElemento.Valor = int.Parse(CC.ins.CurrentElemento.Numero.text);
    }




}
