using UnityEngine;
using System.Collections.Generic;



/// <summary>
/// clase para administrar los elementos de la calculadora 
/// </summary>

public class Calculate_Controller : MonoBehaviour
{

    public static Calculate_Controller instance;
    public Stack<Matriz_UI> matrizs;
    public Matriz_UI matriz_principal;
    private void Awake()
    {
        if (Calculate_Controller.instance != null)
        {
            Calculate_Controller.instance = this;
        }

        matrizs = new Stack<Matriz_UI>();
        matrizs.Push(matriz_principal);
    }

    //just it would had 3 matriz ; matriz 1 , matriz 2 & resuelt

    
    public Matriz_UI result;

    public Matriz_UI CurrentMatriz;
    public elemento CurrentElemento;

    public UnityEngine.UI.Text Mensaje_UI;
    public int Celdas_activas { get; internal set; }

    public void mensaje (string Mensaje) { 
        
        print(Mensaje); 
        Mensaje_UI.text = Mensaje;
        Mensaje_UI.color = Color.white;
    }

    public void agregar_matriz()
    {
        if (matrizs.Count >= 3){
        
            mensaje_Error("ya tienes mas de 2 matrizes");
            return;
        }
        var matriz = Instantiate(matriz_principal);
        matriz.Move_Matriz(matrizs.Peek());
        matrizs.Push(matriz);
        
    }

    public void mensaje_Error(string Mensaje)
    {

        print(Mensaje);
        Mensaje_UI.text = Mensaje;
        Mensaje_UI.color = Color.white;
    }



}





