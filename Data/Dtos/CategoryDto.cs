namespace GuiderTestTask.Data.Dto;

public class CategoryDto(string name, List<long> establishments, string? description = null)
{
    public string Name => name;
    public string? Description => description;
    public List<long>? Establishments { get; } = establishments;
}