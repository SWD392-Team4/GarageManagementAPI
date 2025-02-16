namespace GarageManagementAPI.Shared.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;

        private int _pageNumber = 1;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                if (value == 0 || value < 0)
                    _pageNumber = 1;
                else _pageNumber = value;
            }
        }

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string? OrderBy { get; set; }

        public string? Fields { get; set; }

    }
}
