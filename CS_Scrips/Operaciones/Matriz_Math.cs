
using System.Linq;
using UnityEngine;

/// <summary>
/// matriz to do oparations of matrizs suma ,resta , producto , division ect
/// </summary>
public class Matriz_Math : MonoBehaviour
{

    public Matriz_UI Suma(Matriz_UI matriz_01, Matriz_UI matriz_02)
    {
        //make a array with the valor 
        elemento[] Elem = (from nodo in matriz_02.Elementos select nodo).ToArray();

        //if the matraz 1 is no equals to matriz 2 , make a fail
        if ((matriz_01.fila != matriz_02.fila) && (matriz_01.columna != matriz_02.columna))
        {
            Calculate_Controller.instance.mensaje_Error("las matrices deben terner igual columnas y igual Filas");
            return new Matriz_UI();
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
            return Resultado;
        }
        
    }


}

