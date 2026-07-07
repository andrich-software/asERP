using asERP.Application.Specifications.Base;
using asERP.Domain.Entities;

namespace asERP.Application.Specifications
{
    /// <summary>
    /// Specification for filtering feeds by name (case-insensitive).
    /// </summary>
    public class FeedFilterSpecification : FilterSpecification<Feed>
    {
        public FeedFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var lowerSearchString = searchString.ToLower();
                Criteria = f => f.Name.ToLower().Contains(lowerSearchString);
            }
            else
            {
                Criteria = f => true;
            }
        }
    }
}
