using UnityEngine;

public class sistema_Touch : MonoBehaviour
{
    public Vector2 inicio;
    public Vector2 final;
    private Touch Mi_Touche;
    public direccion Lastslide;

    [Tooltip("a variable that take a minimu of space to count like a slide")]
    public float SpaceMinin;

    private void Update()
    {
       if (Input.touchCount > 0)
        {
            Mi_Touche = Input.GetTouch(0);

            if (Mi_Touche.phase == TouchPhase.Began)
            {
                inicio = Mi_Touche.position;
            }

            if (Mi_Touche.phase == TouchPhase.Ended)
            {
                final = Mi_Touche.position;
                setDirection();
            }
            
        }
        
    }

    public enum direccion
    {
        Up,
        Down,
        Left,
        Right
    }
     public void setDirection()
    {
        var resultX = final.x - inicio.x;
        var resultY = final.y - inicio.y;

        if (resultX < 0)
        {
            resultX *= -1;
        }
        if (resultY < 0)
        {
            resultY *= -1;
        }

        if (resultX < SpaceMinin || resultY < SpaceMinin)
        {
            return;
        }

        if (resultX > resultY )
        {
            resultX = final.x - inicio.x;

            if (resultX < 0 )
            {

                CC.ins.CurrentMatriz.eleminar_Columna();
                Lastslide = direccion.Left;
                return;
            }
            else
            {
                CC.ins.CurrentMatriz.Agregar_Columna();
                Lastslide = direccion.Right;
                return;

            }
        }
        else
        {
            resultY = final.y - inicio.y;

            if (resultY < 0)
            {
                CC.ins.CurrentMatriz.eleminar_Fila();
                Lastslide= direccion.Down;
                return;

            }
            else
            {
                CC.ins.CurrentMatriz.Agregar_Fila();
                Lastslide = direccion.Up;
                return;
            }
        }
        
    }


}

