using UnityEngine;

public class Fraccion : MonoBehaviour
{
    private float Numerador;
    private float Denominador;

    public Fraccion(float num, float den)
    {

        Numerador = num;
        Denominador = den;

    }

    public string fraccion()
    {
        return $"{Numerador}/{Denominador}";
    }
    public string fraccion_Simplificada()
    {
        return $"{Numerador}/{Denominador}";
    }
    public bool Is_Propio()
    {

        if ((Numerador / Denominador) % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Suma(Fraccion F1)
    {
        Numerador = (Numerador * F1.Denominador) + (Denominador * F1.Numerador);
        Denominador = Denominador * F1.Denominador;
    }
    public void Suma_F (Fraccion F1)
    {
        Suma(F1);
    }
    public void Suma(Fraccion F1, Fraccion F2)
    {
        Suma(F1);
        Suma(F2);

    }
    public void Suma(Fraccion F1, Fraccion F2, Fraccion F3)
    {
        Suma(F1);
        Suma(F2);
        Suma(F3);
        
    }
    public void Suma(Fraccion F1, Fraccion F2, Fraccion F3, Fraccion F4)
    {
        Suma(F1);
        Suma(F2);
        Suma(F3);
        Suma(F4);
    }
    public void Suma(Fraccion F1, Fraccion F2, Fraccion F3, Fraccion F4, Fraccion F5)
    {

        Suma(F1);
        Suma(F2);
        Suma(F3);
        Suma(F4);
        Suma(F5);
    }

    private void Multipicacion_Simple(Fraccion F1)
    {
        Numerador *= F1.Numerador;
        Denominador *= F1.Denominador;
    }
    public void Multipicacion(Fraccion F1)
    {
        Multipicacion_Simple(F1);
    }
    public void Multipicacion(Fraccion F1, Fraccion F2)
    {
        Multipicacion_Simple(F1);
        Multipicacion_Simple(F2);
    }
    public void Multipicacion(Fraccion F1, Fraccion F2, Fraccion F3)
    {
        Multipicacion_Simple(F1);
        Multipicacion_Simple(F2);
        Multipicacion_Simple(F3);
    }
    public void Multipicacion(Fraccion F1, Fraccion F2, Fraccion F3, Fraccion F4)
    {
        Multipicacion_Simple(F1);
        Multipicacion_Simple(F2);
        Multipicacion_Simple(F3);
        Multipicacion_Simple(F4);
    }
    public void Multipicacion(Fraccion F1, Fraccion F2, Fraccion F3, Fraccion F4, Fraccion F5)
    {
        Multipicacion_Simple(F1);
        Multipicacion_Simple(F2);
        Multipicacion_Simple(F3);
        Multipicacion_Simple(F4);
        Multipicacion_Simple(F5);
    }

    public void Divicion_Simple(Fraccion F1)
    {
        Numerador *= F1.Denominador;
        Denominador *= F1.Numerador;
    }
    public void Division(Fraccion F1, Fraccion F2)
    {
        Divicion_Simple(F1);
        Divicion_Simple(F2);
    }
    public void Division(Fraccion F1, Fraccion F2, Fraccion F3)
    {
        Division(F1, F2);
        Divicion_Simple(F3);
    }
    public void Division(Fraccion F1, Fraccion F2, Fraccion F3, Fraccion F4)
    {
        Division(F1, F2, F3);
        Divicion_Simple(F4);
    }
    public void Division(Fraccion F1, Fraccion F2, Fraccion F3, Fraccion F4, Fraccion F5)
    {
        Division(F1, F2, F3,F4);
        Divicion_Simple(F5);
    }


}
