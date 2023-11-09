using System.Collections.Generic;
using UnityEngine;


public class PlanetGenerator : MapObjectGenerator
{
    [Header("Planet")]
    public float MaxScale = 200;
    public float MinScale = 50;

    public float MaxShift = 70;
    public float MinShift = 20;

    public float MaxClipping = 0.3f;
    public float MinClipping = 0.125f;

    public float MaxBrightness = 1; 
    public float MinBrightness = 0.7f;

    public float MaxPower = 3;
    public float MinPower = 1;

    public float MaxGrayScale = 2;
    public float MinGrayScale = 1.5f;

    public override GameObject GetObject(bool isBackground)
    { 
        var newPlanet = Instantiate(Prefab, Vector3.zero, Quaternion.identity, this.transform);
        newPlanet.SetActive(false);

        Material planetMaterial = new Material(Material);
        newPlanet.GetComponent<Renderer>().material = planetMaterial;

        //Water
        var colorIndex = RandomGenerator.SeededRange(0, Colors.Instance.GetColorsCount());
        var colors = Colors.Instance.GetComplementaryColors(colorIndex);
        newPlanet.GetComponent<Renderer>().material.SetColor("_Tint", colors.color);
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Scale", RandomGenerator.SeededRange(MinScale, MaxScale));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Shift", RandomGenerator.SeededRange(MinShift, MaxShift));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_ClippingThreshold", RandomGenerator.SeededRange(MinClipping, MaxClipping));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Brightness", RandomGenerator.SeededRange(MinBrightness, MaxBrightness));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_BrightnessPower", RandomGenerator.SeededRange(MinPower, MaxPower));
        if (!isBackground) newPlanet.GetComponent<Renderer>().material.SetFloat("_GrayScale", RandomGenerator.SeededRange(MinGrayScale, MaxGrayScale));
        else newPlanet.GetComponent<Renderer>().material.SetFloat("_GrayScale", 1);

        //land
        newPlanet.GetComponent<Renderer>().material.SetColor("_Tint2", colors.color2);

        var palentScript = newPlanet.GetComponent<Planet>();
        if (palentScript != null)
        {
            palentScript.HasRings = RandomGenerator.SeededRandomBool();
        }

        newPlanet.SetActive(true);
        return newPlanet;
    }
}
