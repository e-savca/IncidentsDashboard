using System.Collections.Generic;

namespace Common.Models
{
    public class DataTableResponseModel<T> where T : class
    {
        public string draw {  get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data {  get; set; } 
    }
}
