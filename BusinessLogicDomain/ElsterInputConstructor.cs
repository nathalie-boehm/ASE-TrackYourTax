namespace TrackYourTax.BusinessLogicDomain
{
    public class ElsterInputConstructor
    {
        private readonly ElsterInputBuilder _elsterInputBuilder;
        public ElsterInputConstructor(ElsterInputBuilder elsterInputBuilder)
        {
            _elsterInputBuilder = elsterInputBuilder;
        }

        public void ConstructElsterInput()
        {
            _elsterInputBuilder.ConstructExpenses();
            _elsterInputBuilder.ConstructRidesFirstEmployment();
            _elsterInputBuilder.ConstructRidesSecondEmployment();
            _elsterInputBuilder.ConstructCateringAdditionalExpenses();
            _elsterInputBuilder.ConstructHealthcareExpenses();
        }

    }
}
