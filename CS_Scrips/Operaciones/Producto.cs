using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Producto : MonoBehaviour
{
    
    public void Multiplicar()
    {
        if (!(Calculate_Controller.instance.matriz_principal.columna == Calculate_Controller.instance.matriz_principal.fila)){
            Mensajeria.mensaje_Error("la columna de la matriz A debe ser igual a las filas de la matriz B");
            return;
        }

        Matriz_UI p1 = Instantiate(Calculate_Controller.instance.matriz_Original, GameObject.FindGameObjectWithTag("UI").transform);

        while (p1.columna >= Calculate_Controller.instance.matriz_principal.columna){
            p1.Agregar_Columna();
        }

        while (p1.fila >= Calculate_Controller.instance.matriz_Secundaria.fila){
            p1.Agregar_Fila();
        }

        p1.Move_Matriz(Calculate_Controller.instance.matriz_Secundaria);

        Multiplicar_Elementos.Multiplicar(p1.Elementos.ToArray(), Calculate_Controller.instance.matriz_principal.Elementos.ToArray(), Calculate_Controller.instance.matriz_Secundaria.Elementos.ToArray());
        Calculate_Controller.instance.result = p1;
    }

    public void Multiplicar_escalar()
    {
           
    } 
}
