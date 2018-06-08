using System.Collections.Generic;

namespace Services.Infrashstructure
{
    public class ResultResponse<TModel>
    {
        public IList<TModel> Models { get; set; }
        public int Success { get; set; }
        public int Fail { get; set; }
        public string[] Exception { get; set; }
    }
}
