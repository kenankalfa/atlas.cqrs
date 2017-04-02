using System;

namespace Atlas.ReadModels
{
    public class DiaryItemReadModel
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }
    }
}
