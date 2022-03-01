using System.Linq;
using UnityEngine;

public class Suma : MonoBehaviour
{
                                                     
    
    public void Sumar()
    {

        var resultado = Calculate_Controller.instance.agregar_matriz();
        Sumar_Elementos.Sumar(resultado.Elementos.ToArray(), Calculate_Controller.instance.matrizs.Last.Value.Elementos.ToArray());

        foreach (var item in resultado.Elementos){
            item.Numero.text = item.Valor.ToString();
        }

    }



}
