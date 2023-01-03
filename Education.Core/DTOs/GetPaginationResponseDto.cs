using System.Text.Json.Serialization;

namespace Education.Core.DTOs
{
    public class GetPaginationResponseDto<T> where T : class
    {
        public T Table { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int RecordTotal { get; set; }
        [JsonIgnore]
        public string RecordsFiltered { get; set; }
        public static GetPaginationResponseDto<T> SetData(T data, int pageNo, int pageSize, int RecordTotal)
        {
            return new GetPaginationResponseDto<T>
            {
                Table = data,
                PageNo = pageNo,
                PageSize = pageSize,
                RecordTotal = RecordTotal,
                RecordsFiltered = $"Toplam  {RecordTotal} adet kayıttan {pageSize} adet kayıt gösterilmektedir."
            };
        }
    }
}
