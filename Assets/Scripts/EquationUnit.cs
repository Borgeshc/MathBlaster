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
