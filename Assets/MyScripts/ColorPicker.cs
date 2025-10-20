using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ColorPicker : MonoBehaviour
{
    private static readonly int ColorProp = Shader.PropertyToID("_BaseColor");
    public Color SelectedColor;
    public Settings settings;
    public Transform topCylinderTransform;
    public Material colorPickDisplayMat;
    
    private XRRayInteractor rayInteractor;
    
    void Start()
    {
        rayInteractor = settings.RightRayInterractor.GetComponent<XRRayInteractor>();
        if(rayInteractor == null) Debug.Log("Could not retrieve right XRRayInteractor from {settings.RightRayInterractor} in {this.name}");
        
        colorPickDisplayMat.SetColor(ColorProp, SelectedColor);
    }
    
    public void updateColor()
    {
        if (rayInteractor.TryGetHitInfo(out Vector3 hitPosition, out Vector3 hitNormal, out int hitIndex,
                out bool isValidTarget))
        {
            if (!isValidTarget) return;
            
            Vector2 hit = hitPosition; 
            
            // compute HSV values:
            float radius = topCylinderTransform.lossyScale.x / 2.0f;
            float v = 1.0f;
            float s = Vector2.Distance(hitPosition, topCylinderTransform.position) / radius;
            if (s > 1.0f)
            {
                Debug.LogWarning("Hit outside of picker. Should not happen");
                return;
            }

            float h = Mathf.Atan2(
                - (hit.y - topCylinderTransform.position.y), // top/bottom inverted 
                hit.x - topCylinderTransform.position.x
            );
            // rescale between 0 and 1
            h = (h + Mathf.PI) / (2 *  Mathf.PI);
            
            // Convert HSV to RGB
            // https://stackoverflow.com/questions/51203917/math-behind-hsv-to-rgb-conversion-of-colors
            float i = Mathf.Floor(6 * h);
            float f = 6 * h - i;
            float p = v * (1 - s);
            float q = v * (1 - f * s);
            float t = v * (1 - (1 - f) * s);

            float r, g, b;
            switch (i % 6)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }
            
            SelectedColor = new Color(r, g, b, 1.0f);
            colorPickDisplayMat.SetColor(ColorProp, SelectedColor);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        if (settings.freeMove)
        {
            settings.RightDisabled.SetActive(false);
            settings.RightRayInterractor.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        if (settings.freeMove)
        {
            settings.RightRayInterractor.SetActive(false);
            settings.RightDisabled.SetActive(true);
        }
    }
}
