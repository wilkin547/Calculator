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
        CC.ins.CurrentMatriz = father;
        CC.ins.CurrentElemento = this;
        Mensajeria.mensaje($"la matriz actual es {father.name}");
        Mensajeria.mensaje($"el elemento actual es {CC.ins.CurrentElemento.name}");
    }

    



}
