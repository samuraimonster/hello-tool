using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// オブジェクトプレビュー画面
/// </summary>
public class ObjectPreviewEditorWindow : EditorWindow
{
    private PreviewRenderUtility renderer;

    private Vector2 size = new Vector2(640, 640);


    public void Init(GameObject gameObject)
    {
        renderer ??= new PreviewRenderUtility();

        var ob = Instantiate(gameObject);
        renderer.AddSingleGO(ob);
    }

    void OnGUI()
    {
        renderer ??= new PreviewRenderUtility();
        var rect = new Rect(0, 0, position.size.x, position.size.y);

        renderer.BeginStaticPreview(rect);
        renderer.camera.farClipPlane = 100;
        renderer.camera.transform.position = new Vector3(0, 20, 0);
        renderer.camera.transform.rotation = Quaternion.Euler(90, 0, 0);

        // レンダリングしてテクスチャとって描画
        renderer.camera.Render();
        var tex = renderer.EndStaticPreview();
        GUI.DrawTexture(rect, tex);
    }

    private void OnDestroy()
    {
        renderer?.Cleanup();
    }
}
