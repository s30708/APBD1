namespace APBD1;

public class OverfillException : Exception
{
    public OverfillException() : base("Not enough space in this container")
    {
    }
}