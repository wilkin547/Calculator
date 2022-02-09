using System.Linq;
using UnityEngine;

public class Suma : MonoBehaviour
{

    
    public void Sumar(Matriz_UI matriz_01, Matriz_UI matriz_02)
    {
        //make a array with the valor 
        elemento[] Elem = (from nodo in matriz_02.Elementos select nodo).ToArray();

        //if the matraz 1 is no equals to matriz 2 , make a fail
        if ((matriz_01.Dimenciones() != matriz_02.Dimenciones()))
        {
            Calculate_Controller.instance.mensaje_Error("las matrices deben terner igual columnas y igual Filas");
        }

        else
        {

            var Resultado = matriz_01;
            var indice = 0;

            foreach (var item in Resultado.Elementos)
            {
                item.Valor = Elem[indice].Valor;
                indice++;
            }

            Resultado.Move_Matriz(matriz_02);
            
        }

    }



}
