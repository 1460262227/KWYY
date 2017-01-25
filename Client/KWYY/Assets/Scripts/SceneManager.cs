using System;
using System.Collections.Generic;

public class SceneManager
{
    public static SceneManager Instance { get { return inst; } }
    static SceneManager inst = new SceneManager();

    public Dictionary<string, Scene> Scenes = new Dictionary<string, Scene>();

    // 切换到指定场景
    Scene curScene = null;
    public void Switch2Scene(string sceneName)
    {
        if (curScene != null)
            curScene.gameObject.SetActive(false);

        Scene s = Scenes[sceneName];
        s.gameObject.SetActive(true);
        curScene = s;
    }
}
