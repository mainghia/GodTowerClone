using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class SceneScript : MonoBehaviour {
    public void OnStartButtonTapped()
    {
        TKSceneManager.ChangeScene("Gameplay Scene");
    }
}
