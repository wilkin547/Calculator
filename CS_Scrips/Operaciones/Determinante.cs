using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Determinante : MonoBehaviour
{
    
    public void Determinant()
    {

       var elem = Instantiate(Calculate_Controller.instance.matriz_Original);
    }
}
public class Determinete
{
    public static void Determinar(Matriz_UI ui,elemento result)
    {
        if (ui.dimensions != Matriz_UI.Dimensions.Incomplete){
            Calculate_Controller.instance.mensaje_Error("la matriz debe ser completa");
            return;
        }

        elemento[,] elem = new elemento[(int)Mathf.Sqrt(ui.Elementos.Count), (int)Mathf.Sqrt(ui.Elementos.Count)];
        foreach (var item in ui.Elementos){
            elem[item.fila, item.columna] = item;
        }

        switch (ui.dimensions) {
            case Matriz_UI.Dimensions._1x1:
                result.Valor = elem[0, 0].Valor;
                break;

            case Matriz_UI.Dimensions._2x2:
                /* [a00,a01]
                 * [a10,a11]
                 */

                var a = 0;
                a += (elem[0, 0].Valor * elem[1, 1].Valor) - (elem[0, 1].Valor * elem[1, 0].Valor);
                result.Valor = a;

                break;
            case Matriz_UI.Dimensions._3x3:
                /* [a00,a01,a02]
                 * [a10,a11,a12]
                 * [a20,a21,a22]
                            */

                a = 0;
                a += (
                      (elem[0, 0].Valor * elem[1, 1].Valor * elem[2, 2].Valor)
                    + (elem[1, 0].Valor * elem[2, 1].Valor * elem[0, 2].Valor)
                    + (elem[2, 0].Valor * elem[0, 1].Valor * elem[1, 2].Valor))
                    -
                     (
                      (elem[0, 2].Valor * elem[1, 1].Valor * elem[2, 0].Valor)
                    + (elem[1, 2].Valor * elem[2, 1].Valor * elem[0, 0].Valor)
                    + (elem[2, 2].Valor * elem[0, 1].Valor * elem[1, 0].Valor));
                result.Valor = a;
                break;
            case Matriz_UI.Dimensions._4x4:
                break;
            case Matriz_UI.Dimensions._5x5:
                break;
            case Matriz_UI.Dimensions.Incomplete:
                break;
            default:
                break;
        }
    }
}
