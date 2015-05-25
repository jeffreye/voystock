using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Voystock.Communication
{
	// 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
	[ServiceContract]
	public interface IVoyStockService
	{
		[OperationContract]
		List<Scheme> GetAllScheme();

		[OperationContract]
		Scheme GetScheme(int id);

		[OperationContract]
		void DeleteScheme(int id);

		[OperationContract]
		void ModifyScheme(Scheme scheme);

		#region Evaluation

		[OperationContract]
		void Evaluate(int scheme_id);

		[OperationContract]
		EvaluationResult GetEvaluationResult(int scheme_id);

		[OperationContract]
		void StopEvaluation(int scheme_id);

		#endregion

		#region Learning

		[OperationContract]
		void Learn(int scheme_id);

		[OperationContract]
		LearningResult GetLearningResult(int scheme_id);

		[OperationContract]
		void StopLearning(int scheme_id);

		#endregion

		#region Recommendation

		[OperationContract]
		void Recommend(int scheme_id);

		[OperationContract]
		RecommendationResult GetRecommendationResult(int scheme_id);

		[OperationContract]
		RecommendationResult GetRecommendationResultOnDate(int scheme_id,DateTime date);

		[OperationContract]
		void StopRecommendationResult(int scheme_id);


		#endregion
	}
}
