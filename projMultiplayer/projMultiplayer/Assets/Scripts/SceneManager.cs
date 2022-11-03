using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
class SceneManager
{
    public static void GoToScene(int sceneID)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneID);
    }

    public static void GoToScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
