namespace BloodBank.ViewModels.Base
{
    public class PagingResponse<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
