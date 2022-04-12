using System.Collections.Generic;
using System.Linq;
using UnityEngine;



/// <summary>
/// clase para administrar los elementos de la calculadora 
/// </summary>

public class CC : MonoBehaviour

{
    public static CC ins;



    public LinkedList<Matriz_UI> matrizs;
    public Matriz_UI matriz_principal;
    public Matriz_UI matriz_Secundaria;
    public Transform father;
    public Matriz_UI matriz_Original;
    public bool IsFloat;

    private void Awake()
    {
        if (ins == null)
        {
            ins = this;

        }
        matrizs = new LinkedList<Matriz_UI>();
        matrizs.AddFirst(matriz_principal);
    }


    //just it would had 3 matriz ; matriz 1 , matriz 2 & resuelt


    public Matriz_UI result;

    public Matriz_UI CurrentMatriz;
    public Matriz_UI CurrentMatrizInversa;
    public elemento CurrentElemento;
    public elemento CurrentElementoInversa;

    public UnityEngine.UI.Text Mensaje_UI;
    public int Celdas_activas { get; internal set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
    public Matriz_UI agregar_matriz()
    {

        if (matrizs.Count > 2)
        {
            Mensajeria.mensaje_Error("ya tienes mas de 2 matrizes");
            return new Matriz_UI();
        }

        var matriz = new Matriz_UI();

        //si no hay secundaria
        if (matriz_Secundaria == null)
        {
            matriz = MonoBehaviour.Instantiate(matriz_principal);
            matriz.inversa = MonoBehaviour.Instantiate(matriz_principal.inversa, father);
            matriz.name = "matrizSecundaria";

            matriz.inversa.name = "InversaSecundaria";
        }

        //si no hay resultado
        else
        {
            matriz = MonoBehaviour.Instantiate(matriz_Secundaria, father);
            matriz.name = "matrizResultado";
            matriz.inversa = MonoBehaviour.Instantiate(matriz_Secundaria.inversa, father);
            matriz.inversa.name = "inversaResult";
        }

        matriz.Move_Matriz(matrizs.Last.Value);
        matrizs.AddLast(matriz);

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
        var matriz = MonoBehaviour.Instantiate(matriz_Original);
        matriz.transform.SetParent(father);
        matriz.transform.position = matriz_principal.CorcheteRigth().position;
        matriz.transform.Translate(Vector2.right * 450);


        return matriz;

    }

    public void ResetMatriz()
    {
        matriz_principal.Reset();

        if (matriz_Secundaria != null)
        {
            matriz_Secundaria.Reset();

        }
        if (result != null)
        {
            result.Reset();

        }
    }
}


public class Agregar_Matriz_UI
{

    public void agregar()
    {
        if (CC.ins.matrizs.Count >= 3)
        {
            Mensajeria.mensaje_Error("ya tienes mas de 3 matrizes");
        }

        var matriz = UnityEngine.MonoBehaviour.Instantiate(CC.ins.matriz_principal);
        matriz.Move_Matriz(CC.ins.matrizs.Last.Value);
        CC.ins.matrizs.AddLast(matriz);

        if (matriz.name.Contains("clone"))
        {
            CC.ins.matriz_Secundaria = matriz;
        }
    }
}

public class Mensajeria
{
    public static void mensaje_Error(string Mensaje)
    {

        Debug.LogError(Mensaje);
        CC.ins.Mensaje_UI.text = Mensaje;
        CC.ins.Mensaje_UI.color = Color.red;
    }

    public static void mensaje(string Mensaje)
    {

        UnityEngine.MonoBehaviour.print(Mensaje);
        CC.ins.Mensaje_UI.text = Mensaje;
        CC.ins.Mensaje_UI.color = Color.white;
    }

}
public class Sumar_Elementos : Organizar_elementos
{
    public static void Sumar(Matriz_UI a, Matriz_UI e)
    {
        var Base = a.Elementos.OrderBy(elem => elem.columna).ToArray();
        var Adiction = e.Elementos.OrderBy(elem => elem.columna).ToArray();

        for (int i = 0; i < Base.Count(); i++)
        {
            Base[i].Valor += Adiction[i].Valor;
        }
    }

}
public class Restar_Elementos : Organizar_elementos
{
    public static void Restar(elemento[] result, elemento[] Secundaria)
    {

        Organizar();
        for (int i = 0; i < result.Length; i++)
        {
            result[i].Valor -= Secundaria[i].Valor;
        }
    }

}

/// <summary>
/// a clase to organize the elements of the matriz
/// </summary>

public abstract class Organizar_elementos
{
    public static elemento[] Result = (from nodo in CC.ins.result.Elementos orderby nodo.columna select nodo).ToArray();
    public static elemento[] Secundaria = (from nodo in CC.ins.matriz_Secundaria.Elementos orderby nodo.columna select nodo).ToArray();
    public static elemento[] principa = (from nodo in CC.ins.matriz_Secundaria.Elementos orderby nodo.columna select nodo).ToArray();

    public static void Organizar()
    {
        Result = (from nodo in CC.ins.result.Elementos orderby nodo.columna select nodo).ToArray();
        Secundaria = (from nodo in CC.ins.matriz_Secundaria.Elementos orderby nodo.columna select nodo).ToArray();
        principa = (from nodo in CC.ins.matriz_Secundaria.Elementos orderby nodo.columna select nodo).ToArray();

    }
}
/// <summary>
/// a clase to multiplicate the elements
/// </summary>

public class Multiplicar_Elementos
{

    public static void Multiplicar_Escalar(elemento[] result, int b)
    {
        for (int i = 0; i < result.Length; i++)
        {
            result[i].Valor *= b;

        }

    }
    public static void Multiplicar()
    {
        //organizo los elementos ;)
        var elem = (from nodo in CC.ins.result.Elementos orderby nodo.fila select nodo).ToArray();

        foreach (var item in CC.ins.result.Elementos)
        {
            item.Valor = Product_filaXcolumnas(item.fila, item.columna);
        }


    }

    private static float Product_filaXcolumnas(int fila, int columna)
    {
        /*
         * result += A11 * B11
         * result += A12 * B12
         * result += A13 * b13
         * c11 = result
         */

        elemento[] seccion1 = (from nodo in CC.ins.matriz_principal.Elementos where nodo.fila == fila orderby nodo.columna select nodo).ToArray();
        elemento[] seccion2 = (from nodo in CC.ins.matriz_Secundaria.Elementos where nodo.columna == columna orderby nodo.fila select nodo).ToArray();

        float resultado = 0;
        for (int i = 0; i < seccion2.Length; i++)
        {
            resultado += seccion1[i].Valor * seccion2[i].Valor;
        }

        return resultado;
    }

}







