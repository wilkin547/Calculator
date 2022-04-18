﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//clase para administrar Matriz
public class Matriz_UI : MonoBehaviour
{

    public int columna = 0;
    public int fila = 0;

    public Dimensions dimensions = new Dimensions();

    public Matriz_UI inversa;
    public LinkedList<elemento> Elementos;

    [SerializeField]
    private Corchetes corchetes;

    private void Awake()
    {
        Elementos = new LinkedList<elemento>();
        Agregar_Celdas();
        
    }

    public Matriz_UI()
    {

    }

    //inicializamos con una copia de una matriz existente
    public Matriz_UI(Matriz_UI Copia)
    {
        

    }
    public void Agregar_Celdas()
    {

        var nodo = (from Nodo
                    in gameObject.GetComponentsInChildren<elemento>()
                    orderby Nodo.columna
                    select Nodo).ToList();

        foreach (var item in nodo)
        {
            var Elem = new LinkedListNode<elemento>(item);

            if (Elementos.Contains(item)) continue;

            Elementos.AddFirst(Elem);

        }


    }
    public void Agregar_Celdas(LinkedListNode<elemento> t)
    {

        Elementos.AddFirst(t);
    }
    public void Agregar_Columna()
    {


        
        var Elem = (from Nodo in Elementos where Nodo.columna == columna select Nodo).ToList();

        //utilizo el copy , para no recrearlo para cada bucle
        elemento Copy = new elemento();

        foreach (var item in Elem)
        {
            Copy = Instantiate(item, gameObject.transform);
            Copy.columna++;
            Copy.gameObject.GetComponent<RectTransform>().Translate(item.transform.right * 120);
        }
        
        corchetes.agregarColumna();
        columna++;

        if (CC.ins.matriz_principal == this)
        {
            transform.Translate(Vector2.left * 125);
        }
        checkDimension();
        Agregar_Celdas();

        if (inversa == null) return;

        inversa.Agregar_Fila();

    }
    public void Agregar_Fila()
    {

        Agregar_Celdas();

        elemento Copy;

        var Elem = (from Nodo in Elementos where Nodo.fila == fila select Nodo).ToList<elemento>();

        //crea los elementos
        foreach (var item in Elem)
        {
            Copy = Instantiate(item, gameObject.transform);
            Copy.fila++;
            Copy.gameObject.GetComponent<RectTransform>().Translate(item.transform.up * -120);
        }

        Agregar_Celdas();

        foreach (var item in Elementos)
        {
            item.GetComponent<RectTransform>().Translate(item.GetComponent<RectTransform>().transform.up * 120);
        }

        fila++;
        checkDimension();
        corchetes.AgregarFila();
        if (inversa == null) return;

        inversa.Agregar_Columna();

    }
    public void Move_Matriz(Matriz_UI matriz_UI)
    {
        this.transform.parent = matriz_UI.transform.parent;
        this.transform.position = matriz_UI.transform.position;
        this.transform.localScale = new Vector3(1, 1, 1);
        this.transform.Translate(Vector2.right * 190 * (matriz_UI.columna + 1));
    }

    public enum Dimensions
    {
        _1x1,
        _2x2,
        _3x3,
        _4x4,
        _5x5,
        Incomplete,
    }
    private void checkDimension()
    {

        if (fila == columna)
        {
            switch (fila)
            {
                case 0:
                    dimensions = Dimensions._1x1;
                    break;
                case 1:
                    dimensions = Dimensions._2x2;
                    break;
                case 2:
                    dimensions = Dimensions._3x3;
                    break;
                case 3:
                    dimensions = Dimensions._4x4;
                    break;
                case 4:
                    dimensions = Dimensions._5x5;
                    break;
            }
        }
        else
        {
            dimensions = Dimensions.Incomplete;
        }
    }
    public void eleminar_Columna()
    {


        if (columna == 0) return;
        var elem = (from nodo in Elementos where nodo.columna == columna select nodo).ToArray();
        
        foreach (var item in elem)
        {
            Elementos.Remove(item);
            Destroy(item.gameObject);
        }

        

        columna--;
        if (CC.ins.matriz_principal == this)
        {
            transform.Translate(Vector2.right * 125);
        }
        checkDimension();
        corchetes.EliminarColumna();

        if (inversa == null) return;

        inversa.eleminar_Fila();
    }
    public void eleminar_Fila()
    {

        if (fila == 0) return;
        elemento[] elem = (from nodo in Elementos where nodo.fila == fila select nodo).ToArray();

        foreach (var item in elem)
        {
            Elementos.Remove(item);
            Destroy(item.gameObject);
        }

        foreach (var item in Elementos)
        {
            item.GetComponent<RectTransform>().Translate(item.GetComponent<RectTransform>().transform.up * -120);
        }

        

        fila--;
        checkDimension();
        corchetes.EliminarFila();
        if (inversa == null) return;

        inversa.eleminar_Columna();
    }
    public void Clonar(Matriz_UI Copia)
    {
        this.columna = Copia.columna;
        this.fila = Copia.fila;
        this.transform.SetPositionAndRotation(Copia.transform.position, Copia.transform.rotation);
        this.transform.parent = Copia.transform.parent;
        this.dimensions = Copia.dimensions;

        //Clonar elementos
        elemento[] elem = Copia.Elementos.ToArray();
        int indice = elem.Length -1;

        while (Copia.Elementos.Count >= this.Elementos.Count)
        {
            this.Elementos.AddFirst(new elemento());
            elem[indice].Clonar(this.Elementos.First.Value);
        }
    }
  
    public Transform CorcheteRigth()
    {
        return corchetes.CorcheteRigth();
    }
    public object Clone()
    {
        return MemberwiseClone();
    }

}
