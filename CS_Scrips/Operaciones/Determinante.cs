using System.Linq;
using UnityEngine;


public class Determinante : MonoBehaviour
{
    public Transform canvas;
    public void Determinant()
    {


        if (CC.ins.matriz_principal.dimensions == Matriz_UI.Dimensions.Incomplete) return;
        if (CC.ins.result != null) return;

        var elem = CC.ins.agregar_matriz_original();
        CC.ins.result = elem;
        elem.transform.parent = canvas;
        CC.ins.result = elem;
        Determinete.Determinar();

    }
}

public class Determinete : MonoBehaviour
{
    public static float Determinar2x2(Matriz_UI elementos)
    {
        elemento[,] elem = new elemento[2, 2];

        //organize the elements
        for (int fila = 0; fila < 2; fila++)
        {
            for (int columna = 0; columna < 2; columna++)
            {
                elem[fila, columna] = (from nodo in elementos.Elementos where nodo.columna == columna && nodo.fila == fila select nodo).First();
            }
        }

        float result = (elem[0, 0].Valor * elem[1, 1].Valor) - (elem[0, 1].Valor * elem[1, 0].Valor);
        return result;
    }
    public static float Determinar2x2(elemento[] e)
    {
        float result = ((e[0].Valor * e[3].Valor) - (e[1].Valor * e[2].Valor));
        return result;
    }
    private static float Determinar3x3(Matriz_UI elementos)
    {
        float result = 0;
        elemento[,] elem = new elemento[3, 3];

        //organize the elements
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                elem[fila, columna] = (from nodo in elementos.Elementos where nodo.columna == columna && nodo.fila == fila select nodo).First();
                Mensajeria.mensaje(elem[fila, columna].name);
            }
        }

        result = ((elem[0, 0].Valor * elem[1, 1].Valor * elem[2, 2].Valor) +
                 (elem[1, 0].Valor * elem[2, 1].Valor * elem[0, 2].Valor) +
                 (elem[2, 0].Valor * elem[0, 1].Valor * elem[1, 2].Valor)

               - (elem[2, 0].Valor * elem[1, 1].Valor * elem[0, 2].Valor) +
                 (elem[0, 0].Valor * elem[2, 1].Valor * elem[1, 2].Valor) +
                 (elem[1, 0].Valor * elem[0, 1].Valor * elem[2, 2].Valor));
        return result;
    }
    public static void Determinar()
    {
        Mensajeria.mensaje((Determinar2x2(CC.ins.CurrentMatriz)).ToString());

        foreach (var item in CC.ins.result.Elementos)
        {
            switch (CC.ins.CurrentMatriz.dimensions)
            {
                case Matriz_UI.Dimensions._1x1:

                    break;
                case Matriz_UI.Dimensions._2x2:
                    item.Valor = Determinar2x2(CC.ins.CurrentMatriz);

                    break;
                case Matriz_UI.Dimensions._3x3:
                    item.Valor = Determinar3x3(CC.ins.CurrentMatriz);
                    break;
                case Matriz_UI.Dimensions._4x4:
                    break;
                case Matriz_UI.Dimensions._5x5:
                    break;
                case Matriz_UI.Dimensions.Incomplete:
                    Mensajeria.mensaje_Error("error , la matriz debe ser cuadrada : 2x2 , 3x3 , 4x4");
                    break;
                default:

                    break;
            }
            item.Numero.text = item.Valor.ToString();

        }
    }


}
