using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    public float scrollSpeed;
    [SerializeField] private Renderer renderer;
    [SerializeField] private Vector2 savedOffset;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        float x=Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset=new Vector2(x,0);
        renderer.sharedMaterial.SetTextureOffset("_MainTex",offset);
    }

   
}
