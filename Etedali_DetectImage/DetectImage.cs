using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace Etedali_DetectImage
{
    [DynamoDBTable("DetectImages")]
    public class DetectImage
    {
        [DynamoDBHashKey]
        public string Id { get; set; }

        [DynamoDBRangeKey]
        public string ObjUrl {get; set;}

        public string FileName { get; set; }

        public long Size { get; set; }

        public List<ImageTag> ImageTag{get; set;}
    }
}
