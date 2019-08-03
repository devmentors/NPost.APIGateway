using System;
using System.Collections.Generic;

namespace NPost.APIGateway
{
    public class CorrelationContext
    {
        public string CorrelationId { get; set; } = Guid.NewGuid().ToString("N");
        public string SpanContext { get; set; }
        public int Retries { get; set; }
        public string UserId { get; set; }
        public string Role { get; set; }
        public IDictionary<string, string> Claims { get; set; }
    }
}