namespace Sharp2;

public interface INameAndCopy
{
    string Name { get; set;}
    object DeepCopy();
}