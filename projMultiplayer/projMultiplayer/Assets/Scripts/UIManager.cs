using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
class UIManager
{
    public static void SetText(GameObject output, object text)
    {
        output.GetComponent<TextMeshProUGUI>().text = text.ToString();
    }

    public static void AddText(GameObject output, object text)
    {
        output.GetComponent<TextMeshProUGUI>().text += text.ToString();
    }

    public static string ReturnHexTextColor(GameObject color)
    {
        return ColorUtility.ToHtmlStringRGB(color.GetComponent<SpriteRenderer>().color);
    }
}
