namespace RetroSpec.Application.DTOs;

public record BoardListDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
}
