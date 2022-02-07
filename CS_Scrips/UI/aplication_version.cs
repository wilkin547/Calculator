using UnityEngine;
using UnityEngine.UI;

public class aplication_version : MonoBehaviour
{

    public Text text;
    void Start()
    {
        text.text = "version " + Application.version ;  
    }


}

