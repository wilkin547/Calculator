using System.Linq;
using UnityEngine;

public class Suma : MonoBehaviour
{
                                                     
    
    public void Sumar()
    {
        
        if (Calculate_Controller.instance.matriz_Secundaria == null){
            Calculate_Controller.instance.matriz_Secundaria = Calculate_Controller.instance.agregar_matriz();
            Mensajeria.mensaje("se agrego la matriz secundaria");
            return;
        }
        if ( Calculate_Controller.instance.result == null){
            Calculate_Controller.instance.result = Calculate_Controller.instance.agregar_matriz();
            Mensajeria.mensaje("se agrego el resultado");
            
        }

        Sumar_Elementos.Sumar(Calculate_Controller.instance.result.Elementos.ToArray(), Calculate_Controller.instance.matriz_Secundaria.Elementos.ToArray());

        foreach (var item in Calculate_Controller.instance.result.Elementos){
            item.Numero.text = item.Valor.ToString();
        }

    }

    private void CompruebaMatrices()
    {
        


    }

}
