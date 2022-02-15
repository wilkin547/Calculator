using UnityEngine;
using UnityEngine.EventSystems;

public class sistema_Touch : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector2 inicio;
    private Vector2 final;
    private Touch Mi_Touche;

    private int Fila;
    private int Columna;

    private float diferencia_X;
    private float diferencia_Y;

    

    private void Update()
    {
        /* if (Input.touchCount > 0)
         {
             Mi_Touche = Input.GetTouch(0);

             inicio = Mi_Touche.phase == TouchPhase.Began ? Mi_Touche.position : inicio;

             final = Mi_Touche.phase == TouchPhase.Ended ? Mi_Touche.position : final;


             //1 == mayor a 0 , 2 menor a 0
             Fila = inicio.y < final.y ? 1 : 2;
             Columna = inicio.x < final.x ? 1 : 2;

             comprueba_Diferencia();

         }*/



    }

    private void comprueba_Diferencia()
    {
        if (Mi_Touche.phase == TouchPhase.Ended)
        {

            diferencia_Y = Fila == 1 ? final.y - inicio.y : inicio.y - final.y;
            diferencia_X = Columna == 1 ? final.x - inicio.x : inicio.x - final.x;


            if (diferencia_X >= diferencia_Y)
            {
                if (diferencia_X >= 50)
                {
                    if (Fila == 1)
                    {
                        
                    }
                    else
                    {

                    }


                }
                else
                {
                  
                }



            }
            else if (diferencia_X <= diferencia_Y)
            {

                if (diferencia_Y >= 50)
                {
                    if (Columna == 1)
                    {

                    }
                    else
                    {

                    }

                }
                print("no se cumplio con la diferenciaY de 50");


            }

            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;
        GetDragDirection(dragVectorDirection);
    }

    private enum DraggedDirection
    {
        Up,
        Down,
        Right,
        Left
    }

    
    private DraggedDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        DraggedDirection draggedDir;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? DraggedDirection.Right : DraggedDirection.Left;
        }
        else
        {
            draggedDir = (dragVector.y > 0) ? DraggedDirection.Up : DraggedDirection.Down;
        }
        Debug.Log(draggedDir);
        print("klk");
        return draggedDir;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetDragDirection(eventData.position - eventData.pressPosition);
    }
}

