using UnityEngine;
using UnityEngine.EventSystems;

public class sistema_Touch : MonoBehaviour
{
    private static Vector2 inicio;
    private static Vector2 final;
    private Touch Mi_Touche;

    public static float pendiente;
    public static direccion M;

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
                setDireccion();
            }           
            
        }
    }

    public static float GetPendiente()
    {
        var Result = (final.y - inicio.y) / (final.x - inicio.x);
        return Result;
    }

    public static void setDireccion()
    {
        pendiente = GetPendiente();

        if (pendiente >= 0  && pendiente < 4 )
        {
            M = direccion.Left;
        }
        if (pendiente > -4 / 800 && pendiente <= 0 )
        {
            M = direccion.Right;
        }
        if (pendiente >= 8 )
        {
            M = direccion.Up;
        }
        if (pendiente <= -8 )
        {
            M = direccion.Down;
        }

        Mensajeria.mensaje($"pendiente {M} vector inicial {inicio} vector final {final}");
    }
    public enum direccion
    {
        Up,
        Down,
        Left,
        Right
    }



}

