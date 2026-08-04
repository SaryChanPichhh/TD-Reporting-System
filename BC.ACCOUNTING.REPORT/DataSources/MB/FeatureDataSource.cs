namespace BC.ACCOUNTING.REPORT.DataSources.MB
{
    public class FeatureDataSource
    {
        public string Parent { get; set; }
        public List<ChildFeatureDataSource> ChildFeatures { get; set; }
    }

    public class ChildFeatureDataSource
    {
        public string ChildFeature { get; set; }
    }
}
