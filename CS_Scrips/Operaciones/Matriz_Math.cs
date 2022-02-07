using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// matriz to do oparations of matrizs suma ,resta , producto , division ect
/// </summary>
public class Matriz_Math : MonoBehaviour
{

    public Matriz_UI Suma(Matriz_UI matriz_01, Matriz_UI matriz_02)
    {

        if (matriz_01.Elementos != matriz_02.Elementos)
        {
            Calculate_Controller.instance.mensaje_Error("las matrices deben terner igual columnas y igual Filas");
            return new Matriz_UI();
        }
        else
        {
            var Resultado = new Matriz_UI();

            return Resultado;
        }
        
    }
}

