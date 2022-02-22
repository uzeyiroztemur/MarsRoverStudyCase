namespace MarsRoverStudyCase.Models
{
    public class CaseModel
    {
        public CaseSizeModel SizeInfo { get; set; }
        public CasePositionModel PositionInfo { get; set; }
    }

    public class CaseSizeModel
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class CasePositionModel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public string StringOfLetters { get; set; }
    }
}
