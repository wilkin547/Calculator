using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//clase para administrar Matriz
public class Matriz_UI : MonoBehaviour
{

    public byte columna = 0;
    public byte fila = 0;

    public Dimensions dimensions = new Dimensions();


    public LinkedList<elemento> Elementos;

    [SerializeField]
    private Corchetes corchetes;

    private void Awake()
    {
        Elementos = new LinkedList<elemento>();
        Agregar_Celdas();
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
    public void Agregar_Columna()
    {

        Agregar_Celdas();
        var Elem = (from Nodo in Elementos where Nodo.columna == columna select Nodo).ToList<elemento>();

        //utilizo el copy , para no recrearlo para cada bucle
        elemento Copy;

        foreach (var item in Elem)
        {
            Copy = Instantiate(item, gameObject.transform);
            Copy.columna++;
            Copy.gameObject.GetComponent<RectTransform>().Translate(item.transform.right * 120);
        }

        corchetes.ActualizarColumna();
        columna++;

        checkDimension();
        Agregar_Celdas();
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

    }
    public Dimensions Dimenciones()
    {
        checkDimension();
        return dimensions;
    }
    public void Move_Matriz(Matriz_UI matriz_UI)
    {
        transform.parent = matriz_UI.transform.parent;
        transform.position = matriz_UI.transform.position;
        transform.Translate(Vector2.right * 150 * (matriz_UI.columna + 1));
    }
    public void Reset()
    {
        while (Elementos.Count > 1)
        {
            Destroy(Elementos.First.Value.gameObject);
            Elementos.RemoveFirst();
        }
        
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
        columna--;
        var elem = (from nodo in Elementos where nodo.columna == columna select nodo).ToArray();

        foreach (var item in elem){
            Destroy(item);
        }

        foreach (var item in elem){
            var nodo = new LinkedListNode<elemento>(item);
            Elementos.Remove(nodo);
        }

        corchetes.ActualizarColumna();
        checkDimension();
    }

    public void eleminar_Fila()
    {
        fila--;
        var elem = (from nodo in Elementos where nodo.fila == fila select nodo).ToArray();

        foreach (var item in elem){
            Destroy(item);
        }

        foreach (var item in elem){
            var nodo = new LinkedListNode<elemento>(item);
            Elementos.Remove(nodo);
        }

        checkDimension();
        corchetes.EliminarFila();
    }

}
