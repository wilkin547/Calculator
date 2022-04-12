using System.Linq;
using UnityEngine;

public class Corchetes : MonoBehaviour
{
    public GameObject Corchete_Left;
    public GameObject Corchete_Rigth;
    public Matriz_UI matriz;

    [Range(0f, 200f)]
    public float RangoColumna;
    [Range(-200f, 200f)]
    public float RangoFila;
    private void Awake()
    {
        //inicializo los elementos

        Corchete_Left = (from nodo in GetComponentsInChildren<RectTransform>() where nodo.name == "Left" select nodo).First().gameObject;
        Corchete_Rigth = (from nodo in GetComponentsInChildren<RectTransform>() where nodo.name == "Rigth" select nodo).First().gameObject;
        matriz = GetComponentInParent<Matriz_UI>();
    }
    public void agregarColumna()
    {
        //creo una lista que tiene todas las columnas de la ultima fila
        var elem = (from nodo in matriz.Elementos where nodo.columna == matriz.columna select nodo).ToList();

        Corchete_Rigth.transform.position = new Vector2 (elem.First().transform.position.x,Corchete_Rigth.transform.position.y);
        Corchete_Rigth.transform.Translate(Vector2.right * RangoColumna);
    }
    public void EliminarColumna()
    {
        //creo una lista que tiene todas las columnas de la ultima fila
        var elem = (from nodo in matriz.Elementos where nodo.columna == matriz.columna select nodo).ToList();

        Corchete_Rigth.transform.position = new Vector2(elem.First().transform.position.x, Corchete_Rigth.transform.position.y);
        Corchete_Rigth.transform.Translate(Vector2.right * (RangoColumna -120));
    }
    public void AgregarFila()
    {
        var vector = new Vector2(1 ,matriz.fila + 1);
        print(vector);
        Corchete_Left.transform.localScale = vector;
        Corchete_Rigth.transform.localScale = vector;

        Corchete_Left.transform.Translate(Vector2.down * RangoFila);
        Corchete_Rigth.transform.Translate(Vector2.down * RangoFila);
    }
    public void EliminarFila()
    {
        var vector = new Vector2(1, matriz.fila + 1);
        Corchete_Left.transform.localScale = vector;
        Corchete_Rigth.transform.localScale = vector;

        Corchete_Left.transform.Translate(Vector2.up * RangoFila);
        Corchete_Rigth.transform.Translate(Vector2.up * RangoFila);
    }
    public Transform CorcheteRigth()
    {
        return Corchete_Rigth.transform;
    }

    public object Clone ()
    {
        return MemberwiseClone();       
    }
}
