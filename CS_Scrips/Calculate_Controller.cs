using System.Collections.Generic;
using System.Linq;
using UnityEngine;



/// <summary>
/// clase para administrar los elementos de la calculadora 
/// </summary>

public class Calculate_Controller : MonoBehaviour
{

    public static Calculate_Controller instance;
    public LinkedList<Matriz_UI> matrizs;
    public Matriz_UI matriz_principal;
    public Matriz_UI matriz_Secundaria;

    public Matriz_UI matriz_Original;
    private void Awake()
    {
        if (Calculate_Controller.instance == null)
        {
            Calculate_Controller.instance = this;

        }
        matrizs = new LinkedList<Matriz_UI>();
        matrizs.AddFirst(matriz_principal);

    }


    //just it would had 3 matriz ; matriz 1 , matriz 2 & resuelt


    public Matriz_UI result;

    public Matriz_UI CurrentMatriz;
    public elemento CurrentElemento;

    public UnityEngine.UI.Text Mensaje_UI;
    public int Celdas_activas { get; internal set; }


    public Matriz_UI agregar_matriz()
    {
        
        if (matrizs.Count > 2)
        {
            Mensajeria.mensaje_Error("ya tienes mas de 2 matrizes");
            return new Matriz_UI();
        }
        var matriz = Instantiate(matriz_principal);
        matriz.Move_Matriz(matrizs.Last.Value);
        matrizs.AddLast(matriz);

        if (matrizs.Count == 2)
        {
            matriz_Secundaria = matriz;
        }
        return matriz;
        
    }


    /// <summary>
    /// a matriz to the determinants
    /// </summary>
    /// <returns></returns>
    public Matriz_UI agregar_matriz_original()
    {

        if (matrizs.Count > 2)
        {
            Mensajeria.mensaje_Error("ya tienes mas de 2 matrizes");
            return new Matriz_UI();
        }
        var matriz = Instantiate(matriz_Original);
        matriz.transform.position = CurrentMatriz.transform.position;
        matriz.Move_Matriz(matrizs.Last.Value);
        

        return matriz;

    }

}
 
public class Agregar_Matriz_UI{

    public void agregar()
    {
        if (Calculate_Controller.instance.matrizs.Count >= 3)
        {
            Mensajeria.mensaje_Error ("ya tienes mas de 3 matrizes");
        }

        var matriz = UnityEngine.MonoBehaviour.Instantiate(Calculate_Controller.instance.matriz_principal);
        matriz.Move_Matriz(Calculate_Controller.instance.matrizs.Last.Value);
        Calculate_Controller.instance.matrizs.AddLast(matriz);

        if (matriz.name.Contains("clone"))
        {
            Calculate_Controller.instance.matriz_Secundaria = matriz;
        }
    }
}


public class Mensajeria
{
    public static void mensaje_Error(string Mensaje)
    {

        Debug.LogError(Mensaje);
        Calculate_Controller.instance.Mensaje_UI.text = Mensaje;
        Calculate_Controller.instance.Mensaje_UI.color = Color.red;
    }

    public static void mensaje(string Mensaje)
    {

        UnityEngine.MonoBehaviour.print(Mensaje);
        Calculate_Controller.instance.Mensaje_UI.text = Mensaje;
        Calculate_Controller.instance.Mensaje_UI.color = Color.white;
    }
    
}
public class Sumar_Elementos
{
    public static void Sumar(elemento[] result, elemento[] b)
    {

        for (int i = 0; i < result.Length; i++)
        {
            result[i].Valor += b[i].Valor;

        }
    }

}

public class Restar_Elementos
{
    public static void Restar(elemento[] result, elemento[] b)
    {

        for (int i = 0; i < result.Length; i++)
        {
            result[i].Valor -= b[i].Valor;

        }
    }

}

public class Multiplicar_Elementos
{

    public static void Multiplicar_Escalar(elemento[] result, int b)
    {
        for (int i = 0; i < result.Length; i++)
        {
            result[i].Valor *= b;

        }

    }
    public static void Multiplicar(elemento[] result, elemento[] A , elemento[] B)
    {
        //organizo los elementos ;)
        var elem = (from nodo in result orderby nodo.fila select nodo).ToArray(); 
        foreach (var item in result){
            item.Valor = product_filaXcolumnas(A,B,item.fila,item.columna);
        }


    }

    private static int product_filaXcolumnas(elemento[] matriz1, elemento[] matriz2, int fila, int columna)
    {
        /*
         * result += A11 * B11
         * result += A12 * B12
         * result += A13 * b13
         * c11 = result
         */

        elemento[] seccion1 = (from nodo in matriz1 where nodo.columna == columna orderby nodo.fila select nodo).ToArray();
        elemento[] seccion2 = (from nodo in matriz2 where nodo.fila == fila orderby nodo.columna select nodo).ToArray();

        int resultado = 0;
        for (int i = 0; i < seccion2.Length; i++)
        {
                resultado += seccion1[i].Valor * seccion2[i].Valor;    
        }

        return resultado;   
    }

}





