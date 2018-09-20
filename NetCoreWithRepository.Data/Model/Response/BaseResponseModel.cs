using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWithRepository.Data.Model.Response
{
    public class BaseResponseModel<T>
    {
        public BaseResponseModel()
        {
            Errors = new List<string>();
        }

        public bool HasError => Errors.Any();
        public List<string> Errors { get; set; }
        public int Total { get; set; }
        public T Data { get; set; }
    }
}
