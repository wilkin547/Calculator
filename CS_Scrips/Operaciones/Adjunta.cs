using UnityEngine;
using System.Linq;
using System.Collections;
using System;

public class Adjunta : MonoBehaviour
{
    
    
    //everything corret

    public void adjuntat()
    {
        switch (CC.ins.matriz_principal.dimensions)
        {
            case Matriz_UI.Dimensions._1x1:
            case Matriz_UI.Dimensions._2x2:
                
                
                break;
            case Matriz_UI.Dimensions._3x3:

                var result = CC.ins.agregar_matriz();
                CC.ins.matriz_Secundaria = result;
                var elem = from nodo in result.Elementos orderby nodo.fila select nodo;
                foreach (var item in elem)
                {
                    item.Valor = 0;
                    item.Numero.text = "";

                    item.Valor = Adjuntar3x3(CC.ins.matriz_principal,item);
                    item.Valor *= (int)Math.Pow(-1, 1 + item.fila + item.columna);
                    
                    item.Numero.text += item.Valor.ToString();

                }

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


    private int Adjuntar3x3(Matriz_UI UI,elemento e)
    {

        var elem = (from nodo in UI.Elementos where nodo.columna != e.columna && nodo.fila != e.fila orderby  nodo.fila ascending select nodo).ToArray();
        int result = Determinete.Determinar2x2(elem);

        return result;

    }


}
