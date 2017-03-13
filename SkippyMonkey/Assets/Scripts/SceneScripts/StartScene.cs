using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class StartScene : MonoBehaviour {
    public void OnStartButtonTapped()
    {
        TKSceneManager.ChangeScene("Gameplay Scene");
    }
}
