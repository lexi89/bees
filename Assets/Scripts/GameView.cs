#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public static class GameView
{
//        public static void SetScreenWidthAndHeightFromEditorGameViewViaReflection()
//        {
//            var gameView = GetGameViewRect();
//            var prop = gameView.GetType().GetProperty("currentGameViewSize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
//            var gvsize = prop.GetValue(gameView, new object[0]{});
//            var gvSizeType = gvsize.GetType();
//
//            int GameViewHeight = (int)gvSizeType.GetProperty("height", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(gvsize, new object[0]{});
//            int GameViewWidth = (int)gvSizeType.GetProperty("width", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(gvsize, new object[0]{});
//            Rect safeArea = new Rect(0,0,GameViewWidth, GameViewHeight);
//        }

    public static Rect GetGameViewRect()
    {
        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
        System.Reflection.MethodInfo GetMainGameView = T.GetMethod("GetMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        System.Object Res = GetMainGameView.Invoke(null,null);
        EditorWindow window = (EditorWindow) Res;
        var prop = window.GetType().GetProperty("currentGameViewSize", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var gvsize = prop.GetValue(window, new object[0]{});
        var gvSizeType = gvsize.GetType();

        int GameViewHeight = (int)gvSizeType.GetProperty("height", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(gvsize, new object[0]{});
        int GameViewWidth = (int)gvSizeType.GetProperty("width", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).GetValue(gvsize, new object[0]{});
        Rect gameViewRect = new Rect(0,0,GameViewWidth, GameViewHeight);
        return gameViewRect;
    }
}

#endif
