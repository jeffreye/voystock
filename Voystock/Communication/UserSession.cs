﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Voystock.Communication
{
    public static class UserSession
    {
        class SchemeCollection : KeyedCollection<string, Scheme>
        {
            public SchemeCollection()
            {
            }

            public SchemeCollection(IEqualityComparer<string> comparer) : base(comparer)
            {
            }

            public SchemeCollection(IEqualityComparer<string> comparer, int dictionaryCreationThreshold) : base(comparer, dictionaryCreationThreshold)
            {
            }

            protected override string GetKeyForItem(Scheme item)
            {
                return item.Name;
            }
        }

        static IVoyStockService Service;

        static WebChannelFactory<IVoyStockService> ChanelFactory;

        public static KeyedCollection<string,Scheme> AllSchemes { get; private set; } = new SchemeCollection();

        public static ObservableCollection<IndicatorDescription> Indicators { get; set; }  = new ObservableCollection<IndicatorDescription>();

        public static event EventHandler AllSchemesChanged;

        public static async Task Open()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            ChanelFactory = new WebChannelFactory<IVoyStockService>(new Uri("http://100.64.77.175:5555/"));
            await Task.Factory.FromAsync(ChanelFactory.BeginOpen, ChanelFactory.EndOpen,null);
            Service = ChanelFactory.CreateChannel();
            
            AllSchemes.Clear();
            var results = Service.GetAllScheme();
            foreach (var item in results)
            {
                AllSchemes.Add(item);
            }
            if (AllSchemesChanged != null)
            {
                AllSchemesChanged(null, EventArgs.Empty);
            }

            foreach (var item in Service.GetAllIndicators())
            {
                Indicators.Add(item);
            }
        }

        public static async Task Close()
        {
            await Task.Factory.FromAsync(ChanelFactory.BeginClose, ChanelFactory.EndClose,null);
            Service = null;
        }

        public static async Task DeleteScheme(Scheme s)
        {
            await Task.Run(() => Service.DeleteScheme(s.ID.ToString()));
            AllSchemes.Remove(s);
            if (AllSchemesChanged != null)
            {
                AllSchemesChanged(null, EventArgs.Empty);
            }
        }
        
        public static async Task AddOrModifyScheme(Scheme s)
        {
            if (!AllSchemes.Contains(s) && AllSchemes.Any(sc=>sc.Name == s.Name))
            {
                throw new InvalidOperationException("Duplicated Name");
            }
            await Task.Run(() => {
                var result = Service.AddOrModifyScheme(s);
                s.ID = int.Parse(result.Trim('"'));
            });
        }

        #region Evaluation

        public static async Task Evaluate(Scheme s)
        {
            await Task.Run(() => Service.Evaluate(s.ID.ToString()));
        }

        public static async Task<EvaluationResult> GetEvaluationResult(Scheme s)
        {
            return await Task.Run(() => Service.GetEvaluationResult(s.ID.ToString()));
        }


        public static async void StopEvaluation(Scheme s)
        {
            await Task.Run(() => Service.StopEvaluation(s.ID.ToString()));
        }

        #endregion

        #region Learning

        public static async Task Learn(Scheme s)
        {
            await Task.Run(() => Service.Learn(s.ID.ToString()));
        }

        public static async Task<LearningResult> GetLearningResult(Scheme s)
        {
            return await Task.Run(() => Service.GetLearningResult(s.ID.ToString()));
        }

        public static async void StopLearning(Scheme s)
        {
            await Task.Run(() => Service.StopLearning(s.ID.ToString()));
        }

        #endregion

        #region Recommendation

        public static async Task Recommend(Scheme s)
        {
            await Task.Run(() => Service.Recommend(s.ID.ToString()));
        }

        public static async Task<List<RecommendationResult>> GetRecommendationResult(Scheme s)
        {
            return await Task.Run(() => Service.GetRecommendationResult(s.ID.ToString()));
        }

        public static async Task<List<RecommendationResult>> GetRecommendationResultOnDate(Scheme s, DateTime date)
        {
            return await Task.Run(() => Service.GetRecommendationResultOnDate(s.ID.ToString(),date.ToShortDateString()));
        }

        public static async void StopRecommendationResult(Scheme s)
        {
            await Task.Run(() => Service.StopRecommendationResult(s.ID.ToString()));
        }


        #endregion
    }
}
