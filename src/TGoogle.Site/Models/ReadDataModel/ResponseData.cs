namespace TGoogle.Site.Models.ReadDataModel
{
    public class ResponseData
    {
        public ResponseResult[] Results { get; set; }

        public static ResponseData Generate()
        {
            var responseData = new ResponseData {Results = new ResponseResult[8]};
            for (int i = 0; i < responseData.Results.Length; i++)
            {
                responseData.Results[i] = ResponseResult.Generate();
            }
            return responseData;
        }
    }
}