namespace GuiderTestTask.Data.Dto;

public class TagDto(string name, string? description, List<long> establishments)
{
    public string Name => name;
    public string? Description => description;
    public List<long> Establishments => establishments;
}