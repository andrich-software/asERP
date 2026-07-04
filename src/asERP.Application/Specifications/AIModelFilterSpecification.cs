using asERP.Application.Specifications.Base;
using asERP.Domain.Entities;

namespace asERP.Application.Specifications
{
    /// <summary>
    /// Specification for filtering ai models
    /// </summary>
    public class AiModelFilterSpecification : FilterSpecification<AiModel>
    {
        public AiModelFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = w => (w.Name.Contains(searchString));
            }
            else
            {
                Criteria = p => true;
            }
        }

        public AiModelFilterSpecification(Guid id)
        {
            Criteria = o => o.Id == id;
        }
    }
}
