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
        Calculate_Controller.instance.CurrentElemento.Numero.text += numero;
        Calculate_Controller.instance.CurrentElemento.Valor = int.Parse(Calculate_Controller.instance.CurrentElemento.Numero.text);
    }




}
