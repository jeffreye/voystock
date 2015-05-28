using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Voystock.Communication
{
	// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
	[ServiceContract]
	public interface IVoyStockService
    {
        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "indicators", Method = "GET")]
        [OperationContract]
        List<IndicatorDescription> GetAllIndicators();

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme_all",Method ="GET")]
		[OperationContract]
        List<Scheme> GetAllScheme();

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme/{id}", Method = "GET")]
        [OperationContract]
		Scheme GetScheme(string id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme/{id}", Method = "DELETE")]
        [OperationContract]
		void DeleteScheme(string id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme/", Method = "POST")]
        [OperationContract]
        int AddOrModifyScheme(Scheme s);

        #region Evaluation

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "evaluation/{scheme_id}", Method = "PUT")]
        [OperationContract]
		void Evaluate(string scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "evaluation/{scheme_id}", Method = "GET")]
        [OperationContract]
		EvaluationResult GetEvaluationResult(string scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "evaluation/{scheme_id}", Method = "DELETE")]
        [OperationContract]
		void StopEvaluation(string scheme_id);

        #endregion

        #region Learning

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "learning/{scheme_id}", Method = "PUT")]
        [OperationContract]
		void Learn(string scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "learning/{scheme_id}", Method = "GET")]
        [OperationContract]
		LearningResult GetLearningResult(string scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "learning/{scheme_id}", Method = "DELETE")]
        [OperationContract]
		void StopLearning(string scheme_id);

        #endregion

        #region Recommendation

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}", Method = "PUT")]
        [OperationContract]
		void Recommend(string scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}", Method = "GET")]
        [OperationContract]
        List<RecommendationResult> GetRecommendationResult(string scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}/{date}", Method = "GET")]
        [OperationContract]
        List<RecommendationResult> GetRecommendationResultOnDate(string scheme_id,string date);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}", Method = "DELETE")]
        [OperationContract]
		void StopRecommendationResult(string scheme_id);


		#endregion
	}
}
