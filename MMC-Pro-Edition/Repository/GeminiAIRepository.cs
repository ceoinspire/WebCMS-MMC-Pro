using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using System.Text.Unicode;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using MMC_Pro_Edition.Models;
using Mscc.GenerativeAI;
using Newtonsoft.Json;
using NuGet.Packaging.Signing;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Utilities;
namespace MMC_Pro_Edition.Repository
{
    public class GeminiAIRepository
    {
        private readonly IConfiguration _config;
        private readonly string _apiKey;

        private readonly GoogleAI _googleAI;

        public GeminiAIRepository(GoogleAI googleAI)
        {
            _googleAI = googleAI;
        }

        public async Task<string> GenerateContent(string prompt)
        {
            var model = _googleAI.GenerativeModel(Model.Gemini25Flash);

            var request = new GenerateContentRequest(prompt);
            var response = await model.GenerateContent(request);
            return response.Text;
        }
    }
    public interface IDataRepository
    {
        Task<GeneratedContentModel> AnalyzeTextAsync(string title,string type);
        Task<string> AnalyzeTextAsync(string title, bool isHtml);

    }
    public class DataRepository : IDataRepository
    {
        private readonly GeminiAIRepository _geminiService;

        public DataRepository(GeminiAIRepository geminiService)
        {
            _geminiService = geminiService;
        }

        public async Task<GeneratedContentModel> AnalyzeTextAsync(string title, string type)
        {
            string prompt = @"
You are an expert e-commerce copywriter and frontend UI designer.

Generate structured content for:
Title: '" + title + @"'
Type: '" + type + @"'

Return ONLY valid JSON (no markdown, no explanations). The JSON must contain exactly these keys (no extra keys):

{
  'ShortDescription': '(valid HTML fragment using Bootstrap 5 components like card, list-group, grid, or badges; self-contained fragment; NO inline <style>; use multi-colored Bootstrap classes; background white, text black; include Bootstrap icons; elegant layout and styling). Minimum length: ~1000 characters.',
  'Description': '(valid HTML fragment using Bootstrap 5 components; must include <h5>, <p>, <ul>/<li>; cards, rows, columns, or list-groups; NO inline <style>; background white, text black; multi-colored panels; include Bootstrap icons; elegant design). Minimum length: ~1000 characters.',
  'OtherShortDescription': '(alternative short HTML content using Bootstrap 5; multi-colored cards/panels; background white, text black; include icons; elegant layout). Minimum length: ~1000 characters.',
  'OtherDescription': '(alternative long description using Bootstrap 5; cards, list-groups, rows/columns; multi-colored panels; background white, text black; include icons; elegant design). Minimum length: ~1000 characters.',
  'OtherTitle': '(plain text short alternative title)',
  'MetaTitle': '(plain text concise meta title)',
  'MetaTags': '(comma-separated keywords, 5-8 keywords, plain text)',
  'MetaDescription': '(plain text, exactly 150-160 characters, no HTML)'
}

Important constraints:
- Output must be STRICT parseable JSON.
- HTML fragments must be safe Bootstrap 5, elegant, visually appealing, with NO inline styles.
- Background must be white, text black; panels, cards, tabs can use multi-colored Bootstrap classes.
- Use Bootstrap icons effectively for visuals.
- Keep HTML fragments concise (~500 characters).
- MetaDescription MUST be 150–160 characters only.
- Do not add comments, notes, markdown, or text outside the JSON.
- Produce the JSON ONLY.
";



            try
            {
                string aiResponse = await _geminiService.GenerateContent(prompt);

                // Try to robustly parse only the JSON block in case the API wraps text
                var firstBrace = aiResponse.IndexOf('{');
                var lastBrace = aiResponse.LastIndexOf('}');
                var jsonText = firstBrace >= 0 && lastBrace >= 0 && lastBrace > firstBrace
                    ? aiResponse.Substring(firstBrace, lastBrace - firstBrace + 1)
                    : aiResponse;

                var result = JsonConvert.DeserializeObject<GeneratedContentModel>(jsonText);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gemini API Error: {ex.Message}");
                return null;
            }
        }
        public async Task<string> AnalyzeTextAsync(string title,bool isHtml)
        {
            string htmlPrompt = "";
            if (isHtml)
            {
                htmlPrompt= "The entire response **MUST** be formatted using bootstrap structure HTML (including cards panel list randomly) and dont add any CDN or html and body tags. ";
            }
            string prompt = $@"
        You are a professional Content Creator. 
        Write a detailed, realistic, and engaging  ""{title}"".
        
        {htmlPrompt}
        Do not include any introductory text.
    ";
            try
            {
                string analysisResult = await _geminiService.GenerateContent(prompt);

                return analysisResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gemini API Error: {ex.Message}");
                return "Analysis failed due to an external service error.";
            }
        }

    }
    public class GeneratedContentModel
    {
        // Plain text fields (safe for DB indexing)

        public string OtherTitle { get; set; }
        public string MetaTitle { get; set; }
        public string MetaTags { get; set; }        // comma separated
        public string MetaDescription { get; set; }

        // HTML snippets (Bootstrap 5). These are strings containing valid HTML you can render in your UI.
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string OtherShortDescription { get; set; }
        public string OtherDescription { get; set; }
    }


}
