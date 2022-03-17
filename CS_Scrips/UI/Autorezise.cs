using UnityEditor;
using UnityEngine;

public class Autorezise : MonoBehaviour
{

    public Canvas portrait;
    public Canvas landScape;
    public DeviceOrientation Orintation;
    private void Awake()
    {
        Orintation = new DeviceOrientation();
        
    }


    void Update()
    {
         
        if (Screen.orientation == ScreenOrientation.Portrait )
        {
            portrait.gameObject.SetActive( true );
            landScape.gameObject.SetActive( false );
        }
        else
        {
            portrait.gameObject.SetActive(false);
            landScape.gameObject.SetActive(true);
        }


    }
}
