using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResizeToChildSize : MonoBehaviour
{
    [SerializeField] RectTransform rect;
    [SerializeField] float height;
    [SerializeField] List<RectTransform> rects;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        height = 0;
        rects.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform child = transform.GetChild(i).GetComponent<RectTransform>();
            rects.Add(child);
            height += child.rect.height;
        }

        rect.sizeDelta = new Vector2(rect.rect.width, height);
        Debug.Log("height: " + rect.rect.height);
    }
}
