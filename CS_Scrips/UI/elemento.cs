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
    private void Start()
    {
       
    }


    private void Update()
    {
        updateText();
    }

    public void updateText()
    {
        Numero.text = Valor.ToString();
    }
    public void UpdateCurrentMatriz()
    {
        Calculate_Controller.instance.CurrentMatriz = father;
        Calculate_Controller.instance.CurrentElemento = this;
        Calculate_Controller.instance.mensaje($"la matriz actual es {father.name}");
    }

    



}
