using UnityEngine;
using UnityEngine.EventSystems;

public class sistema_Touch : MonoBehaviour
{
    private static Vector2 inicio;
    private static Vector2 final;
    private Touch Mi_Touche;


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



}

