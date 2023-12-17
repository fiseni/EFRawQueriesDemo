using System.ComponentModel.DataAnnotations.Schema;

namespace EFRawQueriesDemo;

public record Movie
{
    public int Id { get; set; }

    public required string Title { get; set; }

    [Column("Overview")]
    public string? Description { get; set; }

    public DateTime? ReleaseDate { get; set; }

    [Column(TypeName = "real")]
    public decimal? Popularity { get; set; }

    public int? VoteCount { get; set; }
}