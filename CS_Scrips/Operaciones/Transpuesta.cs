using UnityEngine;

public class Transpuesta : MonoBehaviour
{

    public void Invertir()
    {
        CC.ins.CurrentMatrizInversa.transform.position = CC.ins.CurrentMatriz.transform.position;
        Destroy(CC.ins.CurrentMatriz.gameObject);


    }
}