namespace GuiderTestTask.Data.Dto;

public class EstablishmentDto(string name, long categoryId, string address, List<long> tags, string? description = null)
{
    public string Name => name;
    public string Address => address;
    public string? Description => description;
    public long CategoryId => categoryId;

    public List<long> Tags { get; } = tags;
}