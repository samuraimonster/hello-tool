using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AnimationEventEditor : EditorWindow
{
    private GameObject target;

    private ObjectPreviewEditorWindow objectPreviewEditorWindow;

    [MenuItem("Window/AnimationEventEditor")]
    static void Init()
    {
        AnimationEventEditor window = (AnimationEventEditor)EditorWindow.GetWindow(typeof(AnimationEventEditor));
        window.Show();
    }

    void OnGUI()
    {
        target = (GameObject)EditorGUILayout.ObjectField(target, typeof(GameObject), true);

        if (GUILayout.Button("プレビュー画面を表示"))
        {
            if(objectPreviewEditorWindow == null)
            {
                if(target)
                {
                    objectPreviewEditorWindow = (ObjectPreviewEditorWindow)EditorWindow.GetWindow(typeof(ObjectPreviewEditorWindow));
                    objectPreviewEditorWindow.Init(target);
                    objectPreviewEditorWindow.Show();
                }
                else
                {
                    Debug.LogError("オブジェクトが選択されていません");
                }
            }
        }
    }

    private void OnDestroy()
    {
        objectPreviewEditorWindow.Close();
    }
}
