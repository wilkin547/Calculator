using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class elemento : MonoBehaviour
{
    
    public int Valor;
    
    public TMP_Text Numero;

    public int columna;
    public int fila;

    public Matriz_UI father;
    
    public void UpdateCurrentMatriz()
    {
        Calculate_Controller.instance.CurrentMatriz = father;
        Calculate_Controller.instance.CurrentElemento = this;
        Mensajeria.mensaje($"la matriz actual es {father.name}");
        Mensajeria.mensaje($"el elemento actual es {Calculate_Controller.instance.CurrentElemento.name}");
    }

    



}
