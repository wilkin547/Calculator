using UnityEngine;


/// <summary>
/// clase para administrar los elementos de la calculadora 
/// </summary>

public class Calculate_Controller : MonoBehaviour
{

    public static Calculate_Controller instance;

    private void Awake()
    {
        if (Calculate_Controller.instance != null)
        {
            Calculate_Controller.instance = this;
        }
    }

    //just it would had 3 matriz ; matriz 1 , matriz 2 & resuelt

    public Matriz_UI[] matrizs;
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


    public void mensaje_Error(string Mensaje)
    {

        print(Mensaje);
        Mensaje_UI.text = Mensaje;
        Mensaje_UI.color = Color.white;
    }



}





