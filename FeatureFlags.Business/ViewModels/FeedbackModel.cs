using FeatureFlags.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Business.ViewModels
{
    public class FeedbackModel
    {
        public Guid FlagKey { get; set; }
        public string UserName { get; set; }
        public string Notes { get; set; }

        public FeatureFeedback Dehydrate(FeatureFeedback record, FeatureFlag flag)
        {
            record.Flag = flag;
            record.UserName = this.UserName;
            record.Notes = this.Notes;

            return record;
        }
    }
}
