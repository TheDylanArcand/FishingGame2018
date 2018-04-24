using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/*
[CustomEditor(typeof(InventoryScript))]
public class InventoryEditor : Editor
{
    private const string _INVENTORYPROPERTYITEMIMAGESPROPERTY = "ItemImages";
    private const string _INVENTORYPROPERTYITEMSNAME = "Items";
    private bool[] _ShowItemSlots = new bool[InventoryScript.NumberOfItemSlots];

    private SerializedProperty _ItemImagesProperty;
    private SerializedProperty _ItemsProperty;

    private void OnEnable()
    {
        _ItemImagesProperty = serializedObject.FindProperty(_INVENTORYPROPERTYITEMIMAGESPROPERTY);
        _ItemsProperty = serializedObject.FindProperty(_INVENTORYPROPERTYITEMSNAME);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        for (int i = 0; i < InventoryScript.NumberOfItemSlots; i++)
        {
            ItemSlotGUI(i);
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void ItemSlotGUI(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        _ShowItemSlots[index] = EditorGUILayout.Foldout(_ShowItemSlots[index], "Item slot " + index);

        if (_ShowItemSlots[index])
        {
            EditorGUILayout.PropertyField(_ItemImagesProperty.GetArrayElementAtIndex(index));
            EditorGUILayout.PropertyField(_ItemsProperty.GetArrayElementAtIndex(index));
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }
}*/
