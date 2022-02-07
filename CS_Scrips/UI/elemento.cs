using UnityEngine;
using TMPro;


public class elemento : MonoBehaviour
{
    
    public int Valor;
    
    public TMP_Text Numero;
    public bool Is_Active;
    [SerializeField]
    private Color activo;
    [SerializeField]
    private Color desactivar;
    /// <summary>
    /// indica si ya se ha usado el elemente
    /// </summary>
    
    public bool used;

    public RectTransform guia;
    public int columna;
    public int fila;


    public void Reset()
    {
        
    }

}
