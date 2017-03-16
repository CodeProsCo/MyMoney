namespace MyMoney.API.DataAccess.Spending
{
    using System;

    using Common.Interfaces;

    using Interfaces;

    using JetBrains.Annotations;

    [UsedImplicitly]
    public class ExpenditureRepository : IExpenditureRepository
    {
        private ICategoryRepository categoryRepository;

        public ExpenditureRepository(ICategoryRepository categoryRepository)
        {
            if (categoryRepository == null)
            {
                throw new ArgumentNullException(nameof(categoryRepository));
            }

            this.categoryRepository = categoryRepository;
        }
    }
}
