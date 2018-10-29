﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : Operator {

    public ColArray[] outputColumns; //values will be distributed from left to right, looping
    private int colIndex = 0;
    
    protected override void Step()
    {
        //Output only reads from num1 var
        GetFromReceiver();
        outputColumns[colIndex].AddValue(num1);
        colIndex++;
        colIndex = colIndex % outputColumns.Length;
    }
    
}