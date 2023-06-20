using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float widthInUnits = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosInUnits =Input.mousePosition.x / Screen.width * widthInUnits;
        Vector2 paddlePos = new Vector2(mousePosInUnits,transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits,xMin,xMax);
        transform.position = paddlePos;
    }
}
