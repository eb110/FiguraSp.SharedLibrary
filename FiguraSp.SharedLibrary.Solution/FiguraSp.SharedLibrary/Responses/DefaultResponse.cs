namespace FiguraSp.SharedLibrary.Responses
{
    public record DefaultResponse(bool Success = false)
    {
        public List<string> Errors { get; set; } = [];
    }
}
