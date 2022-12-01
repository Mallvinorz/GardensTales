using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableIconController : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Header("Tweaks")]
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    [Header("Properties UI")]
    public Texture2D iconTexture;
    [SerializeField] RawImage iconImageTexture;
    void Start()
    {
        iconImageTexture.texture = iconTexture;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(lookAt.position + offset);
        if(transform.position != pos) transform.position = pos;   
    }
}
