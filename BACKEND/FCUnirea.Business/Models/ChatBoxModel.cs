using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJ1c2VySWQiOiIxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJqdGkiOiJiNjVmMDc0Zi01ZGExLTRiNGMtODQ2ZC05NWY0ZGNmMGFiNmEiLCJleHAiOjE3NDgwMDY1NzcsImlzcyI6IkZDVW5pcmVhQXBpIiwiYXVkIjoiRkNVbmlyZWFBbmd1bGFyQXBwIn0.lNRc0rCYxFBIuSvfCdGSWkK-YistLMcMmMremUsy3lY

namespace FCUnirea.Business.Models
{
    public class ChatRequest
    {
        public string Message { get; set; }
    }

    public class ChatResponse
    {
        public string Reply { get; set; }
    }
}
