using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
    private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");
    private List<Material> mats;
    
    //private Material mat; 
    public ColorPicker colorPicker;
    [Header("Highlight Settings")]
    public Color emissionColor;
    public float minIntensity = 0f;
    public float maxIntensity = 0.1f;
    public float speed = 1f; //3.0f;
    public float wait = 5f;

    public Transform player;
    public float dist;


    void Awake()
    {
        Renderer[] rends = GetComponentsInChildren<Renderer>();
        mats = new List<Material>();

        foreach(Renderer rend in rends)
        {
            foreach (Material mat in rend.materials)
            {
                mats.Add(mat);
                mat.EnableKeyword("_EMISSION");
            }
        }
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < dist)
        {
            float intensity = (Mathf.Lerp(minIntensity, maxIntensity, Mathf.Pow((Mathf.Sin(Time.time * speed) + 1f) / 2f, wait)));
        
            foreach(Material mat in mats)
            {
                mat.SetColor(EmissionColor, colorPicker.SelectedColor * intensity);
            }

        }
        else
        {
            foreach (Material mat in mats)
            {
                mat.SetColor(EmissionColor, Color.black);
            }
        }

    }

}
