using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            var reversed = $"{word[1]}{word[0]}";

            if (seen.Contains(reversed))
                results.Add($"{word} & {reversed}");
            else
                seen.Add(word);
        }

        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        var counts = new Dictionary<char, int>();

        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        foreach (var c in word1)
            counts[c] = counts.GetValueOrDefault(c, 0) + 1;

        foreach (var c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;
            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        var json = client.GetStringAsync(uri).Result;

        using var document = JsonDocument.Parse(json);
        var features = document.RootElement.GetProperty("features");

        var results = new List<string>();

        foreach (var feature in features.EnumerateArray())
        {
            var properties = feature.GetProperty("properties");

            var place = properties.GetProperty("place").GetString();
            var mag = properties.GetProperty("mag").GetDouble();

            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}
