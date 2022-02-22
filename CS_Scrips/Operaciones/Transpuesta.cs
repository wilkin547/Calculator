using UnityEngine;
using System.Collections.Generic;

public class Transpuesta : MonoBehaviour
{

    public void Invertir(Matriz_UI matriz_Ui )
    {
        Queue<elemento> queue = new Queue<elemento>(matriz_Ui.Elementos);
        

        foreach (var elemento in matriz_Ui.Elementos)
        {
            elemento.Valor = queue.Dequeue().Valor;
            Calculate_Controller.instance.mensaje("se acaba de hacer una inversa");
        }
    }
}