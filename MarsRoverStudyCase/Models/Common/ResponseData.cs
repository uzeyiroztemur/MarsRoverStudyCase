using System;
using MarsRoverStudyCase.Models.Enums;

namespace MarsRoverStudyCase.Models.Common
{
    public class ResponseData
    {
        public StatusEnum Status { get; set; }
        public string Data { get; set; }

        public ResponseData()
        {
            Status = StatusEnum.Success;
            Data = string.Empty;
        }
    }
}
