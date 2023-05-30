using System.Collections.Generic;
using System.IO;
using System;
using System.Collections.ObjectModel;
using WpfLab2;
using System.Text;

namespace SubtitlesPluginNamespace
{
    //public class Row
    //{
    //    public TimeSpan ShowTime { get; set; }
    //    public TimeSpan HideTime { get; set; }

    //    public string Text { get; set; }

    //    public string Translation { get; set; }

    //    public Row()
    //    {
    //        ShowTime = TimeSpan.Zero;
    //        HideTime = TimeSpan.Zero;
    //        Text = string.Empty;
    //        Translation = string.Empty;
    //    }

    //    public Row(TimeSpan showtime, TimeSpan hidetime, string text, string translation)
    //    {
    //        ShowTime = showtime;
    //        HideTime = hidetime;
    //        Text = text;
    //        Translation = translation;
    //    }
    //}
    public class SubtitlesPlugin
    {
        string Name { get; }
        string Extension { get; }

        public SubtitlesPlugin(string name, string extension)
        {
            Name = name;
            Extension = extension;
        }

        //public ICollection<Row> Load(string path)
        //{
        //    ObservableCollection<Row> rows = new ObservableCollection<Row>();

        //    string fileName = Path.Combine(path, Name + Extension);

        //    if (File.Exists(fileName))
        //    {
        //        string[] lines = File.ReadAllLines(fileName);

        //        for (int i = 0; i < lines.Length; i+=5)
        //        {
        //            string line = lines[i].Trim();

        //            if (string.IsNullOrEmpty(line))
        //                continue;

        //            if (int.TryParse(line, out int subtitleNumber) && i + 3 < lines.Length)
        //            {
        //                string showHideTimeLine = lines[i + 1];
        //                string text = lines[i + 2];
        //                string translation = lines[i + 3];

        //                string[] showHideTimeParts = showHideTimeLine.Split(new[] { "-->" }, StringSplitOptions.RemoveEmptyEntries);
        //                if (showHideTimeParts.Length == 2 && TimeSpan.TryParseExact(showHideTimeParts[0].Trim(), @"hh\:mm\:ss\,fff", null, out TimeSpan showTime) &&
        //                    TimeSpan.TryParseExact(showHideTimeParts[1].Trim(), @"hh\:mm\:ss\,fff", null, out TimeSpan hideTime))
        //                {
        //                    Row row = new Row(showTime, hideTime, text, translation);
        //                    rows.Add(row);
        //                }
        //            }
        //        }
        //    }

        //    return rows;
        //}

        public ICollection<Row> Load(string path)
        {
            ObservableCollection<Row> rows = new ObservableCollection<Row>();

            string fileName = Path.Combine(path, Name + Extension);

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);

                int i = 0;
                while (i < lines.Length)
                {
                    string line = lines[i].Trim();

                    if (string.IsNullOrEmpty(line))
                    {
                        i++;
                        continue;
                    }

                    if (int.TryParse(line, out int subtitleNumber))
                    {
                        i++;
                        while (string.IsNullOrEmpty(line))
                        {
                            if (i++ >= lines.Length)
                                break;
                        }                   

                        string showHideTimeLine = lines[i].Trim();

                        i++;
                        while (string.IsNullOrEmpty(line))
                        {
                            if (i++ >= lines.Length)
                                break;
                        }

                        StringBuilder textBuilder = new StringBuilder();

                        while (i < lines.Length && !string.IsNullOrEmpty(lines[i].Trim()))
                        {
                            textBuilder.AppendLine(lines[i].Trim());
                            i++;
                        }

                        string text = textBuilder.ToString().Trim();

                        TimeSpan showTime, hideTime;
                        if (TryParseShowHideTime(showHideTimeLine, out showTime, out hideTime))
                        {
                            Row row = new Row(showTime, hideTime, text, "");
                            rows.Add(row);
                        }
                    }

                    //throw new Exception("Invalid file?");
                }
            }

            return rows;
        }


        private bool TryParseShowHideTime(string line, out TimeSpan showTime, out TimeSpan hideTime)
        {
            showTime = TimeSpan.Zero;
            hideTime = TimeSpan.Zero;

            string[] timeParts = line.Split(new[] { "-->" }, StringSplitOptions.RemoveEmptyEntries);

            if (timeParts.Length == 2 &&
                TimeSpan.TryParseExact(timeParts[0].Trim(), @"hh\:mm\:ss\,fff", null, out showTime) &&
                TimeSpan.TryParseExact(timeParts[1].Trim(), @"hh\:mm\:ss\,fff", null, out hideTime))
            {
                return true;
            }

            return false;
        }


        public void Save(string path, ICollection<WpfLab2.Row> subtitles, bool saveText)
        {
            string fileName = Path.Combine(path, Name + Extension);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                int subtitleNumber = 1;

                foreach (WpfLab2.Row subtitle in subtitles)
                {
                    writer.WriteLine(subtitleNumber);
                    writer.WriteLine(subtitle.ShowTime.ToString(@"hh\:mm\:ss\,fff"));
                    writer.WriteLine(subtitle.HideTime.ToString(@"hh\:mm\:ss\,fff"));
                    writer.WriteLine(saveText ? subtitle.Text : subtitle.Translation);
                    writer.WriteLine();
                    subtitleNumber++;
                }
            }
        }
    }
}