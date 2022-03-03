using UnityEngine;

public class Resta : ComprobarMatrizes
{
    public override void operar()
    {
       base.operar();
        Restar_Elementos.Restar();

        foreach (var item in Calculate_Controller.instance.result.Elementos){
            item.Numero.text = item.Valor.ToString();
        }
    }
}
