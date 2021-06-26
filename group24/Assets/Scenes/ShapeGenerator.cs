
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShapeGenerator {
    ShapeSettings settings;
    NoiseFilter noiseFilter;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
        noiseFilter = new NoiseFilter(settings.noiseSettings);
    }

    public Vector3 CalculatePointOnShape(Vector3 pointOnUnitSphere)
    {
        float elevation = noiseFilter.Evaluate(pointOnUnitSphere);
        return pointOnUnitSphere * settings.shapeRadius * (1 + elevation);
    }
}