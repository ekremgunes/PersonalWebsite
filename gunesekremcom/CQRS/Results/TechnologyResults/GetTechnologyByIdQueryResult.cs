﻿namespace gunesekremcom.CQRS.Results
{
    public class GetTechnologyByIdQueryResult
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        public string ColorCode { get; set; }
        public string Title { get; set; }
        public ushort order { get; set; }
    }
}
