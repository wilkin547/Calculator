using UnityEngine;
using System.Linq;


public class Determinante : MonoBehaviour
{
    
    public void Determinant()
    {
        
       var elem = Calculate_Controller.instance.agregar_matriz();
           Calculate_Controller.instance.result = elem ;
           Determinete.Determinar();
            
    }
}

public class Determinete : MonoBehaviour
{
    private static int Determinar2x2(Matriz_UI elementos)
    {
        int result = 0;

        elemento[,] elem = new elemento[2,2];

       //organize the elements
        for (int fila = 0; fila < 2; fila++){
            for (int columna = 0; columna < 2; columna++){
                elem[fila,columna] = (from nodo in elementos.Elementos where nodo.columna == columna && nodo.fila == fila select nodo).First();
                Mensajeria.mensaje(elem[fila, columna].name);
            }
        }

        result = (elem[0,0].Valor * elem[1,1].Valor) - (elem[0, 1].Valor * elem[1, 0].Valor);
        return result;
    }
    private static int Determinar3x3(Matriz_UI elementos)
    {
        int result = 0;
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

        result =((elem[0, 0].Valor * elem[1, 1].Valor * elem[2,2].Valor) +
                 (elem[1, 0].Valor * elem[2, 1].Valor * elem[0,2].Valor) +
                 (elem[2, 0].Valor * elem[0, 1].Valor * elem[1,2].Valor)

               - (elem[2, 0].Valor * elem[1, 1].Valor * elem[0, 2].Valor) +
                 (elem[0, 0].Valor * elem[2, 1].Valor * elem[1, 2].Valor) +
                 (elem[1, 0].Valor * elem[0, 1].Valor * elem[2, 2].Valor));
        return result;
    }
    public static void Determinar()
    {
        Mensajeria.mensaje((Determinar2x2(Calculate_Controller.instance.CurrentMatriz)).ToString());

        foreach (var item in Calculate_Controller.instance.result.Elementos)
        {
            item.Valor = Determinar2x2(Calculate_Controller.instance.CurrentMatriz);
        }
    }


}
