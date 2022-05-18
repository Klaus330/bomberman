using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper
{
    public static T FindComponentInChildWithTag<T>(RectTransform parent, string tag)where T:Component{
        
        foreach(RectTransform tr in parent.GetComponentsInChildren<RectTransform>())
        {
            // Component[] components = tr.GetComponents(typeof(Component));
            // foreach(Component component in components) {
            //     Debug.Log(component.ToString());
            // }
                if(tr.tag == tag)
                {
                    return tr.GetComponent<T>();
                }
        }
        return null;
    }
}
