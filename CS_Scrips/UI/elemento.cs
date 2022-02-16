using UnityEngine;
using UnityEngine.UI;


public class elemento : MonoBehaviour
{
    
    public int Valor;
    
    public InputField Numero;

    public int columna;
    public int fila;

    private void Update()
    {
        //Valor = int.Parse(Numero.text);
    }
    public void updateText()
    {
        Valor = int.Parse(Numero.text);
        Numero.text = Valor.ToString();
    }



}
