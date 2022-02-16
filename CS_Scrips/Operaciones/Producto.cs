using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producto : MonoBehaviour
{
    
    public void Multiplicar()
    {
        if (!(Calculate_Controller.instance.matriz_principal.columna == Calculate_Controller.instance.matriz_principal.fila)){
            Calculate_Controller.instance.mensaje_Error("la columna de la matriz A debe ser igual a las filas de la matriz B");
            return;
        }
        
    }

    public void Multiplicar_escalar()
    {

    } 
}
