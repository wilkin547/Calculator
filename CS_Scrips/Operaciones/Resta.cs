using UnityEngine;

public class Resta : ComprobarMatrizes
{
    public override void operar()
    {
       base.operar();
        Restar_Elementos.Restar();

        foreach (var item in CC.ins.result.Elementos){
            item.Numero.text = item.Valor.ToString();
        }
    }
}
