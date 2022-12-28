using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaelstrom.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BoundingRegion
    {
        public List<int> boundingBox { get; set; }
        public int pageNumber { get; set; }
    }

    public class Key
    {
        public List<BoundingRegion> boundingRegions { get; set; }
        public string content { get; set; }
        public List<Span> spans { get; set; }
    }

    public class KeyValuePair
    {
        public double confidence { get; set; }
        public Key key { get; set; }
        public Value value { get; set; }
    }

    public class Line
    {
        public List<int> boundingBox { get; set; }
        public string content { get; set; }
        public List<Span> spans { get; set; }
    }

    public class OcrResults
    {
        public string modelVersion { get; set; }
        public List<ReadResult> readResults { get; set; }
        public List<ReadStyle> readStyles { get; set; }
        public string version { get; set; }
    }

    public class ReadResult
    {
        public int angle { get; set; }
        public int height { get; set; }
        public List<Line> lines { get; set; }
        public int pageNumber { get; set; }
        public List<SelectionMark> selectionMarks { get; set; }
        public List<Span> spans { get; set; }
        public string unit { get; set; }
        public int width { get; set; }
        public List<Word> words { get; set; }
    }

    public class ReadStyle
    {
        public double confidence { get; set; }
        public bool isHandwritten { get; set; }
        public List<Span> spans { get; set; }
    }

    public class LazarusResultModel
    {
        public string documentId { get; set; }
        public long endTime { get; set; }
        public List<object> entitiesExtracted { get; set; }
        public bool isUrgent { get; set; }
        public List<KeyValuePair> keyValuePairs { get; set; }
        public string modelType { get; set; }
        public OcrResults ocrResults { get; set; }
        public int pages { get; set; }
        public string rawText { get; set; }
        public DateTime requestDateTime { get; set; }
        public long startTime { get; set; }
        public string status { get; set; }
        public List<object> tablesExtracted { get; set; }
    }

    public class SelectionMark
    {
        public List<int> boundingBox { get; set; }
        public double confidence { get; set; }
        public Span span { get; set; }
        public string state { get; set; }
    }

    public class Span
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class Span4
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class Value
    {
        public List<BoundingRegion> boundingRegions { get; set; }
        public string content { get; set; }
        public List<Span> spans { get; set; }
    }

    public class Word
    {
        public List<int> boundingBox { get; set; }
        public double confidence { get; set; }
        public string content { get; set; }
        public Span span { get; set; }
    }


}
