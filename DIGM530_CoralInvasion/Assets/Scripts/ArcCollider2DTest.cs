﻿/*
The MIT License (MIT)

Copyright (c) 2016 GuyQuad

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

You can contact me by email at guyquad27@gmail.com or on Reddit at https://www.reddit.com/user/GuyQuad
*/


#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Physics 2D/Arc Collider 2D Test")]

[RequireComponent(typeof(EdgeCollider2D))]
public class ArcCollider2DTest : MonoBehaviour {

    [Range(1, 25)]
    public float radius = 3;

    [Range(1, 25)]
    public float radiusSmall = 2;

    [Range(10,90)]
    public int smoothness = 24;

    [Range(10, 360)]
    public int totalAngle = 360;

    [Range(0, 360)]
    public int offsetRotation = 0;

    [Header("Let there be Pizza")]
    public bool pizzaSlice;
    
    Vector2 origin, center;
    
    public Vector2[] getPoints(Vector2 off)
    {
        List<Vector2> points = new List<Vector2>();

        origin = transform.localPosition;
        center = origin + off;
        
        float ang = offsetRotation;

        if (pizzaSlice && totalAngle % 360 != 0)
        {
            points.Add(center);
        }

        // Trying to add vector that holds first position to pass to end of function
        Vector2 startingPoint = new Vector2(center.x + radius * Mathf.Cos(ang * Mathf.Deg2Rad), center.y + radius * Mathf.Sin(ang * Mathf.Deg2Rad));

        // Need to duplicate this with another radius value to create arc section chunks
        for (int i = 0; i <= smoothness; i++)
        {
            float x = center.x + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
            float y = center.y + radius * Mathf.Sin(ang * Mathf.Deg2Rad);

            points.Add(new Vector2(x, y));
            ang += (float)totalAngle/smoothness;
        }

        for (int i = 0; i <= smoothness; i++)
        {
            ang -= (float)totalAngle / smoothness;

            float x = center.x + radiusSmall * Mathf.Cos(ang * Mathf.Deg2Rad);
            float y = center.y + radiusSmall * Mathf.Sin(ang * Mathf.Deg2Rad);

            points.Add(new Vector2(x, y));
            //ang -= (float)totalAngle / smoothness;
        }

        points.Add(startingPoint);

        if (pizzaSlice && totalAngle % 360 != 0)
        {
            points.Add(center);
        }

        return points.ToArray();
    }
}
#endif