using System.Linq;
using UnityEngine;

public class Suma : MonoBehaviour
{
                                                     
    
    public void Sumar()
    {
        Matriz_UI[] elem = new Matriz_UI[2];
        var indice = 0;
        foreach (var item in Calculate_Controller.instance.matrizs)
        {
            elem[indice] = item;
        }
        Calculate_Controller.instance.agregar_matriz();
        var resultado = Calculate_Controller.instance.matrizs.First.Value.Elementos.ToArray();

        for (int i = 0; i < resultado.Length; i++)
        {
            resultado[i].Valor = elem[i].Valor + elem[i].Valor;
        }
    }



}
