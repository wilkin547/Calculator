using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;
using UnityEngine.TestTools;

public class NewTestScript : ScriptableObject
{
    

    public int[] result = { 2, 4, 6, 8 };
    public int[] principalf = {1,3,3,4};
    public int[] Secundariof = {0,1,3,4};


    
    [UnityTest]
    [Test]
    public IEnumerator Comprobar_Si_Los_Elementos_Se_Suman_En_Orden()
    {
      Matriz_UI principal = new Matriz_UI();
      Matriz_UI Secundaria = new Matriz_UI();
      Matriz_UI result = new Matriz_UI();

       
    elemento e = new elemento(0);
        
        principal.Elementos.AddFirst(new elemento());
        principal.Elementos.AddFirst(new elemento());
        principal.Elementos.AddFirst(new elemento(principalf[2]));
        principal.Elementos.AddFirst(new elemento(principalf[3]));

        Secundaria.Elementos.AddFirst(new elemento(Secundariof[0]));
        Secundaria.Elementos.AddFirst(new elemento(Secundariof[1]));
        Secundaria.Elementos.AddFirst(new elemento(Secundariof[2]));
        Secundaria.Elementos.AddFirst(new elemento(Secundariof[3]));

        Sumar_Elementos.Sumar(principal, Secundaria);

        var num1 = principal.Elementos.ToArray();
        var num2 = Secundaria.Elementos.ToArray();
        Assert.AreEqual(num1, num2);
        
        yield return null;
    }
}
