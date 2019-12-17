namespace Network_Analyzer_Backend.Models.BaseModels
{
    /// <summary>
    /// Base model for all return models
    /// </summary>
    public abstract class BaseResponseModel
    {
        public bool Result { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
