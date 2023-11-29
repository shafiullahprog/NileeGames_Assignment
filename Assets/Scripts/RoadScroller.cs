using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScroller : MonoBehaviour
{
    [SerializeField] Renderer roadMat;
    [SerializeField] float backgroundSpeed;
    // Update is called once per frame
    void Update()
    {
        float offsetY = backgroundSpeed * Time.deltaTime;
        roadMat.material.mainTextureOffset = new Vector2(0, offsetY);
         //m.mainTextureOffset += new Vector2(0, backgroundSpeed);
    }
}
