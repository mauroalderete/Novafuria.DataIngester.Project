using Novafuria.DataIngester.Prepaper.Domain.Core.ValueObjects;
using Novafuria.DataIngester.Preparer.Domain.UseCase.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novafuria.DataIngester.Preparer.Temporalio.UseCases.Activities
{
    public class PareparerActivities : IPrepareActivities
    {
        public Task SetupResources(UniqueSelector uniqueSelector)
        {
            throw new NotImplementedException();
        }

        public Task ValidateResources(UniqueSelector uniqueSelector)
        {
            throw new NotImplementedException();
        }

        public Task ValidateUniqueSelector(UniqueSelector uniqueSelector)
        {
            throw new NotImplementedException();
        }
    }
}
