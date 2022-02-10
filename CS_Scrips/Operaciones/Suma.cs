using System.Linq;
using UnityEngine;

public class Suma : MonoBehaviour
{
                                                     
    
    public void Sumar()
    {
       var elemt1 = Calculate_Controller.instance.matrizs.First.Value.Elementos.ToArray();
       var eleme2 = Calculate_Controller.instance.matrizs.Last.Value.Elementos.ToArray();
        Calculate_Controller.instance.agregar_matriz();
        var resultado = Calculate_Controller.instance.matrizs.First.Value.Elementos.ToArray();

        for (int i = 0; i < resultado.Length; i++)
        {
            resultado[i].Valor = eleme2[i].Valor + elemt1[i].Valor;
        }
    }



}
