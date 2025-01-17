﻿namespace GarageManagementAPI.Shared.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;

        private int _pageNumber;
        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value > 0 ? value : 1;
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

    }
}
