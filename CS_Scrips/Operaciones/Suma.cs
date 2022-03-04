using UnityEngine;

public class Suma : ComprobarMatrizes
{
    public override void operar()
    {
        base.operar();
        Sumar_Elementos.Sumar();

        foreach (var item in CC.ins.result.Elementos){
            item.Numero.text = item.Valor.ToString();
        }

    }



}


