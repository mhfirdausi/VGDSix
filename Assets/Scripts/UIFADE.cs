using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIFADE : MonoBehaviour {
    public CanvasGroup myGroup;
    public Canvas myCanvas;
    void Awake()
    {
        myGroup = GetComponent<CanvasGroup>();
        myCanvas = GetComponent<Canvas>();
        myGroup.alpha = 0;
    }

    void Update()
    {
        if(myCanvas.enabled)
        {
            myGroup.alpha = 0;
            StartCoroutine(fadePanel());
        }
    }

    void OnEnable()
    {
        myGroup.alpha = 0;
        StartCoroutine(fadePanel());
    }
    IEnumerator fadePanel()
    {
        yield return null;
        float time = 0f;
        while (time < 1f)
        {
            time += Time.unscaledDeltaTime;
            myGroup.alpha = time;
            yield return null;
        }
        myGroup.alpha = 1f;
        myGroup.interactable = true;
    }

}
