using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//clase para administrar Matriz
public class Matriz_UI : MonoBehaviour
{

    public int columna = 0;
    public int fila = 0;


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

            if (Elementos.Contains(item)) return;

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
        corchetes.AgregarFila();

    }
    public string Dimenciones()
    {
        return fila + "x" + columna;
    }
    public void Move_Matriz(Matriz_UI matriz_UI)
    {
        transform.Translate(Vector2.right * 120 * (columna + 1));
    }
    


}
