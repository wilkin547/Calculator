using System.Linq;
using UnityEngine;

public class Producto : MonoBehaviour
{
    
    public void Multiplicar()
    {

        if (Calculate_Controller.instance.matriz_Secundaria == null)
        {
            Calculate_Controller.instance.matriz_Secundaria = Instantiate(Calculate_Controller.instance.matriz_Original, GameObject.FindGameObjectWithTag("UI").transform);
            Mensajeria.mensaje("se agrego la matriz secundaria");
            return;
        }
        if (Calculate_Controller.instance.result == null)
        {
            Calculate_Controller.instance.result = Calculate_Controller.instance.agregar_matriz();
            Mensajeria.mensaje("se agrego el resultado");

        }

        if (!(Calculate_Controller.instance.matriz_principal.columna == Calculate_Controller.instance.matriz_principal.fila)){
            Mensajeria.mensaje_Error("la columna de la matriz A debe ser igual a las filas de la matriz B");
            return;
        }

        Matriz_UI secundaria = Calculate_Controller.instance.matriz_Secundaria;

        while (secundaria.columna >= Calculate_Controller.instance.matriz_principal.columna){
            secundaria.Agregar_Columna();
        }

        while (secundaria.fila >= Calculate_Controller.instance.matriz_Secundaria.fila){
            secundaria.Agregar_Fila();
        }

        secundaria.Move_Matriz(Calculate_Controller.instance.matriz_Secundaria);

        Multiplicar_Elementos.Multiplicar(secundaria.Elementos.ToArray(), Calculate_Controller.instance.matriz_principal.Elementos.ToArray(), Calculate_Controller.instance.matriz_Secundaria.Elementos.ToArray());
        Calculate_Controller.instance.result = secundaria;
    }

    public void Multiplicar_escalar()
    {
           
    } 
}
