﻿using System;
using MarsRoverStudyCase.Models;
using MarsRoverStudyCase.Models.Common;
using MarsRoverStudyCase.Models.Enums;

namespace MarsRoverStudyCase.Helpers
{
    public class CaseHelper
    {
        public static ResponseData Calculate(CaseModel data)
        {
            var result = new ResponseData();
            try
            {
                //Validation Control
                var validControl = ValidationControl(data);
                if (validControl.Status == StatusEnum.Error)
                    return validControl;
                
                int positionX = data.PositionInfo.X;
                int positionY = data.PositionInfo.Y;
                var direction = GetDirectionByString(data.PositionInfo.Direction);

                //Executing Commands
                foreach (var command in data.PositionInfo.StringOfLetters)
                {
                    if(command == 'L')
                    {
                        direction = DirectionToLeft(direction);
                    }
                    if (command == 'R')
                    {
                        direction = DirectionToRight(direction);
                    }
                    else
                    {
                        if (direction == DirectionEnum.North)
                            positionY++;
                        else if (direction == DirectionEnum.South)
                            positionY--;
                        else if (direction == DirectionEnum.East)
                            positionX++;
                        else
                            positionX--;
                    }
                }

                result.Data = $"{positionX} {positionY} {direction.ToString()[0]}";
                result.Status = StatusEnum.Success;
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Status = StatusEnum.Error;
            }
            return result;
        }

        private static ResponseData ValidationControl(CaseModel data)
        {
            var result = new ResponseData();
            try
            {
                if (data.PositionInfo.X > data.SizeInfo.X)
                    throw new Exception("Position X cannot be greater than X Size!");

                if (data.PositionInfo.Y > data.SizeInfo.Y)
                    throw new Exception("Position Y cannot be greater than Y Size!");

                if (data.PositionInfo.Direction != "N" && data.PositionInfo.Direction != "S" && data.PositionInfo.Direction != "E" && data.PositionInfo.Direction != "W")
                    throw new Exception("Invalid direction!");

                if (!data.PositionInfo.StringOfLetters.Contains("L") && !data.PositionInfo.StringOfLetters.Contains("R") && !data.PositionInfo.StringOfLetters.Contains("M"))
                    throw new Exception("Invalid string of letters!");
            }
            catch (Exception ex)
            {
                result.Data = ex.Message;
                result.Status = StatusEnum.Error;
            }
            return result;
        }

        private static DirectionEnum GetDirectionByString(string direction)
        {
            if (direction == "N")
                return DirectionEnum.North;
            else if (direction == "S")
                return DirectionEnum.South;
            else if (direction == "E")
                return DirectionEnum.East;
            else
                return DirectionEnum.West;
        }

        private static DirectionEnum DirectionToLeft(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.North:
                    return DirectionEnum.West;
                case DirectionEnum.South:
                    return DirectionEnum.East;
                case DirectionEnum.East:
                    return DirectionEnum.North;
                case DirectionEnum.West:
                    return DirectionEnum.South;
                default:
                    return direction;
            }
        }

        private static DirectionEnum DirectionToRight(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.North:
                    return DirectionEnum.East;
                case DirectionEnum.South:
                    return DirectionEnum.West;
                case DirectionEnum.East:
                    return DirectionEnum.South;
                case DirectionEnum.West:
                    return DirectionEnum.North;
                default:
                    return direction;
            }
        }
    }
}
