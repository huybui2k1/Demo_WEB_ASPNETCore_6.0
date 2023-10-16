namespace MyCodeFirstApprochDemo.Areas.Admin.Models
{
	public class SearchSortPageViewModel
	{
		public string SearchString { get; set; }
		public string SortCol { get; set; }
		public string SortOrder { get; set; }
		public int Page { get; set; }
		public int PageSize { get; set; }
	}
}
