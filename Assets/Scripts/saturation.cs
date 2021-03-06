using UnityEngine;
using System.Collections;
using DG.Tweening;

public class saturation : MonoBehaviour
{
    private SpriteRenderer _render;
    public void OnDisable()
    {
        SaturationEventManager.Saturate -= Saturate;
    }

    public void OnEnable()
    {
        SaturationEventManager.Saturate += Saturate;
    }


    private void Saturate(int score)
    {
        switch (score)
        {
            case 1:
                _render.DOColor(HexToColor("656565FF"), 10);
                
                break;
            case 2:
                _render.DOColor(HexToColor("818181FF"), 20);
                //_render.DOColor(HexToColor("414141FF"), 20);

                break;
            case 3:
                _render.DOColor(HexToColor("CACACAFF"), 30);
                //_render.DOColor(HexToColor("595959FF"), 30);

                break;
            case 4:
                _render.DOColor(HexToColor("FFFFFFFF"), 60);
                break;
        }
       
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    public void Start()
    {
        _render = GetComponent<SpriteRenderer>();
    }
}
