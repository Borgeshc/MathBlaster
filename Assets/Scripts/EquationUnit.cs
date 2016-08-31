using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class EquationUnit
{
    private string m_Equations;
    private string m_EquationResult;

    public string EquationResult
    { 
        get { return m_EquationResult; }
        set { m_EquationResult = value; }
    }
    
    public string Equations
    {
        get { return m_Equations; }
        set { m_Equations = value; }
    }
}
