
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShapeGenerator {
    ShapeSettings settings;

    public ShapeGenerator(ShapeSettings settings)
    {
        this.settings = settings;
    }

    public Vector3 CalculatePointOnShape(Vector3 pointOnUnitSphere)
    {
        return pointOnUnitSphere * settings.shapeRadius;
    }
}