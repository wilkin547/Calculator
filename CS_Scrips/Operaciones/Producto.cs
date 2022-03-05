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

        while (CC.ins.result.columna < CC.ins.matriz_Secundaria.columna){
            CC.ins.result.Agregar_Columna();
        }
        while (CC.ins.result.columna > CC.ins.matriz_Secundaria.columna)
        {
            CC.ins.result.eleminar_Columna();
        }
        while (CC.ins.result.fila > CC.ins.matriz_principal.fila)
        {
            CC.ins.result.eleminar_Fila();
        }
        while (CC.ins.result.fila < CC.ins.matriz_principal.fila)
        {
            CC.ins.result.Agregar_Fila();
        }

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
