using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Agregar_Numeros : MonoBehaviour
{
    private string numero;

    private void Start()
    {
        var button = GetComponent<Button>();
       

        if (gameObject.name == "DEL"){

            button.onClick.AddListener(Calculate_Controller.instance.CurrentElemento.Reset);

        }
        else
        { numero = name[4].ToString();
        button.onClick.AddListener(agrega_numero_UI);
        }
    }


    public void agrega_numero_UI() { 
        //le agregamos el valor

        //ya usamos esta celda ? pues activa la animacion 

        if (!Calculate_Controller.instance.CurrentElemento.used) { 
            //limpiamos el elemento
            Calculate_Controller.instance.CurrentElemento.Numero.text = "";
            Calculate_Controller.instance.CurrentElemento.used = true;
            Calculate_Controller.instance.Celdas_activas++;

        }

        Calculate_Controller.instance.CurrentElemento.Numero.text += numero;

    }


}
