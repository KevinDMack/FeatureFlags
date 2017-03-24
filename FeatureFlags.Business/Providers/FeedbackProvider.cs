using FeatureFlags.Business.Interfaces;
using FeatureFlags.Business.ViewModels;
using FeatureFlags.Data;
using FeatureFlags.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.Providers
{
    public class FeedbackProvider : IFeedbackProvider
    {
        private readonly IDataUnit _dataUnit;

        public FeedbackProvider(IDataUnit dataUnit)
        {
            _dataUnit = dataUnit;
        }

        public void SaveFeedback(FeedbackModel model)
        {
            var featureFeedback = new FeatureFeedback();

            var flag = _dataUnit.FeatureFlagRepository.Get().Where(f => f.Key == model.FlagKey).SingleOrDefault();

            if (flag != null)
            {
                try
                {
                    featureFeedback = model.Dehydrate(featureFeedback, flag);
                    _dataUnit.FeatureFeedbackRepository.Insert(featureFeedback);
                    _dataUnit.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentNullException("Feature Flag", "No feature flag found for sent key");
            }
        }
    }

    
}
