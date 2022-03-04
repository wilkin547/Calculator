using UnityEngine;
using System.Collections.Generic;
public class Historia : MonoBehaviour
{
    public static Dictionary<int, CC> histogram = new Dictionary<int, CC>();
    public static int Pasos = 0;
    public static int PasosInches = 0;

    public static void agregarDatos()
    {
        histogram.Add(Pasos, CC.ins);
        Pasos++;
        PasosInches++;

        if (Pasos != PasosInches)
        {
            Pasos = PasosInches;
        }
    }
    public static void RetrocederPasos()
    {
        if (PasosInches <= 0)
        {
            Mensajeria.mensaje_Error("no hay mas pasos atras");
            return;
        }

        PasosInches--;
        CC.ins = histogram[PasosInches];
    }

}
