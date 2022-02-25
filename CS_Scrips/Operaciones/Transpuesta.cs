using System.Linq;
using UnityEngine;

public class Transpuesta : MonoBehaviour
{

    public void Invertir()
    {
        var Matriz = Calculate_Controller.instance.matriz_principal;

        switch (Matriz.dimensions)
        {
            case Matriz_UI.Dimensions._1x1:
            case Matriz_UI.Dimensions._2x2:
            case Matriz_UI.Dimensions._3x3:
            case Matriz_UI.Dimensions._4x4:
            case Matriz_UI.Dimensions._5x5:
                InvertValores(Matriz.Elementos.ToArray());
                break;
            default:
                creaMatriz_Incompleta(Matriz);
                InvertValores(Matriz.Elementos.ToArray());
                break;
        }
    }

    private void InvertValores(elemento[] Result)
    {
        var elemFilas = (from nodo in Result orderby nodo.fila select nodo).ToArray();
        var elemColumna = (from nodo in Result orderby nodo.columna select nodo).ToArray();

        for (int i = 0; i < elemColumna.Length; i++)
        {
            elemColumna[i].Valor = elemFilas[i].Valor;
        }
    }
    private void creaMatriz_Incompleta(Matriz_UI matriz)
    {
        byte CopyFila = matriz.fila;
        byte CopyColumna = matriz.columna;

        //muy buena , pude optimizar eliminantod las if y los math

        while (matriz.columna < CopyFila)
        {
            matriz.Agregar_Columna();
        }

        while (matriz.columna > CopyFila)
        {
            matriz.eleminar_Columna();
        }

        while (matriz.fila > CopyColumna)
        {
            matriz.eleminar_Fila();
        }

        while (matriz.fila < CopyColumna)
        {
            matriz.Agregar_Fila();
        }

    }
}