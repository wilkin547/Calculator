using UnityEngine;
using System.Linq;

public class Suma : ComprobarMatrizes
{
    public override void operar()
    {
  
        base.operar();
        elemento[] result = CC.ins.result.Elementos.ToArray();
        elemento[] principal = CC.ins.matriz_principal.Elementos.ToArray();
        for (int i = 0; i < result.Length; i++)
        {
            result[i].Valor = principal[i].Valor;
        }
        if (CC.ins.matriz_principal.dimensions != CC.ins.matriz_Secundaria.dimensions)
        {
            Mensajeria.mensaje_Error("ambas matrices deben tener las mismas dimensiones");
        }
        Sumar_Elementos.Sumar(CC.ins.result.Elementos.ToArray(),CC.ins.matriz_Secundaria.Elementos.ToArray());

        foreach (var item in CC.ins.result.Elementos){
            item.Numero.text = item.Valor.ToString();
        }

    }



}


