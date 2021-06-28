using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using GLib;
using HSFrameWork.ConfigTable;
using Jyx2;
using Jyx2Editor;
using UnityEditor;
using UnityEngine;

static public class Jyx2NodeEditorHelperQuickButtons
{

    /// <summary>
    /// 绘制跳转到场景的按钮
    /// </summary>
    /// <param name="sceneId"></param>
    /// <param name="text">按钮显示文本</param>
    public static void NavigateToSceneButton(int sceneId,string text="快速导航该场景")
    {
        if (GUILayout.Button(text))
        {
            var jyx2Map = ConfigTable.GetAll<GameMap>()
                .SingleOrDefault(map => map.Jyx2MapId.Equals(sceneId.ToString()));

            if (jyx2Map == null)
            {
                ShowErrMessageBox($"找不到场景id={sceneId}");
            }

            string path = $"Assets/Jyx2Scenes/{jyx2Map.Key}.unity";
            Jyx2MenuItems.NavigateToPath(path);
        }
    }
    
    /// <summary>
    /// 绘制跳转到场景的按钮
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="text">按钮显示文本</param>
    public static void NavigateToEventButton(int eventId,string text = "快速编辑该事件")
    {
        if (GUILayout.Button(text))
        {
            //判断是否存在EventsGraph，否则跳转lua文件
            string path =
                $"Assets/BuildSource/EventsGraph/{eventId}.asset";
            if (File.Exists(path))
            {
                Jyx2MenuItems.NavigateToPath(path);
            }
            else
            {
                string luaPath = $"data/lua/jygame/ka{eventId}.lua";
                if (File.Exists(luaPath))
                {
                    //EditorUtility.RevealInFinder(luaPath);
                    string finalLuaPath = "file:///" + System.Environment.CurrentDirectory + "/" + luaPath; 

                    Application.OpenURL(finalLuaPath);
                }
                else
                {
                    ShowErrMessageBox($"事件{eventId}找不到对应的事件图或lua");
                } 
            }
        }
    }

    private static void ShowErrMessageBox(string content)
    {
        EditorUtility.DisplayDialog("错误", content, "确定");
    }
}
