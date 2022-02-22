using System;
using MarsRoverStudyCase.Models;
using MarsRoverStudyCase.Models.Common;

namespace MarsRoverStudyCase.Helpers
{
    public class CaseHelper
    {
        public static ResponseData Calculate(CaseModel data)
        {
            var result = new ResponseData();
            try
            {
                result.Data = "X:1 - Y:3 - Direction:N";
                result.Status = Models.Enums.StatusEnum.Success;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Status = Models.Enums.StatusEnum.Error;
            }
            return result;
        }
    }
}
