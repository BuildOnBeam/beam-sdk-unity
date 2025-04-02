namespace Beam.Models
{
    public class BeamPollingResult<T> where T : class
    {
        public T Result { get; set; }
        public string Error { get; set; }
        
        public bool IsOk => string.IsNullOrEmpty(Error);
    }
}