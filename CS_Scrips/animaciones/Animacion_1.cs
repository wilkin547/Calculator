using UnityEngine;
using UnityEngine.UI;


public class Animacion_1 : MonoBehaviour
{
    public float speed;
    public Image Mi_imagen;
    public bool IS_Clear;
    public Color Mi_color;
   

    private void Awake()
    {
        Mi_imagen = GetComponent<Image>();
    }


    void Update()
    {
        Comprueba_Transparencia();

        Cambiando_Transparencia();
    }

    private void Comprueba_Transparencia()
    {
        if (Mi_imagen.color.a <= 0)
        {
            IS_Clear = true;
        }
        else if (Mi_imagen.color.a >= 1)
        {
            IS_Clear = false;
        }
    }

    private void Cambiando_Transparencia()
    {
        Mi_imagen.color = Mi_color;

        if (IS_Clear)
        {
            Mi_color.a += speed * Time.deltaTime;
        }
        else
        {
            Mi_color.a -= speed * Time.deltaTime;
        }
    }
}
