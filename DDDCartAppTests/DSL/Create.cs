namespace DDDCartAppTests.DSL
{
    public static class Create
    {
        public static CartBuilder Cart()
        {
            return new CartBuilder();
        }

        public static ProductBuilder Product()
        {
            return new ProductBuilder();
        }
    }
}