using UnityEngine;
using UnityEngine.UI;


public class Agregar_Numeros : MonoBehaviour
{
    private string numero;

    private void Start()
    {
        numero = name;
        if (name == "coma")
        {
            return;
        }
        GetComponent<Button>().onClick.AddListener(Agregar);
    }

    public void Agregar()
    {
        CC.ins.CurrentElemento.Numero.text += numero;
        CC.ins.CurrentElementoInversa.Numero.text += numero;
        CC.ins.CurrentElemento.Valor = float.Parse(CC.ins.CurrentElemento.Numero.text);
        CC.ins.CurrentElementoInversa.Valor = float.Parse(CC.ins.CurrentElementoInversa.Numero.text);
        
    }

    public void agregarComa()
    {
        CC.ins.CurrentElemento.Numero.text += ".";
        CC.ins.CurrentElementoInversa.Numero.text += ".";
        
    }

    




}
