using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsError : MonoBehaviour {

    [SerializeField]
    private bool showed = false;
    [SerializeField]
    private bool showing = false;

    private void OnTriggerEnter2D()
    {
        if (!this.showing && !this.showed)
        {
            this.showing = true;
            GameObject.FindGameObjectWithTag("WindowsErrorImage").GetComponent<Image>().color = new Color(100F, 100F, 100F, 100);
            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>().color = new Color(100F, 100F, 100F, 0F);
            GameObject.FindGameObjectWithTag("ToolbarImage").GetComponent<SpriteRenderer>().color = new Color(100F, 100F, 100F, 0F);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
    }

    private void Update () {
        if (!this.showed && this.showing && Input.GetButtonDown("Fire1"))
        {
            this.showed = true;
            this.showing = false;
            GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Image>().color = new Color(100F, 100F, 100F, 85F);
            GameObject.FindGameObjectWithTag("ToolbarImage").GetComponent<SpriteRenderer>().color = new Color(100F, 100F, 100F, 85F);
            GameObject.FindGameObjectWithTag("WindowsErrorImage").GetComponent<Image>().color = new Color(100F, 100F, 100F, 0);
        }
    }
}
