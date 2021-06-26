using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Shape))]

public class ShapeEditor : Editor
{
   Shape shape;
   public override void OnInspectorGUI() {
       base.OnInspectorGUI();

       DrawSettingsEditor(shape.shapeSettings, shape.OnShapeSettingsUpdated);
   }

   void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated) {
       using (var check = new EditorGUI.ChangeCheckScope()) {
           EditorGUILayout.InspectorTitlebar(true, settings);
       Editor editor = CreateEditor(settings);
       editor.OnInspectorGUI();
       if(check.changed) {
           if(onSettingsUpdated != null) {
               onSettingsUpdated();
           }
       }
       }
   }
   private void OnEnable()
   {
       shape = (Shape)target;
   }
}
