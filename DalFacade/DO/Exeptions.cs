
namespace DO;

[Serializable]
public class DalDoesNotExistException : Exception
{
    public DalDoesNotExistException(string message) : base(message) { }
    public DalDoesNotExistException(string message, Exception inner) : base(message, inner) { }
}

[Serializable]
public class DalAlreadyExistsException : Exception
{
    public DalAlreadyExistsException(string message) : base(message) { }
    public DalAlreadyExistsException(string message, Exception inner) : base(message, inner) { }
}