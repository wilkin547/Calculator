using System.Linq;


public class Producto : ComprobarMatrizes
{

    public override void operar()
    {

        base.operar();
        if (!(CC.ins.matriz_principal.columna == CC.ins.matriz_Secundaria.fila)){
            Mensajeria.mensaje_Error("la columna de la matriz A debe ser igual a las filas de la matriz B");
            return;
        }

        CC.ins.result.eleminar_Columna();

        Multiplicar_Elementos.Multiplicar();

        foreach (var item in CC.ins.result.Elementos)
        {
            item.Numero.text = item.Valor.ToString();
        }


    }

    public void Multiplicar_escalar()
    {
           
    } 
    private void ResizeMatriz()
    {

    }
}
