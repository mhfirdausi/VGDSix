using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeatBar : MonoBehaviour {
    public Image Bar;

	// Use this for initialization
	void Start () {
        Bar.fillAmount = 0;
	}
	
    void Update()
    {
        Bar.fillAmount = player.heat/100;
    }
	
}
