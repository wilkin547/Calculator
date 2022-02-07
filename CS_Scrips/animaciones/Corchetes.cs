﻿using System.Linq;
using UnityEngine;

public class Corchetes : MonoBehaviour
{
    private RectTransform Corchete_Left;
    private RectTransform Corchete_Rigth;
    public Matriz_UI matriz;

    [Range(0f, 200f)]
    public float RangoColumna;
    [Range(-200f, 200f)]
    public float RangoFila;

    private void Awake()
    {
        //inicializo los elementos

        Corchete_Left = (from nodo in GetComponentsInChildren<RectTransform>() where nodo.name == "Left" select nodo).First();
        Corchete_Rigth = (from nodo in GetComponentsInChildren<RectTransform>() where nodo.name == "Rigth" select nodo).First();
        matriz = GetComponentInParent<Matriz_UI>();
    }

    public void ActualizarColumna()
    {
        //creo una lista que tiene todas las columnas de la ultima fila
        var elem = (from nodo in matriz.Elementos where nodo.columna == matriz.GetColumana() select nodo).ToList();

        Corchete_Rigth.transform.position = new Vector2 (elem.First().transform.position.x,Corchete_Rigth.transform.position.y);
        Corchete_Rigth.transform.Translate(Corchete_Left.transform.right * RangoColumna);
    }

    public void AgregarFila()
    {
        var elem = (from nodo in matriz.Elementos where nodo.columna == 0 select nodo);

        var vector = new Vector2(1 ,matriz.GetFila() + 1);
        Corchete_Left.localScale = vector;
        Corchete_Rigth.localScale = vector;

        Corchete_Left.transform.Translate(Vector2.down * RangoFila);
        Corchete_Rigth.transform.Translate(Vector2.down * RangoFila);
    }

}
