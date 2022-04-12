using System.Linq;
using UnityEngine;

public class StepHistory : MonoBehaviour
{
   Matriz_UI PrincipalCopy;
   Matriz_UI SecundarieCopy;
   Matriz_UI ResultCopy;
  
    //create all news matriz
    
    public StepHistory()
    {
        if (CC.ins.matriz_principal == null)
        {
            PrincipalCopy = null;
        }
        else
        {

        PrincipalCopy = new Matriz_UI(CC.ins.matriz_principal);
        }
        SecundarieCopy = new Matriz_UI(CC.ins.matriz_Secundaria);
        ResultCopy = new Matriz_UI(CC.ins.result);
    }

     ~StepHistory()
    {
        Mensajeria.mensaje("Se Destruyo un paso");
    }
    public void Setcurrent()
    {
        
    }
    private void SetCopyMatriz(Matriz_UI UI1,Matriz_UI UI2)
    {
       var elem1 = UI1.Elementos.ToArray();
        var elem2 = UI2.Elementos.ToArray();

        

        UI1.Elementos.Clear();
        for (int i = 0; i < elem1.Length; i++)
        {    elem1[i].Clonar(elem2[i]); 
        }
    }

}
