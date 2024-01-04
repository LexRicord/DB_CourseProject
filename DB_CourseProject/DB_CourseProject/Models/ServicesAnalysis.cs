namespace DB_CourseProject.Models
{
    public class ServiceAnalysis
    {
        public string ServiceName { get; set; }
        public int OrderId { get; set; }
        public int TotalOrders { get; set; }
        public int UniqueClients { get; set; }
        public decimal AvgServicePrice { get; set; }
        public decimal MaxServicePrice { get; set; }
        public decimal MinServicePrice { get; set; }
        public int TotalEstimatedCompletionTime { get; set; }

        public ServiceAnalysis(string serviceName, int orderId, int totalOrders, int uniqueClients, decimal avgServicePrice, decimal maxServicePrice, decimal minServicePrice, int totalEstimatedCompletionTime)
        {
            ServiceName = serviceName;
            OrderId = orderId;
            TotalOrders = totalOrders;
            UniqueClients = uniqueClients;
            AvgServicePrice = avgServicePrice;
            MaxServicePrice = maxServicePrice;
            MinServicePrice = minServicePrice;
            TotalEstimatedCompletionTime = totalEstimatedCompletionTime;
        }
    }
}
