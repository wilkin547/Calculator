using UnityEngine;

public class Agregar_Fila : MonoBehaviour
{
    public void Agregar()
    {
        Calculate_Controller.instance.CurrentMatriz.Agregar_Fila();
    }
}
