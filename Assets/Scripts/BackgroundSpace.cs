using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSpace : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.02f;
    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        Vector2 newOffset = new Vector2(0, (moveSpeed * Time.deltaTime));
        material.mainTextureOffset += newOffset;
    }
}
