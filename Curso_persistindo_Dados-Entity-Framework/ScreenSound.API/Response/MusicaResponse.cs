namespace ScreenSound.API.Response;

public record MusicaResponse(int Id, string Nome, string? NomeArtista, int? ArtistaId, int? AnoLancamento);
