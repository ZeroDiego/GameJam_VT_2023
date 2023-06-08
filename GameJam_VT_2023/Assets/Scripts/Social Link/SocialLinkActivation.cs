using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialLinkActivation : MonoBehaviour
{
    [SerializeField] private GameObject socialLinkManager;
    private bool mouseOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouseOver && Input.GetMouseButtonDown(0))
        {
            socialLinkManager.SetActive(true);
        }
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
