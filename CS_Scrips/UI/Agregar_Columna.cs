using UnityEngine;

public class Agregar_Columna : MonoBehaviour
{
    public void Agregar()
    {
        Calculate_Controller.instance.CurrentMatriz.Agregar_Columna();
    }
}
