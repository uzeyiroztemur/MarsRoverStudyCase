using System;
using System.Collections.Generic;
using MarsRoverStudyCase.Models.Enums;

namespace MarsRoverStudyCase.Models.Common
{
    public class ResponseData
    {
        public StatusEnum Status { get; set; }
        public List<string> Data { get; set; }
        public string Message { get; set; }

        public ResponseData()
        {
            Status = StatusEnum.Success;
            Data = new List<string>();
            Message = "";
        }
    }
}
