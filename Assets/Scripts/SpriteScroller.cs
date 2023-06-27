using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
  
    void Update()
    {
        offset = scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
