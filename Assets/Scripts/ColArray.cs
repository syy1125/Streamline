﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ColArray : MonoBehaviour {

    // Use this for initialization
    private List<Text> text;
    private List<int> nums;
    [HideInInspector]
    public int columnHeight;
	void Awake () {
        text = new List<Text>();
        foreach (Transform child in transform)
        {
            text.Add(child.GetComponent<Text>());
        }
        nums = new List<int>();
        ClearNums();
    }
    public int Length()
    {
        return nums.Count;
    }
    public void ClearNums()
    {
        nums = new List<int>();
        for (int i = 0; i < text.Count; i++)
        {
            text[i].text = "";
        }
    }
    public int GetValue(int i)
    {
        if (i >= nums.Count)
        {
            Debug.Log("Accessing index out of bounds: (Count=" + nums.Count + ",Index=" + i);
            return -1000;
        }
        return nums[i];
    }
    public void SetValue(int i, int newX)
    {
        if (i >= nums.Count)
        {
            Debug.Log("Accessing index out of bounds: (Count=" + nums.Count + ",Index=" + i);
            return;
        }
        nums[i] = newX;
        text[i].text = nums[i].ToString();
    }
    public void AddValue(int val)
    {
        if(nums.Count >= text.Count)
        {
            Debug.Log("ColArray is Full: (Count=" + nums.Count);
            return;
        }
        text[nums.Count].text = val.ToString();
        nums.Add(val);
    }
    public bool Matches(ColArray other)
    {
        if(this.Length() != other.Length())
            return false;
        int length = Mathf.Min(this.Length(),other.Length());
        for(int i = 0; i < length ;i++)
        {
            if(GetValue(i) != other.GetValue(i))
                return false;
        }
        return true;
    }
}
