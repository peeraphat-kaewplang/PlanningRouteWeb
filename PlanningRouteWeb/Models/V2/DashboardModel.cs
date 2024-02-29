namespace PlanningRouteWeb.Models.V2
{
    public class DashboardModel: HttpResponse
    {
        public List<DashboardData> Data { get; set; } = new();
    }

    public class DashboardData
    {
        public string? ORGANIZATION_CODE { get; set; }
        public string? VALUE_PER_MONTH { get; set; }
        public string? SUM_AMOUT { get; set; }
        public string? SUM_REALSALE { get; set; }
        public string? SUM_SALE_VALUE { get; set; }
        public string? SUM_DROP_PER_DAY { get; set; }
        public string? COUNT_SERVICE { get; set; }
        public string? SUM_DROP_SERVICE { get; set; }
        public string? VALUE_PER_MONTH_BEF { get; set; }
        public string? SUM_AMOUT_BEF { get; set; }
        public string? SUM_REALSALE_BEF { get; set; }
        public string? SUM_SALE_VALUE_BEF { get; set; }
        public string? SUM_DROP_PER_DAY_BEF { get; set; }
        public string? COUNT_SERVICE_BEF { get; set; }
        public string? SUM_DROP_SERVICE_BEF { get; set; }
    }
    public class DashboardBody : DateRequest
    {
        public string? ORG { get; set; }
        public string? yearmonth { get; set; }
    }

    public class DateRequest
    {
        public string? DATE_CUR_START { get; set; }
        public string? DATE_CUR_END { get; set; }
        public string? DATE_BEF_START { get; set; }
        public string? DATE_BEF_END { get; set; }

    }

    public class DashboardViewModel
    {
        public List<DashboardList> Data { get; set; } = new();
        public DashboardSummary Summary { get; set; } = new();
    }
    public class DashboardList
    {
        public string? Organization { get; set; }
        public string? OrganizationCode { get; set; }
        public double BeforeTarget { get; set; }
        public double BeforeEstimate { get; set; }
        public double BeforeSales { get; set; }
        public double BeforeSumSales { get; set; }
        public double BeforeTargetDrop { get; set; }
        public double BeforeService { get; set; }
        public double BeforeSumDropService { get; set; }
        public double Target { get; set; }
        public double Estimate { get; set; }
        public double Sales { get; set; }
        public double SumSales { get; set; }
        public double TargetDrop { get; set; }
        public double Service { get; set; }
        public double SumDropService { get; set; }
        public static List<DashboardList> CloneModel(List<DashboardList> model)
        {
            return model.Select(x => new DashboardList
            {
                OrganizationCode = x.OrganizationCode,
                Organization = x.Organization,
                BeforeTarget = x.BeforeTarget,
                BeforeEstimate = x.BeforeEstimate,
                BeforeSales = x.BeforeSales,
                BeforeSumSales = x.BeforeSumSales,
                BeforeTargetDrop = x.BeforeTargetDrop,
                BeforeService = x.BeforeService,
                BeforeSumDropService = x.BeforeSumDropService,
                Target = x.Target,
                Estimate = x.Estimate,
                Sales = x.Sales,
                SumSales = x.SumSales,
                TargetDrop = x.TargetDrop,
                Service = x.Service,
                SumDropService = x.SumDropService,
            }).ToList();
        }
        public static DashboardList ConverModel(DashboardData model, List<OrganizationData> org)
        {
            var o = org.Find(x => x.ORGANIZATION_CODE == model.ORGANIZATION_CODE);

            return new DashboardList
            {
                OrganizationCode = model.ORGANIZATION_CODE,
                Organization = o!.ORGANIZATION_NAME,
                BeforeTarget = double.Parse(model.VALUE_PER_MONTH_BEF!),
                BeforeEstimate = double.Parse(model.SUM_AMOUT_BEF!),
                BeforeSales = double.Parse(model.SUM_REALSALE_BEF!),
                BeforeSumSales = double.Parse(model.SUM_SALE_VALUE_BEF!),
                BeforeTargetDrop = double.Parse(model.SUM_DROP_PER_DAY_BEF!),
                BeforeService = double.Parse(model.COUNT_SERVICE_BEF!),
                BeforeSumDropService = double.Parse(model.SUM_DROP_SERVICE_BEF!),
                Target = double.Parse(model.VALUE_PER_MONTH!),
                Estimate = double.Parse(model.SUM_AMOUT!),
                Sales = double.Parse(model.SUM_REALSALE!),
                SumSales = double.Parse(model.SUM_SALE_VALUE!),
                TargetDrop = double.Parse(model.SUM_DROP_PER_DAY!),
                Service = double.Parse(model.COUNT_SERVICE!),
                SumDropService = double.Parse(model.SUM_DROP_SERVICE!),
            };
        }
    }
    public class DashboardSummary
    {
        public Summary Summarys { get; set; } = new();
        public Summary Averages { get; set; } = new();
    }
    public class Summary
    {
        public double SumBeforeTarget { get; set; }
        public double SumBeforeEstimate { get; set; }
        public double SumBeforeSales { get; set; }
        public double SumBeforeSumSales { get; set; }
        public double SumBeforeTargetDrop { get; set; }
        public double SumBeforeService { get; set; }
        public double SumBeforeSumDropService { get; set; }
        public double SumTarget { get; set; }
        public double SumEstimate { get; set; }
        public double SumSales { get; set; }
        public double SumSumSales { get; set; }
        public double SumTargetDrop { get; set; }
        public double SumService { get; set; }
        public double SumSumDropService { get; set; }
        public static Summary SumModel(List<DashboardList> model, int count = 1)
        {
            var beforeTarget = model.Sum(x => x.BeforeTarget);
            var beforeEstimate = model.Sum(x => x.BeforeEstimate);
            var beforeSales = model.Sum(x => x.BeforeSales);
            var diffBeforeSales = beforeSales - beforeTarget;

            var beforeTargetDrop = model.Sum(x => x.BeforeTargetDrop);
            var beforeService = model.Sum(x => x.BeforeService);
            var diffBeforeService = beforeService - beforeTargetDrop;

            var target = model.Sum(x => x.Target);
            var estimate = model.Sum(x => x.Estimate);
            var sales = model.Sum(x => x.Sales);
            var diffSales = sales - target;

            var targetDrop = model.Sum(x => x.TargetDrop);
            var service = model.Sum(x => x.Service);
            var diffService = service - targetDrop;

            return new Summary
            {
                SumBeforeTarget = beforeTarget / count,
                SumBeforeEstimate = beforeEstimate / count,
                SumBeforeSales = beforeSales / count,
                SumBeforeSumSales = diffBeforeSales / count,
                SumBeforeTargetDrop = beforeTargetDrop / count,
                SumBeforeService = beforeService / count,
                SumBeforeSumDropService = diffBeforeService / count,
                SumTarget = target / count,
                SumEstimate = estimate / count,
                SumSales = sales / count,
                SumSumSales = diffSales / count,
                SumTargetDrop = targetDrop / count,
                SumService = service / count,
                SumSumDropService = diffService / count
            };
        }

        public static Summary SumDetailModel(List<DashboardDetailList> model, int count = 1)
        {
            var beforeTarget = model.Sum(x => x.BeforeTarget);
            var beforeEstimate = model.Sum(x => x.BeforeEstimate);
            var beforeSales = model.Sum(x => x.BeforeSales);
            var diffBeforeSales = beforeSales - beforeTarget;

            var beforeTargetDrop = model.Sum(x => x.BeforeTargetDrop);
            var beforeService = model.Sum(x => x.BeforeService);
            var diffBeforeService = beforeService - beforeTargetDrop;

            var target = model.Sum(x => x.Target);
            var estimate = model.Sum(x => x.Estimate);
            var sales = model.Sum(x => x.Sales);
            var diffSales = sales - target;

            var targetDrop = model.Sum(x => x.TargetDrop);
            var service = model.Sum(x => x.Service);
            var diffService = service - targetDrop;

            return new Summary
            {
                SumBeforeTarget = beforeTarget / count,
                SumBeforeEstimate = beforeEstimate / count,
                SumBeforeSales = beforeSales / count,
                SumBeforeSumSales = diffBeforeSales / count,
                SumBeforeTargetDrop = beforeTargetDrop / count,
                SumBeforeService = beforeService / count,
                SumBeforeSumDropService = diffBeforeService / count,
                SumTarget = target / count,
                SumEstimate = estimate / count,
                SumSales = sales / count,
                SumSumSales = Math.Round(diffSales / count, 2),
                SumTargetDrop = targetDrop / count,
                SumService = service / count,
                SumSumDropService = Math.Round(diffService / count, 2)
            };
        }
    }
    public class DashboardDetailModel : HttpResponse
    {
        public List<DashboardDetailData> Data { get; set; } = new();
    }
    public class DashboardDetailData
    {
        public string? ROUTE_CODE { get; set; }
        public string? ROUTE_NAME { get; set; }
        public string? VALUE_PER_MONTH { get; set; }
        public string? SUM_AMOUT { get; set; }
        public string? SUM_REALSALE { get; set; }
        public string? SUM_SALE_VALUE { get; set; }
        public string? SUM_DROP_PER_DAY { get; set; }
        public string? COUNT_SERVICE { get; set; }
        public string? SUM_DROP_SERVICE { get; set; }
        public string? VALUE_PER_MONTH_BEF { get; set; }
        public string? SUM_AMOUT_BEF { get; set; }
        public string? SUM_REALSALE_BEF { get; set; }
        public string? SUM_SALE_VALUE_BEF { get; set; }
        public string? SUM_DROP_PER_DAY_BEF { get; set; }
        public string? COUNT_SERVICE_BEF { get; set; }
        public string? SUM_DROP_SERVICE_BEF { get; set; }
    }

    public class DashboardDetailViewModel
    {
        public List<DashboardDetailList> Data { get; set; } = new();
        public DashboardSummary Summary { get; set; } = new();
    }
    public class DashboardDetailList
    {
        public string? RouteCode { get; set; }
        public string? RouteName { get; set; }
        public double BeforeTarget { get; set; }
        public double BeforeEstimate { get; set; }
        public double BeforeSales { get; set; }
        public double BeforeSumSales { get; set; }
        public double BeforeTargetDrop { get; set; }
        public double BeforeService { get; set; }
        public double BeforeSumDropService { get; set; }
        public double Target { get; set; }
        public double Estimate { get; set; }
        public double Sales { get; set; }
        public double SumSales { get; set; }
        public double TargetDrop { get; set; }
        public double Service { get; set; }
        public double SumDropService { get; set; }
        public static List<DashboardDetailList> CloneModel(List<DashboardDetailList> model)
        {
            return model.Select(x => new DashboardDetailList
            {
                BeforeTarget = x.BeforeTarget,
                BeforeEstimate = x.BeforeEstimate,
                BeforeSales = x.BeforeSales,
                BeforeSumSales = x.BeforeSumSales,
                BeforeTargetDrop = x.BeforeTargetDrop,
                BeforeService = x.BeforeService,
                BeforeSumDropService = x.BeforeSumDropService,
                Target = x.Target,
                Estimate = x.Estimate,
                Sales = x.Sales,
                SumSales = x.SumSales,
                TargetDrop = x.TargetDrop,
                Service = x.Service,
                SumDropService = x.SumDropService,
            }).ToList();
        }
        public static DashboardDetailList ConverModel(DashboardDetailData model)
        {
            return new DashboardDetailList
            {
                RouteCode = model.ROUTE_CODE,
                RouteName = model.ROUTE_NAME,
                BeforeTarget = string.IsNullOrWhiteSpace(model.VALUE_PER_MONTH_BEF) ? 0 : double.Parse(model.VALUE_PER_MONTH_BEF!),
                BeforeEstimate = string.IsNullOrWhiteSpace(model.SUM_AMOUT_BEF) ? 0 : double.Parse(model.SUM_AMOUT_BEF!),
                BeforeSales = string.IsNullOrWhiteSpace(model.SUM_REALSALE_BEF) ? 0 : double.Parse(model.SUM_REALSALE_BEF!),
                BeforeSumSales = string.IsNullOrWhiteSpace(model.SUM_SALE_VALUE_BEF) ? 0 : double.Parse(model.SUM_SALE_VALUE_BEF!),
                BeforeTargetDrop = string.IsNullOrWhiteSpace(model.SUM_DROP_PER_DAY_BEF) ? 0 : double.Parse(model.SUM_DROP_PER_DAY_BEF!),
                BeforeService = string.IsNullOrWhiteSpace(model.COUNT_SERVICE_BEF) ? 0 : double.Parse(model.COUNT_SERVICE_BEF!),
                BeforeSumDropService = string.IsNullOrWhiteSpace(model.SUM_DROP_SERVICE_BEF) ? 0 : double.Parse(model.SUM_DROP_SERVICE_BEF!),
                Target = string.IsNullOrWhiteSpace(model.VALUE_PER_MONTH) ? 0 : double.Parse(model.VALUE_PER_MONTH!),
                Estimate = string.IsNullOrWhiteSpace(model.SUM_AMOUT) ? 0 : double.Parse(model.SUM_AMOUT!),
                Sales = string.IsNullOrWhiteSpace(model.SUM_REALSALE) ? 0 : double.Parse(model.SUM_REALSALE!),
                SumSales = string.IsNullOrWhiteSpace(model.SUM_SALE_VALUE) ? 0 : double.Parse(model.SUM_SALE_VALUE!),
                TargetDrop = string.IsNullOrWhiteSpace(model.SUM_DROP_PER_DAY) ? 0 : double.Parse(model.SUM_DROP_PER_DAY!),
                Service = string.IsNullOrWhiteSpace(model.COUNT_SERVICE) ? 0 : double.Parse(model.COUNT_SERVICE!),
                SumDropService = string.IsNullOrWhiteSpace(model.SUM_DROP_SERVICE) ? 0 : double.Parse(model.SUM_DROP_SERVICE!),
            };
        }
    }
}
