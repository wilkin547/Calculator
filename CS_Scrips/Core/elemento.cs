using UnityEngine;
using TMPro;

using System.Linq;

public class elemento : MonoBehaviour {

    
    public float Valor;
    
    public TMP_Text Numero;
    public int numeroflotante;

    public int columna;
    public int fila;

    public Matriz_UI father;
    
    public elemento()
    {

    }
    public elemento(int valor,int columna,int fila)
    {
        this.Valor = valor;
        this.columna = columna;
        this.fila = fila;
    }
    public elemento(int valor)
    {
        this.Valor = valor;
    }
    public elemento(int columna, int fila)
    {
        this.columna = columna;
        this.fila = fila;
    }
    public void UpdateCurrentMatriz()
    {
        CC.ins.CurrentMatriz = father;
        CC.ins.CurrentMatrizInversa = father.inversa;
        CC.ins.CurrentElemento = this;
        CC.ins.CurrentElementoInversa = (from nodo in  father.inversa.Elementos where nodo.columna == fila && nodo.fila == columna select nodo).First().GetComponent<elemento>();
        Mensajeria.mensaje($"la matriz actual es {father.name}");
        Mensajeria.mensaje($"el elemento actual es la celda {columna}{fila}");
    }
    public void reset()
    {
        Valor = 0;
        Numero.text = "";
    }
    public void UpdateText()
    {
        Numero.text = Valor.ToString();
        CC.ins.CurrentElementoInversa.Numero.text = Valor.ToString();
    }
    public void Clonar(elemento elem)
    {
        elem.numeroflotante = numeroflotante;
        elem.Numero.text = Numero.text;
        elem.columna = columna;
        elem.fila = fila;
        elem.father = father;
    }

    public object Clone()
    {
        return MemberwiseClone();
    }



}
