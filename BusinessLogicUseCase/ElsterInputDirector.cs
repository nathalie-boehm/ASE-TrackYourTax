namespace TrackYourTax.BusinessLogicDomain
{
    public class ElsterInputDirector
    {
        private readonly ElsterInputBuilder _elsterInputBuilder;
        public ElsterInputDirector(ElsterInputBuilder elsterInputBuilder)
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
