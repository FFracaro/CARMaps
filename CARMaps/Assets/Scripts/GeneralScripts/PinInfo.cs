using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinInfo : MonoBehaviour
{
    [SerializeField]
    TMP_Text PinName;

    [SerializeField]
    Vector3 PinLocalPosition;

    [SerializeField]
    Vector3 PinWorldPosition;

    // 0 branco, 1 azul, 2 laranja, 3 rosa, 4 amarelo, 5 verde
    [SerializeField]
    int PinColor = 0;

    [SerializeField]
    SpriteRenderer PinSpriteRenderer;

    public Sprite[] PinMainSprites;

    private void Start()
    {
        PinLocalPosition = transform.localPosition;
        PinWorldPosition = transform.position;
    }

    private void Update()
    {
        Debug.Log(PinLocalPosition);
        Debug.Log(PinWorldPosition);
    }

    public void ChancePinSprite(int color)
    {
        PinSpriteRenderer.sprite = PinMainSprites[color];
    }

    public void SetPinName(string name)
    {
        PinName.text = name;
    }

    public string GetPinName()
    {
        return PinName.text;
    }

    public void SetPinLocalPosition(Vector3 pos)
    {
        this.PinLocalPosition = pos;
    }

    public Vector3 GetPinLocalPosition()
    {
        return this.PinLocalPosition;
    }

    public void SetPinWorldPosition(Vector3 pos)
    {
        this.PinWorldPosition = pos;
    }

    public Vector3 GetPinWorldPosition()
    {
        return this.PinWorldPosition;
    }

    public void UpdatePinLocations(Vector3 local, Vector3 world)
    {
        SetPinLocalPosition(local);
        SetPinWorldPosition(world);
    }

    public void SetPinColor(int color)
    {
        this.PinColor = color;
    }

    public int GetPinColor()
    {
        return this.PinColor;
    }

    public void UpdatePinSprite(int color)
    {
        PinSpriteRenderer.sprite = PinMainSprites[color];
    }
}
