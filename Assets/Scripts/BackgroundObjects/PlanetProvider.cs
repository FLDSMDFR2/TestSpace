using System.Collections.Generic;
using UnityEngine;


public class PlanetProvider : MonoBehaviour
{
    public Material PlanetMaterial;
    public GameObject PlanetPrefab;

    [Header("Forground")]
    public float ForgroundMaxSize;
    public float ForgroundMinSize;
    public float ForgroundYValue;

    [Header("Water")]
    public float MaxScaleWater = 200;
    public float MinScaleWater = 50;

    public float MaxShiftWater = 70;
    public float MinShiftWater = 20;

    public float MaxClippingWater = 0.3f;
    public float MinClippingWater = 0.125f;

    public float MaxBrightnessWater = 1; 
    public float MinBrightnessWater = 0.7f;

    public float MaxPowerWater = 3;
    public float MinPowerWater = 1;

    public float MaxGrayScaleWater = 2;
    public float MinGrayScaleWater = 1.5f;

    [Header("Land")]
    public float MaxScaleLand = 200;
    public float MinScaleLand = 50;

    public float MaxShiftLand = 70;
    public float MinShiftLand = 20;

    public float MaxClippingLand = 0.3f;
    public float MinClippingLand = 0.125f;

    public float MaxBrightnessLand = 1;
    public float MinBrightnessLand = 0.7f;

    public float MaxPowerLand = 3;
    public float MinPowerLand = 1;

    public float MaxGrayScaleLand = 2;
    public float MinGrayScaleLand = 1.5f;

    public virtual GameObject GetNewPlanet(bool isBackground)
    {
        PlanetPrefab.SetActive(false);
        var newPlanet = Instantiate(PlanetPrefab, Vector3.zero, Quaternion.identity, this.transform);

        Material planetMaterial = new Material(PlanetMaterial);
        newPlanet.GetComponent<Renderer>().material = planetMaterial;

        //Water
        var colorIndex = RandomGenerator.SeededRange(0, Colors.Instance.GetColorsCount());
        var colors = Colors.Instance.GetComplementaryColors(colorIndex);
        newPlanet.GetComponent<Renderer>().material.SetColor("_Tint", colors.color);
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Scale", RandomGenerator.SeededRange(MinScaleWater, MaxScaleWater));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Shift", RandomGenerator.SeededRange(MinShiftWater, MaxShiftWater));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_ClippingThreshold", RandomGenerator.SeededRange(MinClippingWater, MaxClippingWater));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Brightness", RandomGenerator.SeededRange(MinBrightnessWater, MaxBrightnessWater));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_BrightnessPower", RandomGenerator.SeededRange(MinPowerWater, MaxPowerWater));
        if (!isBackground) newPlanet.GetComponent<Renderer>().material.SetFloat("_GrayScale", RandomGenerator.SeededRange(MinGrayScaleWater, MaxGrayScaleWater));
        else newPlanet.GetComponent<Renderer>().material.SetFloat("_GrayScale", 1);

        //land
        newPlanet.GetComponent<Renderer>().material.SetColor("_Tint2", colors.color2);
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Scale2", RandomGenerator.SeededRange(MinScaleLand, MaxScaleLand));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Shift2", RandomGenerator.SeededRange(MinShiftLand, MaxShiftLand));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_ClippingThreshold2", RandomGenerator.SeededRange(MinClippingLand, MaxClippingLand));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_Brightness2", RandomGenerator.SeededRange(MinBrightnessLand, MaxBrightnessLand));
        newPlanet.GetComponent<Renderer>().material.SetFloat("_BrightnessPower2", RandomGenerator.SeededRange(MinPowerLand, MaxPowerLand));
        if (!isBackground) newPlanet.GetComponent<Renderer>().material.SetFloat("_GrayScale2", RandomGenerator.SeededRange(MinGrayScaleLand, MaxGrayScaleLand));
        else newPlanet.GetComponent<Renderer>().material.SetFloat("_GrayScale2", 1);

        return newPlanet;
    }
}
