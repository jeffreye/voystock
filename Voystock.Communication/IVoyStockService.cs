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
            UriTemplate = "scheme/all",Method ="GET")]
		[OperationContract]
		List<Scheme> GetAllScheme();

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme/{id}", Method = "GET")]
        [OperationContract]
		Scheme GetScheme(int id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme/{id}", Method = "DELETE")]
        [OperationContract]
		void DeleteScheme(int id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "scheme/{id}", Method = "POST")]
        [OperationContract]
		void AddOrModifyScheme(Scheme scheme);

        #region Evaluation

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "evaluation/{scheme_id}", Method = "PUT")]
        [OperationContract]
		void Evaluate(int scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "evaluation/{scheme_id}", Method = "GET")]
        [OperationContract]
		EvaluationResult GetEvaluationResult(int scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "evaluation/{scheme_id}", Method = "DELETE")]
        [OperationContract]
		void StopEvaluation(int scheme_id);

        #endregion

        #region Learning

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "learning/{scheme_id}", Method = "PUT")]
        [OperationContract]
		void Learn(int scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "learning/{scheme_id}", Method = "GET")]
        [OperationContract]
		LearningResult GetLearningResult(int scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "learning/{scheme_id}", Method = "DELETE")]
        [OperationContract]
		void StopLearning(int scheme_id);

        #endregion

        #region Recommendation

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}", Method = "PUT")]
        [OperationContract]
		void Recommend(int scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}", Method = "GET")]
        [OperationContract]
		RecommendationResult GetRecommendationResult(int scheme_id);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}/{date}", Method = "GET")]
        [OperationContract]
		RecommendationResult GetRecommendationResultOnDate(int scheme_id,DateTime date);

        [WebInvoke
            (RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "recommendation/{scheme_id}", Method = "DELETE")]
        [OperationContract]
		void StopRecommendationResult(int scheme_id);


		#endregion
	}
}
